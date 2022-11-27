using System.Text;
using System.Xml;
using System.IO;
using Microsoft.Xml.XMLGen;
using System.Xml.Schema;
using System.Xml.Linq;
using System;

namespace ERPHelper
{
    public static class WDXMLSample
    {
        public static string Generate(string xml, string elem)
        {
            XmlDocument xmlDoc = new XmlDocument();
            string ret = "";

            using (StringWriter sWriter = new StringWriter())
            {
                using (XmlWriter xWriter = XmlTextWriter.Create(sWriter, new XmlWriterSettings()
                {
                    Indent = true
                }))
                {
                    using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(xml)))
                    {
                        xmlDoc.Load(stream);
                        XmlNamespaceManager ns = new XmlNamespaceManager(xmlDoc.NameTable);
                        ns.AddNamespace("xsd", "http://www.w3.org/2001/XMLSchema");
                        using (XmlNodeList childNodes = xmlDoc.SelectNodes("xsd:schema/xsd:element[@name!='" + elem + "']", ns))
                        {
                            foreach (XmlNode childNode in childNodes)
                            {
                                childNode.ParentNode.RemoveChild(childNode);
                            }
                        }
                        XmlSchema schema = XmlSchema.Read(new XmlNodeReader(xmlDoc), null);
                        schema.Namespaces.Add("wd", "urn:com.workday/bsvc");
                        XmlSampleGenerator gen = new XmlSampleGenerator(schema, null);
                        gen.ListLength = 1;
                        gen.MaxThreshold = 1;

                        gen.WriteXml(xWriter);
                    }

                    ret = sWriter.ToString();
                    ret = ret.Replace("p2=", "wd=");
                    ret = ret.Replace("p2:", "wd:");
                    ret = ret.Replace("encoding=\"utf-16\"", "encoding=\"UTF-8\"");
                }
            }
            return ret;
        }
        public static string WrapXSLT(string xmlRequest)
        {
            string nsXSL = "http://www.w3.org/1999/XSL/Transform";
            string nsWD = "urn:com.workday/bsvc";
            string nsEnv = "http://schemas.xmlsoap.org/soap/envelope/";
            string nsXSD = "http://www.w3.org/2001/XMLSchema";
          
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlRequest);

            XmlNode saveRequest = null;
            XmlNode stylesheet = null;
            XmlNode template = null;
            XmlNode env = null;
            XmlNode body = null;
            XmlNode forEach = null;

            // Does a stylesheet element exist?
            if (xmlDoc.SelectSingleNode("//*[local-name() = 'stylesheet']") != null)
            {
                throw new Exception("An XSLT stylesheet already exists in the document.");
            }
            else
            {
                saveRequest = xmlDoc.FirstChild.NextSibling;
            }

            // Rebuild XmlDoc
            xmlDoc = new XmlDocument();
            XmlNode xmldocNode = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
            xmlDoc.AppendChild(xmldocNode);
            XmlNamespaceManager ns = new XmlNamespaceManager(xmlDoc.NameTable);
            ns.AddNamespace("xsl", nsXSL);
            ns.AddNamespace("env", nsEnv);
            ns.AddNamespace("xsd", nsXSD);

            // Envelope and Header
            stylesheet = xmlDoc.CreateElement("xsl", "stylesheet", nsXSL);
            XmlAttribute wd = xmlDoc.CreateAttribute("xmlns:wd");
            wd.Value = nsWD;
            stylesheet.Attributes.Append(wd);
            XmlAttribute version = xmlDoc.CreateAttribute("version");
            version.Value = "2.0";
            stylesheet.Attributes.Append(version);
            XmlComment comment = xmlDoc.CreateComment(" Helpers:  \r\n" +
                "<xsl:value-of select=\"\" /> \r\n" +
                "<xsl:param name=\"\" select=\"\" /> \r\n" +
                "<xsl:variable name=\"\" select=\"\" />\r\n" +
                "<xsl:value-of select=\"format-date(current-date(), '[Y0001]-[M01]-[D01]')\" />\r\n" +
                "");
            stylesheet.AppendChild(comment);

            template = xmlDoc.CreateElement("xsl", "template", nsXSL);
            XmlAttribute match = xmlDoc.CreateAttribute("match");
            match.Value = "/";
            template.Attributes.Append(match);

            env = xmlDoc.CreateElement("env", "Envelope", nsEnv);
            XmlAttribute xsd = xmlDoc.CreateAttribute("xmlns:xsd");
            xsd.Value = nsXSD;
            env.Attributes.Append(xsd);

            body = xmlDoc.CreateElement("Body");

            forEach = xmlDoc.CreateElement("xsl", "for-each", nsXSL);
            XmlAttribute select = xmlDoc.CreateAttribute("select");
            select.Value = "wd:Report_Data/wd:Report_Entry";
            forEach.Attributes.Append(select);

            // Append Elements
            forEach.AppendChild(xmlDoc.ImportNode(saveRequest, true));
            body.AppendChild(forEach);
            env.AppendChild(body);
            template.AppendChild(env);
            stylesheet.AppendChild(template);
            xmlDoc.AppendChild(stylesheet);  

            return new XDeclaration("1.0", "UTF-8", null).ToString() + Environment.NewLine + XDocument.Parse(xmlDoc.OuterXml).ToString();
        }
    }
}

using System.Text;
using System.Xml;
using System.IO;
using Microsoft.Xml.XMLGen;
using System.Xml.Schema;

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
    }
}

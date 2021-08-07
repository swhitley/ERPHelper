using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using Saxon.Api;
using System.Collections.Generic;

namespace ERPHelper
{
    public class SaxonXForm
    {
        public static string TransformXml(string xmlData, string xslData)
        {
            string results = "";
            try
            {
                // Saxon Transformation Start
                Processor xsltProcessor = new Processor();
                DocumentBuilder documentBuilder = xsltProcessor.NewDocumentBuilder();
                documentBuilder.BaseUri = new Uri("file://");
                XdmNode xdmNode = documentBuilder.Build(new StringReader(xmlData));
                XsltCompiler xsltCompiler = xsltProcessor.NewXsltCompiler();

                XsltExecutable xsltExecutable = xsltCompiler.Compile(new StringReader(xslData));

                XsltTransformer xsltTransformer = xsltExecutable.Load();
                xsltTransformer.InitialContextNode = xdmNode;
               
                XdmDestination xdmDest = new XdmDestination();
                xsltTransformer.Run(xdmDest);
                // Saxon Transformation End


                // Handle XML Declaration
                string version = "1.0";
                string encoding = "UTF-8";
                string standalone = null;
                string declaration = new XDeclaration(version, encoding, standalone).ToString() + Environment.NewLine;

                try
                {
                    XDocument xslt = XDocument.Parse(xslData);
                    XNamespace xsl = "http://www.w3.org/1999/XSL/Transform";
                    XElement elem = xslt.Root.Element(xsl + "output");

                    if (elem != null)
                    {
                        if (elem.Attribute("version") != null)
                        {
                            version = elem.Attribute("version").Value;
                        }
                        if (elem.Attribute("encoding") != null)
                        {
                            encoding = elem.Attribute("encoding").Value;
                        }
                        if (elem.Attribute("standalone") != null)
                        {
                            standalone = elem.Attribute("standalone").Value;
                        }
                        declaration = new XDeclaration(version, encoding, standalone).ToString() + Environment.NewLine;

                        // Clear Declaration
                        if (elem.Attribute("omit-xml-declaration") != null && elem.Attribute("omit-xml-declaration").Value == "yes")
                        {
                            declaration = "";
                        }
                        if (elem.Attribute("method") != null && elem.Attribute("method").Value != "xml")
                        {
                            declaration = "";
                        }
                    }
                    // Attempt to prevent duplicate declaration
                    if (xdmDest.XdmNode.OuterXml.StartsWith("<?"))
                    {
                        declaration = "";
                    }
                }
                catch
                {
                    // ignore exception
                }
                results =  declaration + xdmDest.XdmNode.OuterXml;
            }
            catch (Exception e)
            {
                throw e;
            }
            return results;
        }

        public static Dictionary<int, string> XPath(string xmlData, string xPath)
        {
            Processor processor = new Processor();
            XPathCompiler compiler = processor.NewXPathCompiler();
   
            XDocument xDoc = XDocument.Parse(xmlData);           
           
            // Detect namespaces in the document so the user doesn't have to specify them.
            var xmlNameSpaceList = ((IEnumerable)xDoc.XPathEvaluate(@"//namespace::*[not(. = ../../namespace::*)]")).Cast<XAttribute>();
            foreach (var nsNode in xmlNameSpaceList)
            {
                compiler.DeclareNamespace(nsNode.Name.LocalName, nsNode.Value);
            }
            
            DocumentBuilder documentBuilder = processor.NewDocumentBuilder();
            documentBuilder.IsLineNumbering = true;
            documentBuilder.BaseUri = new Uri("file://");
            XdmNode document = documentBuilder.Build(new StringReader(xmlData));       
            XPathSelector selector = compiler.Compile(xPath).Load();            
            selector.ContextItem = document;
            
            XdmValue values = selector.Evaluate();
            Dictionary<int, string> lines = new Dictionary<int, string>();
            foreach(XdmNode value in values)
            {
                lines.Add(value.LineNumber - 1, value.ToString());
            }
            return lines;
        }
    }
}

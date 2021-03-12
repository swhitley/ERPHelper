using System;
using System.IO;
using System.Xml.Linq;
using Saxon.Api;


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
    }
}

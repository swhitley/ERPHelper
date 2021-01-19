using System;
using System.IO;
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
                results = xdmDest.XdmNode.OuterXml;
            }
            catch (Exception e)
            {
                throw e;
            }
            return results;
        }
    }
}

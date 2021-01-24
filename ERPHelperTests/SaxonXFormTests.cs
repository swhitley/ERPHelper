using Microsoft.VisualStudio.TestTools.UnitTesting;
using ERPHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERPHelperTests.Properties;

namespace ERPHelper.Tests
{
    [TestClass()]
    public class SaxonXFormTests
    {
        [TestMethod()]
        public void TransformXmlTest()
        {
            string results = SaxonXForm.TransformXml(Resources.SaxonXFormXML, Resources.SaxonXFormXSLT);
            Assert.AreEqual(Resources.SaxonXFromOutput, results);
        }
    }
}
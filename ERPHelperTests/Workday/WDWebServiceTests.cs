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
    public class WDWebServiceTests
    {
        [TestMethod()]
        public void WrapSOAPTest()
        {
            string results = WDWebService.WrapSOAP("dummy", "dummy", Resources.WDWebServiceTest_WrapSOAPTestInput);
            Assert.AreEqual(Resources.WDWebServiceTest_WrapSOAPTestOutput, results);
        }

        [TestMethod()]
        public void DownloadTest()
        {
            string url = "https://community.workday.com/sites/default/files/file-hosting/productionapi/index.html";
            Dictionary<string, string> results = WDWebService.Download(url);
            Assert.AreEqual(true, results.ContainsValue("Absence_Management"));
        }
    }
}
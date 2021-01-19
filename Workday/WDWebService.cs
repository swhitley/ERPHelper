using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using System.Net;
using HtmlAgilityPack;
using System.Text.Json;

namespace ERPHelper
{
    public class WDWebService
    {
        public static string WrapSOAP(string username, string password, string xmlBody)
        {
            string nsXSD = "http://schemas.xmlsoap.org/soap/envelope/";
            string nsWSSE = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd";
            string oasisPasswordUrl = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordText";
            string usernameTokenPath = "xsd:Envelope/xsd:Header/wsse:Security/wsse:UsernameToken/";

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlBody);
            XmlNode innerBody = xmlDoc.FirstChild.NextSibling;

            if (innerBody.LocalName != "Envelope")
            {
                xmlDoc = new XmlDocument();
                XmlNode xmldocNode = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
                xmlDoc.AppendChild(xmldocNode);
                XmlNode env = xmlDoc.CreateElement("xsd", "Envelope", nsXSD);
                XmlNode header = xmlDoc.CreateElement("xsd", "Header", nsXSD);
                XmlNode sec = xmlDoc.CreateElement("wsse", "Security", nsWSSE);
                XmlNode ut = xmlDoc.CreateElement("wsse", "UsernameToken", nsWSSE);
                XmlNode user = xmlDoc.CreateElement("wsse", "Username", nsWSSE);
                XmlNode pass = xmlDoc.CreateElement("wsse", "Password", nsWSSE);
                user.InnerText = username;
                pass.InnerText = password;
                XmlAttribute pType = xmlDoc.CreateAttribute("Type");
                pType.Value = oasisPasswordUrl;
                pass.Attributes.Append(pType);
                XmlNode body = xmlDoc.CreateElement("env", "Body", nsXSD);
                body.AppendChild(xmlDoc.ImportNode(innerBody, true));

                ut.AppendChild(user);
                ut.AppendChild(pass);
                sec.AppendChild(ut);
                header.AppendChild(sec);
                env.AppendChild(header);
                env.AppendChild(body);
                xmlDoc.AppendChild(env);
            }
            else
            {
                XmlNamespaceManager ns = new XmlNamespaceManager(xmlDoc.NameTable);
                ns.AddNamespace("xsd", nsXSD);
                ns.AddNamespace("wsse", nsWSSE);
               
                xmlDoc.SelectSingleNode(usernameTokenPath + "wsse:Username", ns).InnerText = username;
                xmlDoc.SelectSingleNode(usernameTokenPath + "wsse:Password", ns).InnerText = password;
            }

            return new XDeclaration("1.0", "UTF-8", null).ToString() + Environment.NewLine + XDocument.Parse(xmlDoc.OuterXml).ToString();
        }

        public static Dictionary<string, string> Download(string url)
        {
            string workdayProdApi = "https://community.workday.com/sites/default/files/file-hosting/productionapi/";
            Dictionary<string, string> items = new Dictionary<string, string>();
            string html = "";
            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();

            using (var webClient = new WebClient())
            {
                html = webClient.DownloadString(url);
            }
            htmlDoc.LoadHtml(html);

            HtmlNodeCollection nodes = htmlDoc.DocumentNode.SelectNodes("//a[contains(@href, '.xsd')]");            

            foreach (HtmlNode node in nodes)
            {
                string key = workdayProdApi + node.Attributes["href"].Value;
                string value = key.Substring(key.LastIndexOf("/") + 1).Replace(".xsd", "");
                items.Add(key, value);
            }
            return items;
        }

        public static Dictionary<string, string> Load(string data)
        {
            return  JsonSerializer.Deserialize<Dictionary<string, string>>(data);
        }

        public static string GetServiceURL(string envURL, string tenant, string username, string password)
        {
            string result = "";

            // Get Service Gateway 
            using (var webClient = new WebClient())
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                webClient.Credentials = new NetworkCredential(username + "@" + tenant, password);
                result = webClient.DownloadString(envURL + "/cc-cloud-master/service-gateway");
            }

            return result;
        }

        public static string BuildApiUrl(string conn, string service, string version)
        {
            return Settings.Get(IniSection.Connection, conn, IniKey.URL) + service + "/" + version;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using System.Net;
using HtmlAgilityPack;
using System.Text.Json;
using System.Text;
using System.IO;

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
 
            XmlNode saveBody = null;
            XmlNode env = null;
            XmlNode header = null;
            XmlNode body = null;
 
            // Does a Body element exist?
            if (xmlDoc.SelectSingleNode("//*[local-name() = 'Body']") != null)
            {
                saveBody = xmlDoc.SelectSingleNode("//*[local-name() = 'Body']").FirstChild;
            }
            else
            {
                // Assumes correct document that begins with "<?xml" declaration
                saveBody = xmlDoc.FirstChild.NextSibling;
            }

            if(saveBody == null)
            {
                throw new Exception("The XML is not well-formed. Please ensure that an xml declaration (<?xml...) is included.");
            }

            // Rebuild XmlDoc
            xmlDoc = new XmlDocument();
            XmlNode xmldocNode = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
            xmlDoc.AppendChild(xmldocNode);
            XmlNamespaceManager ns = new XmlNamespaceManager(xmlDoc.NameTable);
            ns.AddNamespace("xsd", nsXSD);
            ns.AddNamespace("wsse", nsWSSE);

            // Envelope and Header
            env = xmlDoc.CreateElement("xsd", "Envelope", nsXSD);             
            header = xmlDoc.CreateElement("xsd", "Header", nsXSD);

            // Credentials
            XmlNode sec = xmlDoc.CreateElement("wsse", "Security", nsWSSE);
            XmlNode ut = xmlDoc.CreateElement("wsse", "UsernameToken", nsWSSE);
            XmlNode user = xmlDoc.CreateElement("wsse", "Username", nsWSSE);
            XmlNode pass = xmlDoc.CreateElement("wsse", "Password", nsWSSE);
            user.InnerText = username;
            pass.InnerText = password;
            XmlAttribute pType = xmlDoc.CreateAttribute("Type");
            pType.Value = oasisPasswordUrl;
            pass.Attributes.Append(pType);

            // Body
            body = xmlDoc.CreateElement("env", "Body", nsXSD);
            body.AppendChild(xmlDoc.ImportNode(saveBody, true));

            // Append Elements
            ut.AppendChild(user);
            ut.AppendChild(pass);
            sec.AppendChild(ut);
            header.AppendChild(sec);
            env.AppendChild(header);
            env.AppendChild(body);
            xmlDoc.AppendChild(env);
            
            if(xmlDoc.SelectSingleNode(usernameTokenPath + "wsse:Username", ns) != null) {
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

        public static string CallAPI(string username, string password, string url, string xmlData)
        {
            try
            {
                using (var webClient = new WebClient())
                {
                    webClient.Headers.Add("Content-Type", "text/xml; charset=utf-8");
                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                    webClient.Credentials = new NetworkCredential(username, password);
                    byte[] data = Encoding.UTF8.GetBytes(WDWebService.WrapSOAP(username, password, xmlData));
                    byte[] rData = webClient.UploadData(url, data);

                    return new XDeclaration("1.0", "UTF-8", null).ToString() + Environment.NewLine + XDocument.Parse(Encoding.UTF8.GetString(rData)).ToString() + Environment.NewLine;
                }
            }
            catch (WebException webEx)
            {
                String responseFromServer = webEx.Message.ToString() + Environment.NewLine;
                if (webEx.Response != null)
                {
                    using (WebResponse response = webEx.Response)
                    {
                        Stream dataRs = response.GetResponseStream();
                        using (StreamReader reader = new StreamReader(dataRs))
                        {
                            try
                            {
                                responseFromServer += XDocument.Parse(reader.ReadToEnd());
                            }
                            catch
                            {
                                // ignore exception
                            }
                        }
                    }
                }
                return responseFromServer;
            }
        }
        public static string CallRest(string username, string password, string url, string method, bool auth, string data = "")
        {
            using (var webClient = new WebClient())
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                if (auth)
                {
                    webClient.Credentials = new NetworkCredential(username, password);
                }
                if(method != WebRequestMethods.Http.Get.ToUpper())
                { 
                    if(method == "DELETE")
                    {
                        data = String.Empty;
                    }
                    return webClient.UploadString(url, method, data);
                }
                return webClient.DownloadString(url);
            }
        }

    }
}

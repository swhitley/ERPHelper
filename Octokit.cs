using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Octokit;
using System.Reflection;
using System.Net;

namespace ERPHelper
{
    public class Octokit
    {
        public async Task<GitHubRelease> GetLatest()
        {
            GitHubRelease release = new GitHubRelease();
            try
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                GitHubClient client = new GitHubClient(new ProductHeaderValue("erp-helper"));
                Release latestRelease = await client.Repository.Release.GetLatest("swhitley", "ERPHelper");
                Version latestGitHubVersion = new Version(latestRelease.TagName.Replace("v", ""));                
                string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
                Version localVersion = new Version(version.Substring(0, version.LastIndexOf(".")));
                release.UpdateAvailable = localVersion.CompareTo(latestGitHubVersion) != 0 ? true : false;
                release.Description = latestRelease.Body;
                release.Version = latestGitHubVersion.ToString();
                
            }
            catch
            {
                // ignore exception
            }
            return release;
        }
    }
}

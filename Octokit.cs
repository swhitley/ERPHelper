using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Octokit;
using System.Reflection;

namespace ERPHelper
{
    public class Octokit
    {
        public async Task<GitHubRelease> GetLatest()
        {
            GitHubRelease release = new GitHubRelease();
            try
            {
                
                GitHubClient client = new GitHubClient(new ProductHeaderValue("erp-helper"));
                IReadOnlyList<Release> releases = await client.Repository.Release.GetAll("swhitley", "ERPHelper");
                Version latestGitHubVersion = new Version(releases[0].TagName.Replace("v", ""));                
                string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
                Version localVersion = new Version(version.Substring(0, version.LastIndexOf(".")));
                release.UpdateAvailable = localVersion.CompareTo(latestGitHubVersion) != 0 ? true : false;
                release.Description = releases[0].Body;
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

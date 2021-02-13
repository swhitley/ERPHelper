using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPHelper
{
    public class GitHubRelease
    {
        public bool UpdateAvailable { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
    }
}

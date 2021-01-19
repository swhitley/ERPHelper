using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPHelper
{
    class AssemblyCustomAttributes
    {
    }
    [AttributeUsage(AttributeTargets.Assembly)]
    public class AssemblyProductLinkAttribute : Attribute
    {
        public string ProductLink{ get; private set; }

        public AssemblyProductLinkAttribute() : this(string.Empty) { }
        public AssemblyProductLinkAttribute(string value) { ProductLink = value; }
    }
}

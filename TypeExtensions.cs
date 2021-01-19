using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace ERPHelper
{
    public static class TypeExtensions
    {
        // string
        public static string RemoveNonAlphaNumeric(this string input)
        {
            char[] arr = input.Where(c => (char.IsLetterOrDigit(c) ||
                             char.IsWhiteSpace(c) ||
                             c == '-')).ToArray();

            return new string(arr);
        }  
    }
}

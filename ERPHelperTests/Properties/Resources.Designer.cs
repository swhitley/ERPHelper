﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ERPHelperTests.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("ERPHelperTests.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot;?&gt;
        ///&lt;?xml-stylesheet type=&quot;text/xsl&quot;?&gt;
        ///&lt;hello-world&gt;
        ///	&lt;greeter&gt;A Developer&lt;/greeter&gt;
        ///	&lt;greeting&gt;Hello, World!&lt;/greeting&gt;
        ///&lt;/hello-world&gt;.
        /// </summary>
        internal static string SaxonXFormXML {
            get {
                return ResourceManager.GetString("SaxonXFormXML", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot;?&gt;
        ///&lt;xsl:stylesheet xmlns:xsl=&quot;http://www.w3.org/1999/XSL/Transform&quot;
        ///                version=&quot;1.0&quot;&gt;
        ///	&lt;xsl:output method=&quot;html&quot; /&gt;
        ///	&lt;xsl:template match=&quot;/hello-world&quot;&gt;
        ///		&lt;HTML&gt;
        ///			&lt;HEAD&gt;
        ///				&lt;TITLE/&gt;
        ///			&lt;/HEAD&gt;
        ///			&lt;BODY&gt;
        ///				&lt;H1&gt;
        ///					&lt;xsl:value-of select=&quot;greeting&quot;/&gt;
        ///				&lt;/H1&gt;
        ///				&lt;xsl:apply-templates select=&quot;greeter&quot;/&gt;
        ///			&lt;/BODY&gt;
        ///		&lt;/HTML&gt;
        ///	&lt;/xsl:template&gt;
        ///	&lt;xsl:template match=&quot;greeter&quot;&gt;
        ///		&lt;DIV&gt;To
        ///			&lt;I&gt;
        ///				&lt;xsl:value-of select=&quot;.&quot;/&gt;
        ///			&lt;/I&gt;
        ///		&lt;/DIV&gt;
        ///	&lt;/xsl:templat [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string SaxonXFormXSLT {
            get {
                return ResourceManager.GetString("SaxonXFormXSLT", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;!DOCTYPE HTML&gt;&lt;HTML&gt;
        ///   &lt;HEAD&gt;
        ///      &lt;meta http-equiv=&quot;Content-Type&quot; content=&quot;text/html; charset=UTF-8&quot;&gt;
        ///      &lt;TITLE&gt;&lt;/TITLE&gt;
        ///   &lt;/HEAD&gt;
        ///   &lt;BODY&gt;
        ///      &lt;H1&gt;Hello, World!&lt;/H1&gt;
        ///      &lt;DIV&gt;To
        ///         			&lt;I&gt;A Developer&lt;/I&gt;&lt;/DIV&gt;
        ///   &lt;/BODY&gt;
        ///&lt;/HTML&gt;.
        /// </summary>
        internal static string SaxonXFromOutput {
            get {
                return ResourceManager.GetString("SaxonXFromOutput", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;UTF-8&quot;?&gt;
        ///&lt;wd:Get_Workers_Request xmlns:wd=&quot;urn:com.workday/bsvc&quot; wd:version=&quot;v35.0&quot;&gt;
        ///	&lt;wd:Request_References wd:Ignore_Invalid_References=&quot;true&quot; wd:Skip_Non_Existing_Instances=&quot;true&quot;&gt;
        ///		&lt;wd:Worker_Reference&gt;
        ///			&lt;wd:ID wd:type=&quot;Employee_ID&quot;&gt;MYID&lt;/wd:ID&gt;
        ///		&lt;/wd:Worker_Reference&gt;
        ///	&lt;/wd:Request_References&gt;
        ///&lt;/wd:Get_Workers_Request&gt;.
        /// </summary>
        internal static string WDWebServiceTest_WrapSOAPTestInput {
            get {
                return ResourceManager.GetString("WDWebServiceTest.WrapSOAPTestInput", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;UTF-8&quot;?&gt;
        ///&lt;xsd:Envelope xmlns:xsd=&quot;http://schemas.xmlsoap.org/soap/envelope/&quot;&gt;
        ///  &lt;xsd:Header&gt;
        ///    &lt;wsse:Security xmlns:wsse=&quot;http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd&quot;&gt;
        ///      &lt;wsse:UsernameToken&gt;
        ///        &lt;wsse:Username&gt;dummy&lt;/wsse:Username&gt;
        ///        &lt;wsse:Password Type=&quot;http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordText&quot;&gt;dummy&lt;/wsse:Password&gt;
        ///      &lt;/wsse:UsernameToken&gt;
        ///    &lt;/wsse:Securit [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string WDWebServiceTest_WrapSOAPTestOutput {
            get {
                return ResourceManager.GetString("WDWebServiceTest.WrapSOAPTestOutput", resourceCulture);
            }
        }
    }
}

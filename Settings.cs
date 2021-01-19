using System.Text;
using Kbg.NppPluginNET.PluginInfrastructure;
using System.IO;

namespace ERPHelper
{
    public enum IniSection
    {
        Connection,
        Connections,
        State,
        WDStudio,
        WDWebServices
    }
    public enum IniKey
    {
        Environment,
        Names,
        Password,
        SavePassword,
        Tenant,
        URL,
        Username,
        Version,
        Workspace,
        WorkspaceFilter,
        XSD
    }

    public static class Settings
    {
        public static string iniFilePath = null;

        public static string Get(IniSection section, string key)
        {
            return Settings.Get(section.ToString(), key);
        }
        public static void Set(IniSection section, string key, string value)
        {
            Settings.Set(section.ToString(), key, value);
        }
        public static string Get(IniSection section, IniKey key)
        {
            return Settings.Get(section.ToString(), key.ToString());
        }
        public static void Set(IniSection section, IniKey key, string value)
        {
            Settings.Set(section.ToString(), key.ToString(), value);
        }
        public static string Get(IniSection section, string sectionSuffix, IniKey key)
        {
            return Settings.Get(section.ToString() + "." + sectionSuffix, key.ToString());
        }
        public static void Set(IniSection section, string sectionSuffix, IniKey key, string value)
        {
            Settings.Set(section.ToString() + "." + sectionSuffix, key.ToString(), value);
        }
        public static void DeleteSection(IniSection section, string sectionSuffix)
        {
            Settings.Set(section.ToString() + "." + sectionSuffix, null, null);
        }
 
        public static void Init(string pluginName)
        {
            StringBuilder sbIniFilePath = new StringBuilder(Win32.MAX_PATH);
            Win32.SendMessage(PluginBase.nppData._nppHandle, (uint)NppMsg.NPPM_GETPLUGINSCONFIGDIR, Win32.MAX_PATH, sbIniFilePath);
            iniFilePath = sbIniFilePath.ToString();
            if (!Directory.Exists(iniFilePath)) Directory.CreateDirectory(iniFilePath);
            iniFilePath = Path.Combine(iniFilePath, pluginName + ".ini");
        }

        public static void Cleanup()
        {
        }

        public static void Set(string section, string key, string value)
        {
            Win32.WritePrivateProfileString(section, key, value, iniFilePath);

        }

        public static string Get(string section, string key)
        {
            StringBuilder ret = new StringBuilder(500);
            Utils.GetPrivateProfileString(section, key, "", ret, (uint)ret.Capacity, iniFilePath);

            return ret.ToString();
        }
    }
}

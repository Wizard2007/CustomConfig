using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomConfig
{
    class Program
    {
        static void Main(string[] args)
        {
			//https://msdn.microsoft.com/en-us/library/2tw134k3.aspx

            setConfigFileAtRuntime(@".\CustomConfig\CustomConfig\bin\Debug\1.config");
            Console.WriteLine(ConfigurationManager.AppSettings["test"].ToString());
            StartupFoldersConfigSection section = (StartupFoldersConfigSection)ConfigurationManager.GetSection("StartupFoldersGroup/StartupFolders");

            if (section != null)
            {
                Console.WriteLine(section.FolderItems[0].folderType);
                Console.WriteLine(section.FolderItems[0].Path);
            }
        }
        protected static void setConfigFileAtRuntime(string args)
        {   // change config file name 
            //https://www.codeproject.com/Articles/616065/Why-Where-and-How-of-NET-Configuration-Files
            AppDomain.CurrentDomain.SetData("APP_CONFIG_FILE", args);
        }
    }
}

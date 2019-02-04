using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomConfig
{// https://habrahabr.ru/post/128517/
 // https://msdn.microsoft.com/en-us/library/system.appdomainsetup.configurationfile.aspx
    public class StartupFoldersConfigSection: ConfigurationSection
    {
        [ConfigurationProperty("Folders")]
        public FoldersCollection FolderItems
        {
            get { return (FoldersCollection)(base["Folders"]); }
        }
    }
    [ConfigurationCollection( typeof(FolderElement), AddItemName="Folder")]
    public class FoldersCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new FolderElement();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((FolderElement)(element)).folderType;
        }
        public FolderElement this[int idx]
        {
            get { return (FolderElement)BaseGet(idx); }
        }
    }
    public class FolderElement : ConfigurationElement
    {
        [ConfigurationProperty("folderType", DefaultValue = "", IsKey = false, IsRequired = false)]
        public string folderType
        {
            get { return ((string)(base["folderType"])); }
            set { base["folderType"] = value; }
        }

        [ConfigurationProperty("path", DefaultValue = "", IsKey = false, IsRequired = false)]
        public string Path
        {
            get { return ((string)(base["path"]));}
            set { base["path"] = value; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Xml;

namespace Backend.Utilities.FilePath
{
    public class FilePathConfigurationSectionHandler : IConfigurationSectionHandler
    {
        public object Create(object parent, object configContext, System.Xml.XmlNode section)
        {
            FilePathConfigurationSection fpcs = new FilePathConfigurationSection();
            foreach (XmlNode node in section.ChildNodes)
            {
                if (node.Name == "photo")
                {
                    fpcs.PhotoLocalPath = node.Attributes["localPath"].Value;
                    fpcs.PhotoDefaultIcon = node.Attributes["defaultIcon"].Value;
                    fpcs.PhotoHttpPrefix = node.Attributes["httpPrefix"].Value;
                }
                else if (node.Name == "newsImage")
                {
                    fpcs.NewsImageLocalPath = node.Attributes["localPath"].Value;
                    fpcs.NewsDefaultIcon = node.Attributes["defaultIcon"].Value;
                    fpcs.NewsImageHttpPrefix = node.Attributes["httpPrefix"].Value;
                }
            }
            return fpcs;
        }
    }
}

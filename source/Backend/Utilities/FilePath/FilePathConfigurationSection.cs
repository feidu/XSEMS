using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Utilities.FilePath
{
    public class FilePathConfigurationSection
    {
        
        private string _PhotoLocalPath;

        public string PhotoLocalPath
        {
            get { return _PhotoLocalPath; }
            set { _PhotoLocalPath = value; }
        }

        private string _PhotoDefaultIcon;

        public string PhotoDefaultIcon
        {
            get { return _PhotoDefaultIcon; }
            set { _PhotoDefaultIcon = value; }
        }

        private string _PhotoHttpPrefix;

        public string PhotoHttpPrefix
        {
            get { return _PhotoHttpPrefix; }
            set { _PhotoHttpPrefix = value; }
        }

        private string _EditorImageLocalPath;

        public string EditorImageLocalPath
        {
            get { return _EditorImageLocalPath; }
            set { _EditorImageLocalPath = value; }
        }

        private string _EditorDefaultIcon;

        public string EditorDefaultIcon
        {
            get { return _EditorDefaultIcon; }
            set { _EditorDefaultIcon = value; }
        }

        private string _EditorImageHttpPrefix;

        public string EditorImageHttpPrefix
        {
            get { return _EditorImageHttpPrefix; }
            set { _EditorImageHttpPrefix = value; }
        }

        private string _BlogImageLocalPath;

        public string BlogImageLocalPath
        {
            get { return _BlogImageLocalPath; }
            set { _BlogImageLocalPath = value; }
        }

        private string _BlogDefaultIcon;

        public string BlogDefaultIcon
        {
            get { return _BlogDefaultIcon; }
            set { _BlogDefaultIcon = value; }
        }

        private string _BlogImageHttpPrefix;

        public string BlogImageHttpPrefix
        {
            get { return _BlogImageHttpPrefix; }
            set { _BlogImageHttpPrefix = value; }
        }

        private string _NewsImageLocalPath;

        public string NewsImageLocalPath
        {
            get { return _NewsImageLocalPath; }
            set { _NewsImageLocalPath = value; }
        }

        private string _NewsDefaultIcon;

        public string NewsDefaultIcon
        {
            get { return _NewsDefaultIcon; }
            set { _NewsDefaultIcon = value; }
        }

        private string _NewsImageHttpPrefix;

        public string NewsImageHttpPrefix
        {
            get { return _NewsImageHttpPrefix; }
            set { _NewsImageHttpPrefix = value; }
        }
    }
}

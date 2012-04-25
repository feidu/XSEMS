using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Web.UI.WebControls;
using System.IO;
using System.Text.RegularExpressions;

namespace Backend.Utilities.FilePath
{
    public class FilePathGenerator
    {
        private static readonly FilePathConfigurationSection FPCS = (FilePathConfigurationSection)ConfigurationManager.GetSection("web.file.path");

        private static readonly Regex UPLAOD_TYPE_REGREX = new Regex(@"(.jpg|.jpeg|.psd|.cda|.cdr|.png|.ai|.gif|.pdf|.rtf|.bmp|.txt|.xls|.doc|.rar|.zip)$", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        private static readonly Regex ICON_TYPE_REGREX = new Regex(@"(.jpg|.jpeg|.gif)$", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        private static readonly Regex IMAGE_TYPE_RECEX = new Regex(@"(.jpg|.jpeg|.gif|.png|.bmp)$", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        
        public const int ICON_MAX_LENGTH = 102400;

        public const int UPLOAD_MAX_LENGTH = 1048576;

        public const int IMAGE_MAX_LENGTH = 6000000;

        public static FilePathConfigurationSection FilePathConfiguration
        {
            get { return FPCS; }
        }

        public static bool ValidateUploadFile(string filename, int length)
        {
            return !StringHelper.IsEmpty(filename) && UPLAOD_TYPE_REGREX.Match(filename).Success && length <= UPLOAD_MAX_LENGTH;
        }

        public static bool VaildateFileImage(string fileImageName, int length)
        {
            return !StringHelper.IsEmpty(fileImageName) && IMAGE_TYPE_RECEX.Match(fileImageName).Success && length <= IMAGE_MAX_LENGTH;
        }

        public static string GeneratePhotoLocalPath(string url)
        {
            string dir = FPCS.PhotoLocalPath + DateTime.Now.ToString(@"yyyy\\MM") + "\\";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            return FPCS.PhotoLocalPath + url;
        }

        public static string GeneratePhotoHttpUrl(string url)
        {
            return FPCS.PhotoHttpPrefix + url;
        }

        public static string GenerateNewsImageLocalPath(string url)
        {
            string dir = FPCS.NewsImageLocalPath + DateTime.Now.ToString(@"yyyy\\MM") + "\\";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            return FPCS.NewsImageLocalPath + url;
        }

        public static string GenerateNewsImageHttpUrl(string url)
        {
            return FPCS.NewsImageHttpPrefix + url;
        }

        /// <summary>
        /// 删除文件文件或图片
        /// </summary>
        /// <param name="path">当前文件的路径</param>
        /// 是否删除成功
        public static bool FilePicDelete(string path)
        {
            bool ret = false;
            System.IO.FileInfo file = new System.IO.FileInfo(path);
            if (file.Exists)
            {
                file.Delete();
                ret = true;
            }
            return ret;
        }

        /// <summary>
        /// 缩小图片
        /// </summary>
        /// <param name="strOldPic">源图文件名(包括路径)</param>
        /// <param name="strNewPic">缩小后保存为文件名(包括路径)</param>
        /// <param name="intWidth">缩小至宽度</param>
        /// <param name="intHeight">缩小至高度</param>

        public static void SmallPic(string strOldPic, string strNewPic, int intWidth, int intHeight)
        {
            System.Drawing.Bitmap objPic, objNewPic;
            try
            {
                objPic = new System.Drawing.Bitmap(strOldPic);
                objNewPic = new System.Drawing.Bitmap(objPic, intWidth, intHeight);
                objNewPic.Save(strNewPic);
            }
            catch (Exception exp)
            { throw exp; }
            finally
            {
                objPic = null;
                objNewPic = null;
            }
        }

        public static string GenerateFilePath(string filename)
        {
            string ext = GetExtName(filename);
            return DateTime.Now.ToString(@"yyyy\/MM") + "/"+DateTime.Now.Day.ToString() + EncryptionHelper.GenerateKey() + "." + ext;

        }

        public static bool ValidateIconFile(string filename, int length)
        {
            return !StringHelper.IsEmpty(filename) && ICON_TYPE_REGREX.Match(filename).Success && length <= ICON_MAX_LENGTH;
        }

        public static string GetExtName(string filename)
        {
            string ext = null;
            int p = filename.LastIndexOf(".") + 1;
            if (p > 0)
            {
                ext = filename.Substring(p, filename.Length - p);
            }
            return ext;
        }

    }
}

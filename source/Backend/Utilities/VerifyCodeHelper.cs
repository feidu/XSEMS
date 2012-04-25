using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.Drawing.Imaging;

namespace Backend.Utilities
{
    public class VerifyCodeHelper : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        public static readonly Font FONT = new Font(new FontFamily("Arial"), 9);

        public static readonly Brush FONT_BRUSH = new SolidBrush(Color.Gray);

        public static readonly Point FONT_POINT = new Point(1, 0);

        public const string CONTENT_TYPE = "image/gif";

        public static readonly Brush OUTER_RECTANGLE_BRUSH = new SolidBrush(Color.LightGray);

        public static readonly Brush INNER_RECTANGLE_BRUSH = new SolidBrush(Color.White);

        public const string SESSION_NAME = "MF.VerifyCode";

        public static bool IsValid(HttpContext context, string id)
        {
            if (string.IsNullOrEmpty(context.Request.Form[id])) return false;
            if (context.Session[SESSION_NAME] == null) return false;
            return context.Request.Form[id] == context.Session[SESSION_NAME].ToString();
        }

        public void ProcessRequest(HttpContext context)
        {
            string num = new Random().Next(1000, 9999).ToString();

            // set session
            context.Session[SESSION_NAME] = num;

            // output image
            context.Response.ContentType = CONTENT_TYPE;
            Bitmap bm = new Bitmap(35, 15);
            Graphics gp = Graphics.FromImage(bm);
            gp.FillRectangle(OUTER_RECTANGLE_BRUSH, 0, 0, 35, 15);
            gp.FillRectangle(INNER_RECTANGLE_BRUSH, 1, 1, 33, 13);
            gp.DrawString(num, FONT, FONT_BRUSH, FONT_POINT);
            bm.Save(context.Response.OutputStream, ImageFormat.Gif);
        }

        public bool IsReusable
        {
            get { return true; }
        }

    }

}

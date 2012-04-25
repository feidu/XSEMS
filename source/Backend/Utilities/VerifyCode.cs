using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Backend.Utilities
{
    /// <summary>
    /// Summary description for VerifyCode
    /// </summary>
    public class VerifyCode : Control
    {
        protected override void Render(HtmlTextWriter writer)
        {
            writer.Write("<script type=\"text/javascript\" src=\"");
            writer.Write("/Admin/Js/VerifyCode.js");
            writer.Write("\"></script>");
            writer.Write("<div class=\"");
            writer.Write(_CssClass);
            writer.Write("\"><input id=\"");
            writer.Write(this.ID);
            writer.Write("\" name=\"");
            writer.Write(this.ID);

            writer.Write("\" class=\"");
            writer.Write(_InputClass);

            writer.Write("\"/> <span id=\"");
            writer.Write(this.ID);
            writer.Write("Span\"></span><script>refreshVerifyCodeHtml(\"");
            writer.Write(this.ID);
            writer.Write("Span\");</script></div>");
        }


        private string _CssClass;

        public string CssClass
        {
            get { return _CssClass; }
            set { _CssClass = value; }
        }

        private string _InputClass;

        public string InputClass
        {
            get { return _InputClass; }
            set { _InputClass = value; }
        }

    }
}
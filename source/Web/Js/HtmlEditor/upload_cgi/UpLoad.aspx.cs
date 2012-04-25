using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Backend.Utilities.FilePath;
using Backend.Utilities;

public partial class Js_HtmlEditor_upload_cgi_Upload : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack) this.SaveImages();
    }

    private Boolean SaveImages()
    {
        string imgWidth = Request.Form["imgWidth"];
        string imgHeight = Request.Form["imgHeight"];
        string imgBorder = Request.Form["imgBorder"];
        string imgTitle = Request.Form["imgTitle"];
        string imgAlign = Request.Form["imgAlign"];
        string imgHspace = Request.Form["imgHspace"];
        string imgVspace = Request.Form["imgVspace"];

        ////����File��Ԫ��
        HttpFileCollection files = HttpContext.Current.Request.Files;
        try
        {
            //'����ļ���չ����
            HttpPostedFile postedFile = files[0];
            string fileName;
            fileName = System.IO.Path.GetFileName(postedFile.FileName);//��ȡ��ʼ�ļ���
            string helpImagePath = string.Empty;
            if (!StringHelper.IsEmpty(fileName))
            {
                helpImagePath = FilePathGenerator.GenerateFilePath(fileName);
                postedFile.SaveAs(FilePathGenerator.GenerateNewsImageLocalPath(helpImagePath));
            }

            //����ͼƬ���رղ�
            string fileUrl = FilePathGenerator.GenerateNewsImageHttpUrl(helpImagePath);
            fileUrl = fileUrl.Replace('\\','/');
            Response.Write("<html>");
            Response.Write("<head>");
            Response.Write("<title>Insert Image</title>");
            Response.Write("<meta http-equiv=\"content-type\" content=\"text/html; charset=utf-8\">");
            Response.Write("</head>");
            Response.Write("<body>");
            Response.Write("<script>parent.KindInsertImage(\"" + fileUrl + "\",\"" + imgWidth + "\",\"" + imgHeight + "\",\"" + imgBorder + "\",\"" + imgTitle + "\",\"" + imgAlign + "\",\"" + imgHspace + "\",\"" + imgVspace + "\");</script>");
            Response.Write("</body>");
            Response.Write("</html>");
            //��ʾ�Ƿ�ɹ���
            //Response.Write("<div style=\"font-size:12px;color:#333333;padding-top:0px;\">�ļ��Ѿ��ɹ��ϴ���[ <a style=\"CURSOR: pointer\" onclick=history.go(-1) ><font color=red>�����ϴ�</font></a> ]</div>");
            return true;

        }
        catch (System.Exception Ex)
        {
            Response.Write("<div style=\"font-size:12px;color:#333333;padding-top:0px;\">�ϴ�ʧ��,ԭ��("+Ex.Message+")[ <a style=\"CURSOR: pointer\" onclick=history.go(-1) ><font color=red>�����ϴ�</font></a> ]</div>");
            Response.End();
            return false;
        }
    }
}

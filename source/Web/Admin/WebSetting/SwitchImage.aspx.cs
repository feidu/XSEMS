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
using Backend.Models;
using Backend.BAL;
using Backend.Utilities;
using Backend.Models.Pagination;
using System.Collections.Generic;
using Backend.Authorization;
using Backend.Utilities.FilePath;

public partial class Admin_WebSetting_SwitchImage : System.Web.UI.Page
{
    private List<Ad> list = null;
    private static readonly string HTTP = "http://";

    protected void Page_Load(object sender, EventArgs e)
    {
        list = SettingOperation.GetAdSortByNum();
        if (!IsPostBack)
        {
            DataTable dt = CreateDataTable();
            if (list.Count == 0)
            {
                dt = AddNewRow(dt);
            }
            else
            {
                dt = BindData(dt);
            }
            BindRepeater(dt);
            AlertConfirmDialogBox();
            lblMsg.Text = "";
        }
    }

    private void AlertConfirmDialogBox()
    {
        DataTable currentDt = GetDataTable();
        if (currentDt.Rows.Count > 0)
        {
            DataRow lastNow = currentDt.Rows[currentDt.Rows.Count - 1];
            int id = 0;
            if (int.TryParse(lastNow[1].ToString(), out id))
            {
                lbSubtract.Attributes.Add("onclick", "return confirm('您确认要删除最后一行吗？删除以后不可恢复！');");
            }
            else
            {
                lbSubtract.Attributes.Remove("onclick");
            }
        }

    }

    private DataTable BindData(DataTable dt)
    {
        for (int i = 0; i < list.Count; i++)
        {
            DataRow row = dt.NewRow();
            row[0] = dt.Rows.Count + 1;
            row[1] = list[i].Id;
            row[2] = list[i].Path;
            row[3] = list[i].Url.Replace(HTTP, "");
            row[4] = list[i].Title;
            row[5] = list[i].SortNum;
            dt.Rows.Add(row);
        }
        return dt;
    }

    private DataTable CreateDataTable()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add(new DataColumn("RowId", typeof(int)));
        dt.Columns.Add(new DataColumn("Id", typeof(string)));
        dt.Columns.Add(new DataColumn("Path", typeof(string)));
        dt.Columns.Add(new DataColumn("Url", typeof(string)));
        dt.Columns.Add(new DataColumn("Title", typeof(string)));
        dt.Columns.Add(new DataColumn("SortNum", typeof(int)));
        return dt;
    }

    private DataTable GetDataTable()
    {
        DataTable dt = CreateDataTable();
        for (int i = 0; i < rep.Items.Count; i++)
        {
            DataRow row = dt.NewRow();
            row[0] = dt.Rows.Count + 1;
            row[1] = ((HiddenField)rep.Items[i].FindControl("hdId")).Value;

            int id = 0;
            if (int.TryParse(row[1].ToString(), out id))
            {
                Ad ad = SettingOperation.GetAdbyId(id);
                row[2] = ad.Path;
            }
            else
            {
                row[2] = ((FileUpload)rep.Items[i].FindControl("fuImage")).FileName;
            }
            row[3] = ((TextBox)rep.Items[i].FindControl("txtUrl")).Text;
            row[4] = ((TextBox)rep.Items[i].FindControl("txtTitle")).Text;
            row[5] = ((TextBox)rep.Items[i].FindControl("txtSortNum")).Text;
            dt.Rows.Add(row);
        }
        return dt;
    }

    private DataTable AddNewRow(DataTable dt)
    {
        DataRow row = dt.NewRow();
        row[0] = dt.Rows.Count + 1;
        row[1] = "";
        row[2] = "";
        row[3] = "";
        row[4] = "";
        row[5] = "0";
        dt.Rows.Add(row);
        return dt;
    }

    private DataTable DeleteRow()
    {
        DataTable dt = GetDataTable();
        if (dt.Rows.Count < 1) return dt;
        DataRow lastNow = dt.Rows[dt.Rows.Count - 1];
        int id = 0;
        if (int.TryParse(lastNow[1].ToString(), out id))
        {
            SettingOperation.DeleteAdById(id);
        }
        dt.Rows.RemoveAt(dt.Rows.Count - 1);
        return dt;
    }

    private void BindRepeater(DataTable dt)
    {
        rep.DataSource = dt;
        rep.DataBind();
    }

    protected void lbAdd_Click(object sender, EventArgs e)
    {

        DataTable dt = GetDataTable();
        dt = AddNewRow(dt);
        BindRepeater(dt);
        lbSubtract.Attributes.Remove("onclick");
    }

    protected void lbSubtract_Click(object sender, EventArgs e)
    {
        AlertConfirmDialogBox();
        DataTable dt = DeleteRow();
        BindRepeater(dt);
        
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < rep.Items.Count; i++)
        {
            RepeaterItem item = rep.Items[i];
            HiddenField hdId = ((HiddenField)item.FindControl("hdId"));
            FileUpload fuImage = ((FileUpload)item.FindControl("fuImage"));
            TextBox txtUrl = ((TextBox)item.FindControl("txtUrl"));
            TextBox txtTitle = ((TextBox)item.FindControl("txtTitle"));
            TextBox txtSortNum = ((TextBox)item.FindControl("txtSortNum"));
            string url = txtUrl.Text;
            if (url != "") url = HTTP + url;
            string title = txtTitle.Text;
            string sId = hdId.Value;
            string sortNum = txtSortNum.Text;
            if (!string.IsNullOrEmpty(url) && Validator.IsMatchLessThanChineseCharacter(url, 100))
            {
                lblMsg.Text = "第" + (i + 1) + "行,链接地址不能超过100个字符！";
                return;
            }
            if (!string.IsNullOrEmpty(title) && Validator.IsMatchLessThanChineseCharacter(title, 100))
            {
                lblMsg.Text = "第" + (i + 1) + "行,描述不能超过100个字符！";
                return;
            }
            int num = 0;
            if (string.IsNullOrEmpty(sortNum) || !int.TryParse(sortNum, out num))
            {
                num = 0;
            }
            string filePath = string.Empty;
            if (!StringHelper.IsEmpty(fuImage.FileName))
            {
                if (!FilePathGenerator.VaildateFileImage(fuImage.FileName, fuImage.PostedFile.ContentLength))
                {
                    lblMsg.Text = "第" + (i + 1) + "行,上传图片出错，请重新上传！";
                    return;
                }
                filePath = FilePathGenerator.GenerateFilePath(fuImage.FileName);
                fuImage.PostedFile.SaveAs(FilePathGenerator.GeneratePhotoLocalPath(filePath));
            }
            if (sId == "")
            {
                if (string.IsNullOrEmpty(filePath)) continue;
                Ad ad = new Ad();
                ad.Path = filePath;
                ad.Title = title;
                ad.Url = url;
                ad.CreateTime = DateTime.Now;
                ad.SortNum = num;
                SettingOperation.CreateAd(ad);
            }
            else
            {
                int id = 0;
                if (!int.TryParse(sId, out id)) continue;
                Ad ad = SettingOperation.GetAdbyId(id);
                if (!string.IsNullOrEmpty(filePath))
                {
                    ad.Path = filePath;
                }
                ad.Title = title;
                ad.Url = url;
                ad.CreateTime = DateTime.Now;
                ad.SortNum = num;
                SettingOperation.UpdateAd(ad);
            }
        }
        lblMsg.Text = "操作成功！";
        list = SettingOperation.GetAdSortByNum();
        DataTable dt = CreateDataTable();
        dt = BindData(dt);
        BindRepeater(dt);
        lbSubtract.Attributes.Add("onclick", "return confirm('您确认要删除最后一行吗？删除以后不可恢复！');");
    }
}

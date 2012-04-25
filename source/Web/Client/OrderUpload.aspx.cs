using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Backend.Utilities;
using Backend.Models;
using Backend.Authorization;
using Backend.BAL;
using System.IO;
using System.Text;

public partial class Client_OrderUpload : System.Web.UI.Page
{
    ClientSession clientSession;
    protected void Page_Load(object sender, EventArgs e)
    {
        clientSession = (ClientSession)AuthorizationManager.GetCurrentSessionObject(Context, false);
        if (!IsPostBack)
        {
            //List<ClientAddress> result = ClientAddressOpreation.GetClientAddressByClientId(clientSession.Id);
            //ddlClientAddress.DataSource = result;
            //ddlClientAddress.DataTextField = "SenderName";
            //ddlClientAddress.DataValueField = "Id";
            //ddlClientAddress.DataBind();
        }
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        int clientAddressId = 0;
        //if (ddlClientAddress.SelectedItem==null || !int.TryParse(ddlClientAddress.SelectedItem.Value, out clientAddressId))
        //{
        //    lblMsg.Text = "请添加并选择发件人！";
        //    return;
        //}
        if (fuDataFile.HasFile)
        {
            if (Path.GetExtension(fuDataFile.FileName).ToLower() == ".csv")
            {
                string path = Server.MapPath("~/Uploads/") + DateTime.Now.ToString("yyyyMMdd") + "/";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                path = string.Concat(new object[] { path, "/", DateTime.Now.Ticks, ".csv" });
                fuDataFile.SaveAs(path);
                using (CsvReader reader = new CsvReader(path, Encoding.Default))
                {
                    try
                    {
                        List<Dictionary<string, string>> list = reader.ReadAllData();

                        foreach (Dictionary<string, string> item in list)
                        {
                            if (item.Count == 46)
                            {
                                string status = item["Status"];
                                string balanceImpact = item["Balance Impact"];
                                if (status == "Completed" && balanceImpact == "Credit")
                                {
                                    ClientOrder co = new ClientOrder();
                                    co.Email = item["From Email Address"];
                                    co.Country = item["Country"];
                                    co.City = item["Town/City"];
                                    co.Postcode = item["Zip/Postal Code"];
                                    co.Phone = item["Contact Phone Number"];
                                    co.ClientAddressId = clientAddressId;
                                    co.RealName = item["Name"];
                                    co.Remark = "";
                                    co.ClientId = clientSession.Id;
                                    co.Encode = StringHelper.GetEncodeNumber("YD");
                                    co.CreateTime = DateTime.Now;
                                    co.Address = item["Address Line 1"] + " " + item["Address Line 2/District"];
                                    ClientOrderOperation.CreateClientOrder(co);
                                }
                            }
                            else if (item.Count == 35)
                            {
                                string toUserName = item["Buyer Fullname"];
                                string toCountry = item["Buyer Country"];
                                string toAddress = item["Buyer Address 1"] + " " + item["Buyer Address 2"];
                                if (!string.IsNullOrEmpty(toAddress) && !string.IsNullOrEmpty(toUserName) && !string.IsNullOrEmpty(toCountry))
                                {
                                    ClientOrder co = new ClientOrder();
                                    co.Email = item["Buyer Email"];
                                    co.Country = toCountry;
                                    co.City = item["Buyer City"];
                                    co.Postcode = item["Buyer Zip"];
                                    co.Phone = item["Buyer Phone Number"];
                                    co.ClientAddressId = clientAddressId;
                                    co.RealName = toUserName;
                                    co.Remark = "";
                                    co.ClientId = clientSession.Id;
                                    co.Encode = StringHelper.GetEncodeNumber("YD");
                                    co.CreateTime = DateTime.Now;
                                    co.Address = toAddress;
                                    ClientOrderOperation.CreateClientOrder(co);
                                }

                            }
                            else
                            {
                                lblMsg.Text = "请使用正确的格式范本！";
                                return;
                            }
                        }
                        lblMsg.Text = "上传成功！";

                    }
                    catch (Exception exception)
                    {
                        lblMsg.Text = exception.Message;
                    }
                    return;
                }
            }
            lblMsg.Text = "请选择正确的csv文件！";
        }
        else
        {
            lblMsg.Text = "请选择正确的csv文件！";
        }
    }
}
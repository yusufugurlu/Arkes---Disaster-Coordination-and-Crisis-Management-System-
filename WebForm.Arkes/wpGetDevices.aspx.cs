using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebForm.Arkes.Bussiness.Abstract;
using WebForm.Arkes.Bussiness.Concrete;
using WebForm.Arkes.Helpers;

namespace WebForm.Arkes.Pages
{
    public partial class wpGetDevices : System.Web.UI.Page
    {
        private readonly IDeviceService _deviceService;
        public wpGetDevices()
        {
            _deviceService = new DeviceManager();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            PageInformation.PageName = "Cihazlar";
            loadRepeater();
        }

        private void loadRepeater()
        {
            var list = _deviceService.GetDevices();
            rptDevice.DataSource = list;
            rptDevice.DataBind();
        }

        protected void rptOrnek_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "Duzenle")
            {
                Response.Redirect("wpUpdateDevice.aspx?id="+e.CommandArgument);  
            }

        }
    }
}
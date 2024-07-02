using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebForm.Arkes.Bussiness.Abstract;
using WebForm.Arkes.Bussiness.Concrete;
using WebForm.Arkes.Dtos;
using WebForm.Arkes.Helpers;

namespace WebForm.Arkes
{
    public partial class wpAddDevice : System.Web.UI.Page
    {
        private readonly IDeviceService _deviceService;
        private readonly IDeviceTypeService _deviceTypeService;
        public wpAddDevice()
        {
            _deviceService = new DeviceManager();
            _deviceTypeService = new DeviceTypeManager();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadDeviceType();
            }
            PageInformation.PageName = "Cihaz Ekle";

        }

        private void LoadDeviceType()
        {
            var list = _deviceTypeService.GetList();
            drpDeviceType.DataTextField = "Name";
            drpDeviceType.DataValueField = "ID";
            drpDeviceType.DataSource = list;
            drpDeviceType.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            CreateDeviceDto dto = new CreateDeviceDto()
            {
                Name = txtFullName.Text,
                TypeId = Convert.ToInt32(drpDeviceType.SelectedItem.Value),
                Address = txtAddress.Text,
                City = txtCity.Text,
                Id = int.Parse(txtCode.Text)
            };

            var result = _deviceService.CreateDevice(dto);

            if (result.IsSuccess)
            {
                Response.Redirect("wpGetDevices.aspx");
            }
            else
            {
                lblResult.Text = "İşlem sırasında hata oluştu.";
            }
        }

    }
}
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
    public partial class wpUpdateDevice : System.Web.UI.Page
    {
        private readonly IDeviceService _deviceService;
        private readonly IDeviceTypeService _deviceTypeService;
        public wpUpdateDevice()
        {
            _deviceService = new DeviceManager();
            _deviceTypeService = new DeviceTypeManager();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null && !string.IsNullOrEmpty(Request.QueryString["id"].ToString()))
            {
                PageInformation.PageName = "Cihaz Güncelle";
                int deviceId;
                int.TryParse(Request.QueryString["id"].ToString(), out deviceId);
                if (!Page.IsPostBack)
                {
                    var device = _deviceService.GetDeviceById(deviceId);
                    loadCompannent(device);
                }
            }
            else
            {
                Response.Redirect("wpGetDevices.aspx");
            }

        }

        private void loadCompannent(Dtos.DeviceDto device)
        {
            txtFullName.Text = device.Name;
            txtAddress.Text = device.Address;
            txtCity.Text = device.City;
            txtCode.Text = device.ID.ToString();
            LoadDeviceType(device.DeviceTypeId);
        }

        private void LoadDeviceType(int deviceTypeId)
        {
            var list = _deviceTypeService.GetList();
            drpDeviceType.SelectedValue = deviceTypeId.ToString();
            drpDeviceType.DataTextField = "Name";
            drpDeviceType.DataValueField = "ID";
            drpDeviceType.DataSource = list;
            drpDeviceType.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int deviceId;
            int.TryParse(Request.QueryString["id"].ToString(), out deviceId);

            UpdatedDeviceDto dto = new UpdatedDeviceDto()
            {
                Name = txtFullName.Text,
                TypeId = Convert.ToInt32(drpDeviceType.SelectedItem.Value),
                ID = deviceId,
                Address = txtAddress.Text,
                City = txtCity.Text,
                Code = txtCode.Text
            };

            var result = _deviceService.UpdateDevice(dto);

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
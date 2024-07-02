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
    public partial class wpAddUser : System.Web.UI.Page
    {
        private readonly IDeviceService _deviceService;
        private readonly IUserService _userService;

        public wpAddUser()
        {
            _deviceService = new DeviceManager();
            _userService = new UserManager();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadDevice();
            }
            PageInformation.PageName = "Kişi Ekle";
        }

        private void LoadDevice()
        {
            var list = _deviceService.GetDevices();
            drpDevice.DataTextField = "Name";
            drpDevice.DataValueField = "ID";
            drpDevice.DataSource = list;
            drpDevice.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            CreateUserDto dto = new CreateUserDto()
            {
                FullName = txtFullName.Text,
                DeviceID = Convert.ToInt32(drpDevice.SelectedItem.Value)
            };

            var result = _userService.CreateUser(dto);

            if (result.IsSuccess)
            {
                Response.Redirect("wpGetUsers.aspx");
            }
            else
            {
                lblResult.Text = "İşlem sırasında hata oluştu.";
            }
        }
    }
}
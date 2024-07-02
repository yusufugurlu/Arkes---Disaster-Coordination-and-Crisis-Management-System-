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
    public partial class wpUpdateUser : System.Web.UI.Page
    {
        private readonly IDeviceService _deviceService;
        private readonly IUserService _userService;
        public wpUpdateUser()
        {
            _deviceService = new DeviceManager();
            _userService = new UserManager();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null && !string.IsNullOrEmpty(Request.QueryString["id"].ToString()))
            {
                PageInformation.PageName = "Kişi Güncelle";
                int userId;
                int.TryParse(Request.QueryString["id"].ToString(), out userId);
                if (!Page.IsPostBack)
                {
                    var user = _userService.GetUserById(userId);
                    loadCompannent(user);
                }
            }
            else
            {
                Response.Redirect("wpGetUsers.aspx");
            }
        }

        private void loadCompannent(Dtos.UserDto user)
        {
            txtFullName.Text = user.FullName;
            LoadDevice(user.DeviceId);
        }

        private void LoadDevice(int deviceId)
        {
            var list = _deviceService.GetDevices();
            drpDevice.SelectedValue = deviceId.ToString();
            drpDevice.DataTextField = "Name";
            drpDevice.DataValueField = "ID";
            drpDevice.DataSource = list;
            drpDevice.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int deviceId;
            int.TryParse(Request.QueryString["id"].ToString(), out deviceId);

            UpdateUserDto dto = new UpdateUserDto()
            {
                FullName = txtFullName.Text,
                DeviceId = Convert.ToInt32(drpDevice.SelectedItem.Value),
                Id = deviceId
            };

            var result = _userService.UpdateUser(dto);

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
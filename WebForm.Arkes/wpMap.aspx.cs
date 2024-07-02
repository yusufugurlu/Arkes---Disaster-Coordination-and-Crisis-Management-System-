using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebForm.Arkes.Bussiness.Abstract;
using WebForm.Arkes.Bussiness.Concrete;
using WebForm.Arkes.Helpers;

namespace WebForm.Arkes
{
    public partial class wpMap : System.Web.UI.Page
    {
        private readonly IGpsLogService _gpsLogService;
        private readonly IDeviceTypeService _deviceTypeService;
        public wpMap()
        {
            _gpsLogService = new GpsLogManager();
            _deviceTypeService = new DeviceTypeManager();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            PageInformation.PageName = "Harita";
            if (!Page.IsPostBack)
                LoadDeviceType();
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
            int deviceTypeId = 0;
            int.TryParse(drpDeviceType.SelectedValue, out deviceTypeId);

            var logs = _gpsLogService.GetLogsByDeviceTypeId(deviceTypeId);
            if (logs != null)
            {
                if (logs.Count > 0)
                {
                    ConvertLiteral(logs, deviceTypeId);
                    pnlAlert.Visible = false;
                }
                else
                {
                    ltMap.Text = "";
                    pnlAlert.Visible = true;
                    lblMessage.Text = "İlgili sonuç bulunamadı.";
                }
            }
        }

        private void ConvertLiteral(List<Dtos.GpsLogDto> logs, int deviceTypeId)
        {
            var result = _gpsLogService.GetLiteralString(logs, deviceTypeId);
            ltMap.Text = result;
        }
    }
}
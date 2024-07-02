using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebForm.Arkes.Bussiness.Abstract;
using WebForm.Arkes.Bussiness.Concrete;
using WebForm.Arkes.Dtos;

namespace WebForm.Arkes
{
    public partial class HitPageLog : System.Web.UI.Page
    {
        private readonly IGpsLogService _gpsLogService;
        public HitPageLog()
        {
            _gpsLogService = new GpsLogManager();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["a"] != null && !string.IsNullOrEmpty(Request.QueryString["a"].ToString()))
            {
                int deviceId;
                int.TryParse(Request.QueryString["id"].ToString(), out deviceId);
                if (!Page.IsPostBack)
                {
                    _gpsLogService.CreateGpsLog(new CreateGpsLogDto()
                    {
                    });
                }
            }
        }
    }
}
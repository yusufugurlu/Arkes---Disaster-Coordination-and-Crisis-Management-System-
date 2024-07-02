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
    public partial class wpGetUsers : System.Web.UI.Page
    {
        private readonly IUserService _userService;
        public wpGetUsers()
        {
            _userService = new UserManager();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            PageInformation.PageName = "Kişiler";
            loadRepeater();

        }

        private void loadRepeater()
        {
            var list = _userService.GetUsers();
            rptUser.DataSource = list;
            rptUser.DataBind();
        }

        protected void rptDevice_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "Duzenle")
            {
                Response.Redirect("wpUpdateUser.aspx?id=" + e.CommandArgument);
            }
        }
    }
}
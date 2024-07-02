using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebForm.Arkes.Helpers;

namespace WebForm.Arkes.Pages.UserControls
{
    public partial class ucPageHeader : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblPageName.Text = PageInformation.PageName;
        }
    }
}
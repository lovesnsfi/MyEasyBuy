using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyEasyBuy
{
    public partial class Menu : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
        }
    }
}
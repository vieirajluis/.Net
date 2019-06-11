using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WcfServiceExampleClient
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();
            GridView1.DataSource = proxy.GetUsers();
            GridView1.DataBind();
        }
    }
}
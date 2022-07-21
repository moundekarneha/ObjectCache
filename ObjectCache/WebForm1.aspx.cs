using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ObjectCache
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           if(!IsPostBack)
            {
                ViewState["data"] = Cache["data"];
                Cache.Remove("data");   
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataSet ds = (DataSet)ViewState["data"];
            GridView1.DataSource=ds;
            GridView1.DataBind();

        }
    }
}
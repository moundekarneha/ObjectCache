using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace ObjectCache
{
    public partial class Index : System.Web.UI.Page
    {
        SqlConnection conn;
        SqlDataAdapter da;
        DataSet ds=new DataSet();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                conn =new SqlConnection(ConfigurationManager.ConnectionStrings["myconn"].ConnectionString);
                conn.Open();
                da = new SqlDataAdapter("select * from mydata", conn);
                da.Fill(ds,"Emps");
                ViewState["data"] = ds;
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Cache["data"] = ViewState["data"];
            Response.Redirect("WebForm1.aspx");
        }
    }
}
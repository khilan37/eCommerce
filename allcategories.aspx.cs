using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

public partial class allcategories : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        categoryDAL cDAL = new categoryDAL();
        DataSet ds = cDAL.show_category_details();
        Repeater1.DataSource = ds;
        Repeater1.DataBind();
    }
}
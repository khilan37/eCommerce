using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class all_productbrand : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["sub_cat_id"] != null)
        {
            thirdcategoryBAL tBAL = new thirdcategoryBAL();
            tBAL.sub_cat_id = Convert.ToInt16(Request.QueryString["sub_cat_id"]);
            thirdcategoryDAL tDAL = new thirdcategoryDAL();
            DataSet ds = tDAL.show_thirdcategory_productform(tBAL);
            Repeater1.DataSource = ds;
            Repeater1.DataBind();
        }
        else
        {
            Response.Redirect("home.aspx");
        }
    }
}
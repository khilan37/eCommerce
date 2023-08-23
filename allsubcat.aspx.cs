using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class allsubcat : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["cat_id"] != null)
        {
            subcategoryBAL sBAL = new subcategoryBAL();
            sBAL.cat_id = Request.QueryString["cat_id"];
            subcategoryDAL sDAL = new subcategoryDAL();
            DataSet ds = sDAL.show_subcategory_thidcategoryform(sBAL);
            Repeater1.DataSource = ds;
            Repeater1.DataBind();
        }
        else
        {
            Response.Redirect("home.aspx");
        }
    }
}
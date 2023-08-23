using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class productlist : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        productBAL pBAL = new productBAL();
        pBAL.tc_id = Convert.ToInt16(Request.QueryString["tc_id"]);
        pBAL.sub_cat_id = Convert.ToInt16(Request.QueryString["sub_cat_id"]);
        productDAL pDAL = new productDAL();
        if (Request.QueryString["tc_id"] != null)
        {
            DataSet ds = pDAL.show_products(pBAL);
            Repeater1.DataSource = ds;  
            Repeater1.DataBind();
        }
        else if (Request.QueryString["sub_cat_id"]!=null)
        {
            DataSet ds = pDAL.show_subcat_products(pBAL);
            Repeater1.DataSource = ds;
            Repeater1.DataBind();
        }
        else
        {
            DataSet ds = pDAL.show_product_details();
            Repeater1.DataSource = ds;
            Repeater1.DataBind();
        }
    }
}
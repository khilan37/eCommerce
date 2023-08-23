using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_A_BrandList : System.Web.UI.Page
{
    void fillgrid()
    {
        brandDAL bDAL = new brandDAL();
        DataSet ds = bDAL.show_brands();
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        fillgrid();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int sid = Convert.ToInt16(e.CommandArgument);
        brandBAL bBAL = new brandBAL();
        bBAL.brand_id = sid;
        brandDAL bDAL = new brandDAL();
        int bval = bDAL.delete_brands(bBAL);
        if (bval == 1)
        {
            Response.Write("<script>alert('brand deleted successfully...')</script>");
        }
        fillgrid();
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
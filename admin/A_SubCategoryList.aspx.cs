using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class admin_A_SubCategoryList : System.Web.UI.Page
{
    void fillgrid()
    {
        subcategoryDAL sDAL = new subcategoryDAL();
        DataSet ds = sDAL.show_subcategory_details();
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        fillgrid();       
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int sub_id = Convert.ToInt32(e.CommandArgument);
        subcategoryBAL sBAL = new subcategoryBAL();
        sBAL.subcat_id = sub_id;
        subcategoryDAL sDAL = new subcategoryDAL();
        int sval = sDAL.delete_subcategory_details(sBAL);
        if (sval == 1)
        {
            Response.Write("<script>alert('SubCategory is a Deleted...')</script>");
        }
        fillgrid();
    }
}
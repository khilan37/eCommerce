using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class admin_A_CategoryList : System.Web.UI.Page
{
    void fillgrid()
    {
        categoryDAL cDAL = new categoryDAL();
        DataSet ds = cDAL.show_category_details();
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        fillgrid();
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int sid = Convert.ToInt32(e.CommandArgument);
        categoryBAL cBAL = new categoryBAL();
         cBAL.cat_id = sid;
        categoryDAL cDAL = new categoryDAL();
        int cval = cDAL.delete_cateogry_details(cBAL);
        if (cval == 1)
        {
            Response.Write("<script>alert('category deleted successfully....')</script>");
        }
        fillgrid();
    }
}
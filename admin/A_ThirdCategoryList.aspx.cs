using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_A_ThirdCategoryList : System.Web.UI.Page
{
    void fillgrid()
    {
        thirdcategoryDAL cDAL = new thirdcategoryDAL();
        DataSet ds = cDAL.show_thirdcategory_details();
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        fillgrid();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int third_id = Convert.ToInt32(e.CommandArgument);
        thirdcategoryBAL cBAL = new thirdcategoryBAL();
        cBAL.tc_id = third_id;
        thirdcategoryDAL cDAL = new thirdcategoryDAL();
        int tval = cDAL.delete_thirdcategory_details(cBAL);
        if (tval == 1)
        {
            Response.Write("<script>alert('ThirdCategory is a Deleted...')</script>");
        }
        fillgrid();
    }
}
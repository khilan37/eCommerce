using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

public partial class admin_A_ProductList : System.Web.UI.Page
{
    void show()
    {
        productDAL pDAL = new productDAL();
        DataSet ds = pDAL.show_product_details();
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }
   
    protected void Page_Load(object sender, EventArgs e)
    {
        show();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int pid = Convert.ToInt32(e.CommandArgument);
        productBAL pBAL = new productBAL();
        pBAL.product_id = pid;
        productDAL pDAL = new productDAL();
        int pval = pDAL.delete_product(pBAL);
        if (pval == 1)
        {
            Response.Write("<script>alert('product is Deleted...')</script>");
        }
        show();
    }
}
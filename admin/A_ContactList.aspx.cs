using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_A_ContactList : System.Web.UI.Page
{
    void contact()
    {
        contactDAL cDAL = new contactDAL();
        DataSet ds = cDAL.show_contact_details();
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        contact();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int id = Convert.ToInt32(e.CommandArgument);
        contactBAL cBAL = new contactBAL();
        cBAL.id = id;
        contactDAL cDAL = new contactDAL();
        int cval = cDAL.delete_contact_details(cBAL);
        if (cval == 1)
        {
            Response.Write("<script>alert('message deleted successfully....')</script>");
        }
        contact();
    }
}
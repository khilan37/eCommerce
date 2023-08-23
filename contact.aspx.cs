using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class contact : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        contactBAL cBAL = new contactBAL();
        cBAL.name = TextBox1.Text;
        cBAL.email = TextBox2.Text;
        cBAL.message = TextBox3.Text;
        contactDAL cDAL = new contactDAL();
        int cval = cDAL.insert_contact_details(cBAL);
        if (cval == 1)
        {
            Response.Write("<script>alert('message successfully sented...')</script>");
        }
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
    }
}
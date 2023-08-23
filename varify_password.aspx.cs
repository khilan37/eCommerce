using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

public partial class varify_password : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        registrationBAL rBAL = new registrationBAL();
        rBAL.name = Session["name"].ToString();
        rBAL.vcode = TextBox1.Text + TextBox2.Text + TextBox3.Text + TextBox4.Text;
        rBAL.status = "Active";
        registrationDAL rDAL = new registrationDAL();
        DataSet ds = rDAL.verify_details_registration(rBAL);
        if (ds.Tables[0].Rows.Count > 0)
        {
            registrationDAL rDAL1 = new registrationDAL();
            int rval = rDAL1.update_status_registration(rBAL);
            if (rval == 1)
            {
                Response.Redirect("login.aspx");
            }
        }
        else
        {
            Response.Write("<script>alert('your opt is wrong please properly check it out...')</script>");
        }

    }
}
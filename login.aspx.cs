using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        registrationBAL rBAL = new registrationBAL();
        rBAL.name = TextBox1.Text;
        rBAL.password = TextBox2.Text;
        rBAL.status = "Deactive";
        registrationDAL rDAL = new registrationDAL();
        DataSet ds = rDAL.check_login_registration(rBAL);
        if (ds.Tables[0].Rows.Count > 0)
        {
            string st = ds.Tables[0].Rows[0]["status"].ToString();
            if (st == "Active")
            {
                Session["username"] = ds.Tables[0].Rows[0]["name"].ToString();
                Session["rid"] = ds.Tables[0].Rows[0]["regid"].ToString();
                Response.Redirect("home.aspx");
            }
            else if(st == "Deactive")
            {
                registrationDAL rDAL1 = new registrationDAL();
                int rval = rDAL1.delete_deactive_registration(rBAL);
                if (rval == 1)
                {
                    Response.Write("<script>alert('your username and password is invalid please go to first registration')</script>");
                }
            }
        }
        else
        {
            Response.Write("<script>alert('your username or password wrong please check it out..')</script>");
        }
    }
}
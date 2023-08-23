using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class registration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        registrationBAL rBAL1 = new registrationBAL();
        rBAL1.name = TextBox1.Text;
        rBAL1.email = TextBox2.Text;
        rBAL1.status = "Deactive";
        rBAL1.password = TextBox3.Text;
        registrationDAL rDAL1 = new registrationDAL();
        DataSet ds = rDAL1.check_name_and_email_registration(rBAL1);
        if (ds.Tables[0].Rows.Count > 0)
        {
            Response.Write("<script>alert('this email id or username already exist')</script>");
        }
        else
        {
            Random r = new Random();
            string otp = r.Next(1000, 9999).ToString();
            rBAL1.rtd = System.DateTime.Now.ToString();
            rBAL1.vcode = otp;
            registrationDAL rDAL = new registrationDAL();
            int rval = rDAL.insert_registration_details(rBAL1);
            if (rval == 1)
            {
                string message = "Thank You For Registration " + TextBox1.Text + "  <br> Your Username = : " + TextBox1.Text + "<br> Your Password = " + TextBox3.Text + "<br>Your Verification Code = " + otp + " <br> Good Luck.....";
                if (gmailsender.SendMail("eshoppingmart23@gmail.com", "mart@123", TextBox2.Text, "Welcome to yourmart", message))
                {
                    Response.Write("<script>alert('Thank you for Registration your Verification code and account details have been sent on your email account');window.location.href='varify_password.aspx';</script>");
                }
                else
                {
                    Response.Write("<script>alert('Sorry, Message Sending Failed... ')</script>");
                }
            }
        }
        Session["name"] = TextBox1.Text;
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";

    }


    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {
        registrationBAL rBAL = new registrationBAL();
        rBAL.name = TextBox1.Text;
        rBAL.email = TextBox2.Text;
        registrationDAL rDAL = new registrationDAL();
        DataSet ds = rDAL.check_name_and_email_registration(rBAL);
        if (ds.Tables[0].Rows.Count > 0)
        {
            Response.Write("<script>alert('this email id already exist')</script>");
        }
        else
        {
            Response.Write("<script>alert('you can use this email id')</script>");
        }
    }

    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        registrationBAL rBAL = new registrationBAL();
        rBAL.name = TextBox1.Text;
        rBAL.email = TextBox2.Text;
        registrationDAL rDAL = new registrationDAL();
        DataSet ds = rDAL.check_name_and_email_registration(rBAL);
        if (ds.Tables[0].Rows.Count > 0)
        {
            Response.Write("<script>alert('this username already exist')</script>");
        }
        else
        {
            Response.Write("<script>alert('you can use this username')</script>");
        }
    }
}
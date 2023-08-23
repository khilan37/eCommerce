using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

public partial class shippingaddress : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["rid"] != null)
            {
                if (Request.QueryString["shipping_id"] != null)
                {
                    shippingaddressBAL sBAL1 = new shippingaddressBAL();
                    Session["shipping"] = Request.QueryString["shipping_id"];
                    sBAL1.shipping_id = Convert.ToInt32(Session["shipping"]);
                    shippingaddressDAL sDAL1 = new shippingaddressDAL();
                    DataSet ds1 = sDAL1.show_pervious_address(sBAL1);
                    div1.Visible = true;
                    div2.Visible = false;
                    div1.Attributes["class"] = div2.Attributes["class"].Replace("col-6", "col-12");
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        TextBox1.Text = ds1.Tables[0].Rows[0]["full_name"].ToString();
                        TextBox2.Text = ds1.Tables[0].Rows[0]["city"].ToString();
                        TextBox3.Text = ds1.Tables[0].Rows[0]["state"].ToString();
                        TextBox4.Text = ds1.Tables[0].Rows[0]["pincode"].ToString();
                        TextBox5.Text = ds1.Tables[0].Rows[0]["mobile_number"].ToString();
                        TextBox6.Text = ds1.Tables[0].Rows[0]["address"].ToString();

                    }
                }
                else
                {
                    shippingaddressBAL sBAL = new shippingaddressBAL();
                    sBAL.user_id = Session["rid"].ToString();
                    shippingaddressDAL sDAL = new shippingaddressDAL();
                    DataSet ds = sDAL.show_shipping_address(sBAL);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        div1.Visible = false;
                        div2.Visible = true;
                        div2.Attributes["class"] = div2.Attributes["class"].Replace("col-6", "col-12");
                        Repeater1.DataSource = ds;
                        Repeater1.DataBind();
                    }
                    else
                    {
                        div1.Visible = true;
                        div2.Visible = false;
                        div1.Attributes["class"] = div1.Attributes["class"].Replace("col-6", "col-12");
                        //div1.Style["margin-left"] = "270px";
                        //div.Style["text-align"] = "center";
                    }
                }   
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
        //div1.Visible = false;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if(Session["rid"] != null)
        {
            shippingaddressBAL sBAL = new shippingaddressBAL();
            sBAL.shipping_id = Convert.ToInt32(Session["shipping"]);
            sBAL.user_id = Session["rid"].ToString();
            sBAL.full_name = TextBox1.Text;
            sBAL.city = TextBox2.Text;
            sBAL.state = TextBox3.Text;
            sBAL.pincode = TextBox4.Text;
            sBAL.address = TextBox6.Text;
            sBAL.mobile_no = TextBox5.Text;
            shippingaddressDAL sDAL = new shippingaddressDAL();
                if (Session["shipping"] != null)
                {
                    int uval = sDAL.update_shipping_address(sBAL);
                    if (uval == 1)
                    {
                        Session.Remove("shipping");
                        Response.Redirect("shippingaddress.aspx");
                    }
                }
                else
                {
                    int sval = sDAL.insert_shipping_address(sBAL);
                    if (sval == 1)
                    {
                        Response.Write("<script>alert('success')</script>");
                    }
                    Response.Redirect("shippingaddress.aspx");
                }
        }
    }
    protected void delete_btn(object sender, CommandEventArgs e)
    {
        string delete = e.CommandArgument.ToString();
        shippingaddressBAL sBAL = new shippingaddressBAL();
        sBAL.shipping_id = Convert.ToInt32(delete);
        shippingaddressDAL sDAL = new shippingaddressDAL();
        int sval = sDAL.delete_shipping_address(sBAL);
        if (sval == 1)
        {
            Response.Redirect("shippingaddress.aspx");
        }
    }
    protected void add_btn(object sender, EventArgs e)
    {
        div1.Visible = true;
        div2.Attributes["class"] = div2.Attributes["class"].Replace("col-12", "col-6");
    }
    protected void edit_btn(object sender, CommandEventArgs e)
    {
        div1.Visible = true;
        div2.Visible = true;
        div2.Attributes["class"] = div2.Attributes["class"].Replace("col-12", "col-6");
        Session["shipping"] = e.CommandArgument.ToString();
        shippingaddressBAL sBAL = new shippingaddressBAL();
        sBAL.shipping_id = Convert.ToInt32(Session["shipping"]);
        shippingaddressDAL sDAL = new shippingaddressDAL();
        DataSet ds = sDAL.show_pervious_address(sBAL);
        if (ds.Tables[0].Rows.Count > 0)
        {
                TextBox1.Text = ds.Tables[0].Rows[0]["full_name"].ToString();
                TextBox2.Text = ds.Tables[0].Rows[0]["city"].ToString();
                TextBox3.Text = ds.Tables[0].Rows[0]["state"].ToString();
                TextBox4.Text = ds.Tables[0].Rows[0]["pincode"].ToString();
                TextBox5.Text = ds.Tables[0].Rows[0]["mobile_number"].ToString();
                TextBox6.Text = ds.Tables[0].Rows[0]["address"].ToString();
        }
    }
}

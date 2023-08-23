using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

public partial class order_summary : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["rid"] != null)
            {
                if (Request.QueryString["shipping_id"] != null)
                {

                    //-----------------------------------

                    registrationBAL rBAL = new registrationBAL();
                    rBAL.regid = Convert.ToInt32(Session["rid"]);
                    registrationDAL rDAL = new registrationDAL();
                    DataSet ds = rDAL.show_name(rBAL);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Label2.Text = ds.Tables[0].Rows[0]["name"].ToString();
                    }

                    //-----------------------------------

                    shippingaddressBAL sBAL = new shippingaddressBAL();
                    sBAL.shipping_id = Convert.ToInt32(Request.QueryString["shipping_id"]);
                    shippingaddressDAL sDAL = new shippingaddressDAL();
                    DataSet ds1 = sDAL.show_pervious_address(sBAL);
                    Repeater2.DataSource = ds1;
                    Repeater2.DataBind();

                    //-----------------------------------

                    cartBAL cBAL = new cartBAL();
                    cBAL.uid = Session["rid"].ToString();
                    cartDAL cDAL = new cartDAL();
                    DataSet ds2 = cDAL.show_cart_product(cBAL);
                    Repeater1.DataSource = ds2;
                    Repeater1.DataBind();

                }
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }
    }

    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        Response.Redirect("shippingaddress.aspx");
    }
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if(e.CommandName == "delete")
        {
            string sid = e.CommandArgument.ToString();
            cartBAL cBAL = new cartBAL();
            cBAL.product_id = sid;
            cBAL.uid = Session["rid"].ToString();
            cartDAL cDAL = new cartDAL();
            int cval = cDAL.delete_product_cart(cBAL);
            if (cval == 1)
            {
                Response.Redirect(Request.RawUrl);
            }
        }
        else if(e.CommandName == "update")
        {
            TextBox t = (TextBox)e.Item.FindControl("Textbox1");
            string cid = e.CommandArgument.ToString();
            cartBAL cBAL = new cartBAL();
            cBAL.cart_id = Convert.ToInt32(cid);
            cBAL.quantity = Convert.ToInt32(t.Text);
            cartDAL cDAL = new cartDAL();
            int qt = cDAL.update_quantity(cBAL);
            if (qt == 1)
            {
                Response.Redirect(Request.RawUrl);
            }
        }
    }
}
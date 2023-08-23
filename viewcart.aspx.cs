using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class viewcart : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if(Session["rid"] != null)
            {
                cartBAL cBAL = new cartBAL();
                cBAL.uid = Session["rid"].ToString();
                cartDAL cDAL = new cartDAL();
                DataSet ds = cDAL.show_cart_product(cBAL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    inCart.Visible = true;
                    notinCart.Visible = false;
                    Repeater1.DataSource = ds;
                    Repeater1.DataBind();
                }
                else
                {
                    inCart.Visible = false;
                    notinCart.Visible = true;
                    Label12.Visible = false;
                    LinkButton5.Visible = false;
                    Label11.Text = "Your cart is empty! Add item to it now.";
                }
            }
            else
            {
                if (Request.Cookies["uid"] != null)
                {   
                    tempcartBAL tcBAL = new tempcartBAL();
                    tcBAL.unique_id = Request.Cookies["uid"].Value.ToString();
                    tempcartDAL tcDAL = new tempcartDAL();
                    DataSet ds = tcDAL.show_tempcart_product(tcBAL);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        inCart.Visible = true;
                        notinCart.Visible = false;
                        Repeater1.DataSource = ds;
                        Repeater1.DataBind();
                    }
                    else
                    {
                        inCart.Visible = false;
                        notinCart.Visible = true;
                        Label12.Visible = true;
                        LinkButton5.Visible = true;
                        Label11.Text = "Missing the cart items? ";
                        Label12.Text = "Login to see the items you added previously";
                    }
                }
                else
                {
                    inCart.Visible = false;
                    notinCart.Visible = true;
                    Label12.Visible = true;
                    LinkButton5.Visible = true;
                    Label11.Text = "Missing the cart items? ";
                    Label12.Text = "Login to see the items you added previously";
                }
            }
        }
    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        Response.Redirect("productlist.aspx");
    }

    protected void LinkButton5_Click(object sender, EventArgs e)
    {
        Response.Redirect("login.aspx");
    }
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        TextBox t = (TextBox)e.Item.FindControl("TextBox1");
        if (e.CommandName == "Update" )
        {
            if(Session["rid"]!= null)
            {
                string cid = e.CommandArgument.ToString();
                cartBAL cBAL = new cartBAL();
                cBAL.cart_id = Convert.ToInt32(cid);
                cBAL.quantity = Convert.ToInt32(t.Text);
                cartDAL cDAL = new cartDAL();
                int qt = cDAL.update_quantity(cBAL);
                if (qt == 1)
                {
                    Response.Redirect("viewcart.aspx");
                }
            }
            else
            {
                if (Request.Cookies["uid"] != null)
                {
                    string cid = e.CommandArgument.ToString();
                    tempcartBAL tcBAL = new tempcartBAL();
                    tcBAL.cart_id = Convert.ToInt32(cid);
                    tcBAL.quantity = Convert.ToInt32(t.Text);
                    tempcartDAL tcDAL = new tempcartDAL();
                    int qt = tcDAL.update_quantity(tcBAL);
                    if (qt == 1)
                    {
                        Response.Redirect("viewcart.aspx");
                    }
                }
            }
            
        }
        else if(e.CommandName == "delete")
        {
            if (Session["rid"] != null)
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
            else
            {
                string sid = e.CommandArgument.ToString();
                tempcartBAL tcBAL = new tempcartBAL();
                tcBAL.product_id = sid;
                tempcartDAL tcDAL = new tempcartDAL();
                int cval = tcDAL.delete_product_tempcart(tcBAL);
                if (cval == 1)
                {
                    Response.Redirect(Request.RawUrl);
                }
            }
        }
    }

    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        Response.Redirect("shippingaddress.aspx");
    }
}

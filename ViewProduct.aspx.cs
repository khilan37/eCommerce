using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewProduct : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["product_id"] != null)
            {
                if (Session["rid"] != null)
                {
                    cartBAL cBAL = new cartBAL();
                    cBAL.product_id = Request.QueryString["product_id"].ToString();
                    cBAL.uid = Session["rid"].ToString();
                    cartDAL cDAL = new cartDAL();
                    DataSet ds1 = cDAL.already_cart_btn(cBAL);
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        gobtn.Visible = true;
                        addbtn.Visible = false;
                    }
                    else
                    {
                        gobtn.Visible = false;
                        addbtn.Visible = true;
                    }
                }
                else
                {
                    tempcartBAL tcBAL = new tempcartBAL();
                    tcBAL.product_id = Request.QueryString["product_id"].ToString();
                    tempcartDAL tcDAL = new tempcartDAL();
                    DataSet ds2 = tcDAL.already_tempcart(tcBAL);
                    if (ds2.Tables[0].Rows.Count > 0)
                    {
                        gobtn.Visible = true;
                        addbtn.Visible = false;
                    }
                    else
                    {
                        gobtn.Visible = false;
                        addbtn.Visible = true;
                    }
                }
                productBAL pBAL = new productBAL();
                pBAL.product_id = Convert.ToInt16(Request.QueryString["product_id"]);
                productDAL pDAL = new productDAL();
                DataSet ds = pDAL.show_previous_product_details(pBAL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Label1.Text = ds.Tables[0].Rows[0]["product_name"].ToString();
                    Label2.Text = ds.Tables[0].Rows[0]["product_description"].ToString();
                    Label3.Text = ds.Tables[0].Rows[0]["product_price"].ToString();
                    Image1.ImageUrl = ds.Tables[0].Rows[0]["product_image"].ToString();
                }
            }
            else
            {
                Response.Redirect("home.aspx");
            }
        }
    }

    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        if (Session["rid"] != null)
        {
            cartBAL cBAL = new cartBAL();
            cBAL.uid = Session["rid"].ToString(); 
            cBAL.product_id = Request.QueryString["product_id"];
            cBAL.quantity = Convert.ToInt32(TextBox1.Text);
            cBAL.cdate = System.DateTime.Now.ToString();
            cartDAL cDAL = new cartDAL();
            DataSet ds = cDAL.already_cart(cBAL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gobtn.Visible = true;
                addbtn.Visible = false; 
            }
            else
            {
                gobtn.Visible = false;
                addbtn.Visible = true;
                int cval = cDAL.cart_insert(cBAL);
                if (cval == 1)
                {
                    Response.Redirect(Request.RawUrl);    
                }
            }
        }
        else
        {
            Random r = new Random();
            string uid="";
            if (Request.Cookies["uid"] != null)
            {
                uid = Request.Cookies["uid"].Value.ToString();
            }
            else
            {
                uid = r.Next(100000, 999999).ToString();
                HttpCookie hc = new HttpCookie("uid", uid);
                hc.Expires = System.DateTime.Now.AddDays(2);
                Response.Cookies.Add(hc);

                //HttpCookie h1 = new HttpCookie("cart");
                //h1.Values.Add("uid", Request.Cookies["uid"].ToString());
                //h1.Expires = System.DateTime.Now.AddDays(2);
                //Response.Cookies.Add(h1);

            }
            tempcartBAL tcBAL = new tempcartBAL();
            tcBAL.unique_id = uid;
            tcBAL.product_id = Request.QueryString["product_id"].ToString();
            tcBAL.quantity = Convert.ToInt32(TextBox1.Text);
            tcBAL.cdate = System.DateTime.Now.ToString();
            tempcartDAL tcDAL = new tempcartDAL();
            DataSet ds = tcDAL.already_tempcart(tcBAL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gobtn.Visible = true;
                addbtn.Visible = false;
            }
            else
            {
                gobtn.Visible = true;
                addbtn.Visible = false;
                int cval = tcDAL.tempcart_insert(tcBAL);
                if (cval == 1)
                {
                    Response.Redirect(Request.RawUrl);
                }
            }
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("viewcart.aspx");
    }
}
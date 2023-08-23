using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

public partial class home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            subcategoryDAL sDAL = new subcategoryDAL();
            DataSet ds = sDAL.show_subcategory_details();
            Repeater1.DataSource = ds;
            Repeater1.DataBind();
            if (Session["rid"] != null)
            {
                string pid = "";
                string qt = "";
                if (Request.Cookies["uid"] != null)
                {
                    tempcartBAL tcBAL = new tempcartBAL();
                    tcBAL.unique_id = Request.Cookies["uid"].Value.ToString();
                    tempcartDAL tcDAL = new tempcartDAL();
                    DataSet ds2 = tcDAL.forward_tempcart(tcBAL);
                    if(ds2.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
                        { 
                            pid = ds2.Tables[0].Rows[i]["pid"].ToString();
                            qt = ds2.Tables[0].Rows[i]["quantity"].ToString();
                            cartBAL cBAL = new cartBAL();
                            cBAL.uid = Session["rid"].ToString();
                            cBAL.product_id = pid;
                            cBAL.quantity = Convert.ToInt32(qt);
                            cBAL.cdate = System.DateTime.Now.ToString();
                            cartDAL cDAL = new cartDAL();
                            DataSet ds1 = cDAL.already_cart(cBAL);
                            if (ds1.Tables[0].Rows.Count > 0)
                            {
                                Response.Cookies["uid"].Expires = DateTime.Now.AddDays(-1);
                            }
                            else
                            {
                                int cval = cDAL.cart_insert(cBAL);
                                if (cval == 1)
                                {
                                    Response.Cookies["uid"].Expires = DateTime.Now.AddDays(-1);
                                }
                            }
                        }
                    }
                }
                else
                {
                    Response.Cookies["uid"].Expires = DateTime.Now.AddDays(-1);
                }
            }
        }
    }
    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Repeater r = (Repeater)e.Item.FindControl("Repeater2");
        HiddenField h = (HiddenField)e.Item.FindControl("HiddenField1");
        productBAL pBAL = new productBAL();
        pBAL.sub_cat_id = Convert.ToInt32(h.Value);
        productDAL pDAL = new productDAL();
        DataSet ds = pDAL.show_subcat_4products(pBAL);
        r.DataSource = ds;
        r.DataBind();
    }
}
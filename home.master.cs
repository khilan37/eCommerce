using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["rid"] != null)
            {
                beforelogin.Visible = false;
                afterlogin.Visible = true;
            }
            else
            {
                beforelogin.Visible = true;
                afterlogin.Visible = false;
            }
            categoryDAL cDAL = new categoryDAL();
            DataSet ds = cDAL.show_category_details();
            Repeater1.DataSource = ds;
            Repeater1.DataBind();
        }
        
    
    }
    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Repeater r = (Repeater)e.Item.FindControl("Repeater2");
        HiddenField h = (HiddenField)e.Item.FindControl("HiddenField1");
        subcategoryBAL sBAL = new subcategoryBAL();
        sBAL.cat_id = h.Value;
        subcategoryDAL sDAL = new subcategoryDAL();
        DataSet ds = sDAL.show_subcategory_thidcategoryform(sBAL);
        r.DataSource = ds;
        r.DataBind();
    }
    protected void Repeater2_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Repeater r = (Repeater)e.Item.FindControl("Repeater3");
       
        HiddenField h1 = (HiddenField)e.Item.FindControl("HiddenField2");
        thirdcategoryBAL tBAL = new thirdcategoryBAL();
       
        tBAL.sub_cat_id = Convert.ToInt16(h1.Value);
        thirdcategoryDAL tDAL = new thirdcategoryDAL();
        DataSet ds = tDAL.show_thirdcatgory_name(tBAL);
        r.DataSource = ds;
        r.DataBind();
    }

    protected void beforelogin_Click(object sender, EventArgs e)
    {
        Response.Redirect("login.aspx");
    }
    protected void afterlogin_Click(object sender, EventArgs e)
    {
        afterlogin.Visible = false;
        beforelogin.Visible = true;
        Session.Remove("rid");
        Response.Redirect("home.aspx");

    }
    public static List<string> GetsProductNames(string pn)
    {
        productBAL pBAL = new productBAL();
        pBAL.product_name = pn;
        productDAL pDAL = new productDAL();
        DataSet ds = pDAL.search_products(pBAL);
        List<string> product = new List<string>();
        for (int i = 0; i< ds.Tables[0].Rows.Count; i++)
        {
            product.Add(ds.Tables[0].Rows[i]["product_name"].ToString());
        }
        return product;
    }
}


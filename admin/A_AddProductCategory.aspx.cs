using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_A_AddProductCategory : System.Web.UI.Page
{
    void cat()
    {
        categoryDAL cDAL = new categoryDAL();
        DataSet ds = cDAL.show_category_details();
        DropDownList1.DataSource = ds;
        DropDownList1.DataTextField = "category";
        DropDownList1.DataValueField = "cat_id";
        DropDownList1.DataBind();
        DropDownList1.Items.Insert(0,"--select category--");
    }
    void subcat()
    {
        subcategoryBAL sBAL = new subcategoryBAL();
        sBAL.cat_id = DropDownList1.SelectedValue;
        subcategoryDAL sDAL = new subcategoryDAL();
        DataSet ds = sDAL.show_subcategory_thidcategoryform(sBAL);
        DropDownList2.DataSource = ds;
        DropDownList2.DataTextField = "subcategory";
        DropDownList2.DataValueField = "sub_cat_id";
        DropDownList2.DataBind();
        DropDownList2.Items.Insert(0,"--select subcategory--");
    }
    void thirdcat()
    {
        thirdcategoryBAL tBAL = new thirdcategoryBAL();
        tBAL.sub_cat_id = Convert.ToInt32(DropDownList2.SelectedValue);
        thirdcategoryDAL tDAL = new thirdcategoryDAL();
        DataSet ds = tDAL.show_thirdcategory_productform(tBAL);
        DropDownList3.DataSource = ds;
        DropDownList3.DataTextField = "third_category";
        DropDownList3.DataValueField = "tc_id";
        DropDownList3.DataBind();
        DropDownList3.Items.Insert(0,"--select thirdcategory--");
    }
    void brand()
    {
        brandDAL bDAL = new brandDAL();
        DataSet ds = bDAL.show_brands();
        DropDownList4.DataSource = ds;
        DropDownList4.DataTextField = "brand_name";
        DropDownList4.DataValueField = "brand_id";
        DropDownList4.DataBind();
        DropDownList4.Items.Insert(0, "--select brands--");
        DropDownList4.Items[0].Value = "0";
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            cat();
            if (Request.QueryString["Edit"] != null)
            {
                productBAL pBAL = new productBAL();
                pBAL.product_id = Convert.ToInt16(Request.QueryString["Edit"]);
                productDAL pDAL = new productDAL();
                DataSet ds = pDAL.show_previous_product_details(pBAL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DropDownList1.SelectedValue = ds.Tables[0].Rows[0]["cat_id"].ToString();
                    string sid = ds.Tables[0].Rows[0]["sub_cat_id"].ToString();
                    subcat();
                    DropDownList2.SelectedValue = sid;
                    string tcid = ds.Tables[0].Rows[0]["tc_id"].ToString();
                    thirdcat();
                    DropDownList3.SelectedValue = tcid;
                    string bid = ds.Tables[0].Rows[0]["brand_id"].ToString();
                    TextBox1.Text = ds.Tables[0].Rows[0]["product_name"].ToString();
                    TextBox2.Text = ds.Tables[0].Rows[0]["product_price"].ToString();
                    TextBox3.Text = ds.Tables[0].Rows[0]["product_color"].ToString();
                    Image1.ImageUrl = ds.Tables[0].Rows[0]["product_image"].ToString();
                    TextBox4.Text = ds.Tables[0].Rows[0]["product_description"].ToString();
                    brand();
                    DropDownList4.SelectedValue = bid;
                }
            }
        }
    }



    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        subcat();
    }

    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        thirdcat();
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        productBAL pBAL = new productBAL();
        productDAL pDAL = new productDAL();
        pBAL.product_id = Convert.ToInt16(Request.QueryString["Edit"]);
        pBAL.cat_id = Convert.ToInt16(DropDownList1.SelectedValue.Trim().ToUpper());
        pBAL.sub_cat_id = Convert.ToInt16(DropDownList2.SelectedValue.Trim().ToUpper());
        pBAL.tc_id = Convert.ToInt16(DropDownList3.SelectedValue.Trim().ToUpper());
        pBAL.brand_id = Convert.ToInt16(DropDownList4.SelectedValue.Trim().ToUpper());
        pBAL.product_name = TextBox1.Text.Trim().ToUpper();
        pBAL.product_price = Convert.ToInt32(TextBox2.Text.Trim().ToUpper());
        pBAL.product_color = TextBox3.Text.Trim().ToUpper();
        pBAL.product_status = DropDownList5.SelectedValue;
        if (FileUpload1.HasFile)
        {
            FileUpload1.SaveAs(Server.MapPath("~/images/" + FileUpload1.FileName));
            pBAL.product_img = "~/images/" + FileUpload1.FileName.Trim().ToUpper();
        }
        pBAL.product_description = TextBox4.Text.Trim().ToUpper();
        if (Request.QueryString["Edit"] != null)
        {
            int pval = pDAL.update_product_details(pBAL);
            if (pval == 1)
            {
                Response.Write("<script>alert('product details updated...')</script>");
            }
        }
        else
        {
            DataSet ds = pDAL.show_already_message_product(pBAL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Response.Write("<script>alert('product name already exist')</script>");
            }
            else
            {
                int pval = pDAL.insert_product_details(pBAL);
                if (pval == 1)
                {
                    Response.Write("<script>alert('product has been added...')</script>");
                }
            }
        }
    }

    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        brand();
    }
}
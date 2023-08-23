using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class admin_A_AddThirdCategory : System.Web.UI.Page
{
    void show_subcat()
    {
        subcategoryBAL sBAL = new subcategoryBAL();
        sBAL.cat_id = DropDownList1.SelectedValue;
        subcategoryDAL sDAL = new subcategoryDAL();
        DataSet ds = sDAL.show_subcategory_thidcategoryform(sBAL);
        DropDownList2.DataSource = ds;
        DropDownList2.DataTextField = "subcategory";
        DropDownList2.DataValueField = "sub_cat_id";
        DropDownList2.DataBind();
        DropDownList2.Items.Insert(0, "--select subcategory--");
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            categoryDAL cDAL = new categoryDAL();
            DataSet ds = cDAL.show_category_details();
            DropDownList1.DataSource = ds;
            DropDownList1.DataTextField = "category";
            DropDownList1.DataValueField = "cat_id";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0,"--select category--");
            if(Request.QueryString["Edit"]!= null)
            {
                thirdcategoryBAL cBAL = new thirdcategoryBAL();
                cBAL.tc_id = Convert.ToInt32(Request.QueryString["Edit"]);
                thirdcategoryDAL cDAL1 = new thirdcategoryDAL();
                DataSet ds1 = cDAL1.show_previous_thirdcategory_details(cBAL);
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    DropDownList1.SelectedValue = ds1.Tables[0].Rows[0]["cat_id"].ToString();
                    string sid = ds1.Tables[0].Rows[0]["sub_cat_id"].ToString();
                    TextBox1.Text = ds1.Tables[0].Rows[0]["third_category"].ToString();
                    DropDownList3.SelectedValue = ds1.Tables[0].Rows[0]["status"].ToString();
                    show_subcat();
                    DropDownList2.SelectedValue = sid;
                }
            }

        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        thirdcategoryBAL cBAL = new thirdcategoryBAL();
        cBAL.cat_id = Convert.ToInt32(DropDownList1.SelectedValue.Trim().ToUpper());
        cBAL.tc_id = Convert.ToInt32(Request.QueryString["Edit"]);
        cBAL.sub_cat_id = Convert.ToInt32(DropDownList2.SelectedValue.Trim().ToUpper());
        cBAL.third_category = TextBox1.Text.Trim().ToUpper();
        cBAL.status = DropDownList3.SelectedValue.Trim().ToUpper();
        thirdcategoryDAL cDAL = new thirdcategoryDAL();
        if (Request.QueryString["Edit"] != null)
        {
            int tval = cDAL.update_thirdcategory_details(cBAL);
            if (tval == 1)
            {
                Response.Write("<script>alert('thridcategory updated successfully...')</script>");
            }
        }
        else
        {
            DataSet ds = cDAL.already_thirdbcategory_details(cBAL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Response.Write("<script>alert('This ThirdCategroy exist...')</script>");
            }
            else
            {
                int cval = cDAL.insert_thridcategry_details(cBAL);
                if (cval == 1)
                {
                    Response.Write("<script>alert('ThirdCategroy has been added...')</script>");
                }
            }
            
        }
           
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        show_subcat();
    }
}
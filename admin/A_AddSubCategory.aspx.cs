using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class admin_A_AddSubCategory : System.Web.UI.Page
{
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
            DropDownList1.Items.Insert(0, "--select Category--");
            if(Request.QueryString["Edit"]!= null)
            {
                subcategoryBAL sBAL = new subcategoryBAL();
                sBAL.subcat_id = Convert.ToInt32(Request.QueryString["Edit"]);
                subcategoryDAL sDAL = new subcategoryDAL();
                DataSet ds1 = sDAL.show_previous_subcategory_details(sBAL);
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    DropDownList1.SelectedValue = ds1.Tables[0].Rows[0]["cat_id"].ToString();
                    TextBox1.Text = ds1.Tables[0].Rows[0]["subcategory"].ToString();
                    DropDownList2.SelectedValue = ds1.Tables[0].Rows[0]["status"].ToString();
                }
            }
        }   
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        subcategoryBAL sBAL = new subcategoryBAL();
        sBAL.cat_id = DropDownList1.SelectedValue.Trim().ToUpper();
        sBAL.subcat_id = Convert.ToInt32(Request.QueryString["Edit"]);
        sBAL.subcategory = TextBox1.Text.Trim().ToUpper();
        sBAL.status = DropDownList2.Text.Trim().ToUpper();
        if (Request.QueryString["Edit"]!= null)
        {
            subcategoryDAL sDAL1 = new subcategoryDAL();
            int sval1 = sDAL1.update_subcategory_details(sBAL);
            if (sval1 == 1)
            {
                Response.Write("<script>alert('subcategory updated sucessfully...')</script>");
            }
        }
        else
        {
            subcategoryDAL sDAL1 = new subcategoryDAL();
            DataSet ds = sDAL1.already_subcategory_details(sBAL);
            if(ds.Tables[0].Rows.Count > 0)
            {
                Response.Write("<script>alert('this subcategory already exist...')</script>");
            }
            else
            {
                subcategoryDAL sDAL = new subcategoryDAL();
                int sval = sDAL.insert_subcateogry_details(sBAL);
                if (sval == 1)
                {
                    Response.Write("<script>alert('subcategory has been added')</script>");
                }
            }
        }
    }
}
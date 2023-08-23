using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class A_AddCategory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        TextBox1.Focus();
        if (!IsPostBack)
        {
            if (Request.QueryString["Edit"] != null)
            {
                categoryBAL cBAL = new categoryBAL();
                cBAL.cat_id = Convert.ToInt32(Request.QueryString["Edit"]);
                categoryDAL cDAL = new categoryDAL();
                DataSet ds = cDAL.show_previous_category_details(cBAL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    TextBox1.Text = ds.Tables[0].Rows[0]["category"].ToString();
                    DropDownList1.SelectedValue = ds.Tables[0].Rows[0]["status"].ToString();
                }
            }
        }
        
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        categoryBAL cBAL = new categoryBAL();
        cBAL.cat_id = Convert.ToInt32(Request.QueryString["Edit"]);
        cBAL.category = TextBox1.Text.Trim().ToUpper();
        cBAL.status = DropDownList1.Text.Trim().ToUpper();
        if (Request.QueryString["Edit"] != null)
        {
            categoryDAL cDAL1 = new categoryDAL();
            int cval1 = cDAL1.update_category_details(cBAL);
            if (cval1 == 1)
            {
                Response.Write("<script>alert('details updated successfully...'); window.location.href='A_CategoryList.aspx';</script>");
            }
        }
        else
        {
            categoryDAL cDAL2 = new categoryDAL();
            DataSet ds = cDAL2.already_category_details(cBAL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Response.Write("<script>alert('this category already exist..')</script>");
            }
            else
            {
                categoryDAL cDAL = new categoryDAL();
                int cval = cDAL.insert_cateogry_details(cBAL);
                if (cval == 1)
                {
                    Response.Write("<script>alert('category has been added')</script>");
                    TextBox1.Text = "";
                }
                else
                {
                    Response.Write("<script>alert('category is not added')</script>");
                }
            }
        }
    }
}
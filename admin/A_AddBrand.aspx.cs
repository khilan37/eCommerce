using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_A_AddBrandList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["Edit"] != null)
            {
                brandBAL bBAL = new brandBAL();
                bBAL.brand_id = Convert.ToInt16(Request.QueryString["Edit"]);
                brandDAL bDAL = new brandDAL();
                DataSet ds = bDAL.show_previos_brands(bBAL);
                if(ds.Tables[0].Rows.Count > 0)
                {
                    TextBox1.Text = ds.Tables[0].Rows[0]["brand_name"].ToString();
                    DropDownList1.SelectedValue = ds.Tables[0].Rows[0]["status"].ToString();
                }
            }
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        brandBAL bBAL = new brandBAL();
        bBAL.brand_id = Convert.ToInt16(Request.QueryString["Edit"]);
        bBAL.brand_name = TextBox1.Text.Trim().ToUpper();
        bBAL.status = DropDownList1.SelectedValue.Trim().ToUpper();
        brandDAL bDAL = new brandDAL();
        if (Request.QueryString["Edit"] != null)
        {
            int bval = bDAL.update_brands(bBAL);
            if (bval == 1)
            {
                Response.Write("<script>alert('brand updated successfully...')</script>");
            }
        }
        else
        {
            DataSet ds = bDAL.show_already_brands(bBAL);
            if(ds.Tables[0].Rows.Count>0)
            {
                Response.Write("<script>alert('brand is already exist...')</script>");
            }
            else
            {
                int bval1 = bDAL.insert_brand_details(bBAL);
                if (bval1 == 1)
                {
                    Response.Write("<script>alert('brand has been added...')</script>");
                }
            }
        }
    }
}
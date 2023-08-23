using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public class connection
{
    public SqlConnection con;
    public SqlCommand cmd;
    public SqlDataAdapter da;
    public DataSet ds;
    public DataTable dt;

    public void mycon()
    {
        con = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ToString());
        con.Open();
    }
}
public class registrationDAL : connection
{
    public int insert_registration_details(registrationBAL rBAL)
    {
        mycon();
        try
        {
            cmd = new SqlCommand("insert into registration values(@nm,@em,@pass,@vcode,@st,@rtd)",con);
            cmd.Parameters.AddWithValue("@nm",rBAL.name);
            cmd.Parameters.AddWithValue("@em", rBAL.email);
            cmd.Parameters.AddWithValue("@pass", rBAL.password);
            cmd.Parameters.AddWithValue("@st", rBAL.status);
            cmd.Parameters.AddWithValue("@vcode",rBAL.vcode);
            cmd.Parameters.AddWithValue("@rtd", rBAL.rtd);
            cmd.ExecuteNonQuery();
            con.Close();
            con.Dispose();
            return 1;
        }
        catch
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
    public DataSet check_name_and_email_registration(registrationBAL rBAL)
    {
        mycon();
        try
        {
            cmd = new SqlCommand("select * from registration where email = @em OR name = @name",con);
            cmd.Parameters.AddWithValue("em",rBAL.email);
            cmd.Parameters.AddWithValue("name",rBAL.name);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            con.Close();
            con.Dispose();
            return ds;
        }
        catch 
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
    public DataSet show_name(registrationBAL rBAL)
    {
        mycon();
        try
        {
            cmd = new SqlCommand("select * from registration where regid=@rid", con);
            cmd.Parameters.AddWithValue("rid", rBAL.regid);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            con.Close();
            con.Dispose();
            return ds;
        }
        catch
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
    public DataSet verify_details_registration(registrationBAL rBAL)
    {
        mycon();
        try
        {
            cmd = new SqlCommand("select * from registration where name=@nm AND vcode=@vc",con);
            cmd.Parameters.AddWithValue("nm",rBAL.name);
            cmd.Parameters.AddWithValue("vc",rBAL.vcode);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            con.Close();
            con.Dispose();
            return ds;
        }
        catch
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
    public int update_status_registration(registrationBAL rBAL)
    {
        mycon();
        try
        {
            cmd = new SqlCommand("update registration set status = @st where name = @nm",con);
            cmd.Parameters.AddWithValue("st",rBAL.status);
            cmd.Parameters.AddWithValue("nm", rBAL.name);
            cmd.ExecuteNonQuery();
            con.Close();
            con.Dispose();
            return 1;
        }
        catch
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
    public DataSet check_login_registration(registrationBAL rBAL)
    {
        mycon();
        try
        {
            cmd = new SqlCommand("select * from registration where name=@nm and password=@ps",con);
            cmd.Parameters.AddWithValue("nm",rBAL.name);
            cmd.Parameters.AddWithValue("ps",rBAL.password);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            con.Close();
            con.Dispose();
            return ds;
        }
        catch
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
    public int delete_deactive_registration(registrationBAL rBAL)
    {
        mycon();
        try
        {
            cmd = new SqlCommand("delete from registration where name = @nm and status = @st", con);
            cmd.Parameters.AddWithValue("nm",rBAL.name);
            cmd.Parameters.AddWithValue("st",rBAL.status);
            cmd.ExecuteNonQuery();
            con.Close();
            con.Dispose();
            return 1;
        }
        catch
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
}
public class categoryDAL : connection
{
    public int insert_cateogry_details(categoryBAL cBAL)
    {
        mycon();
        try
        {
            cmd = new SqlCommand("insert into category_master values(@ct,@st)",con);
            cmd.Parameters.AddWithValue("ct",cBAL.category);
            cmd.Parameters.AddWithValue("st",cBAL.status);
            cmd.ExecuteNonQuery();
            con.Close();
            con.Dispose();
            return 1;
        }
        catch
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
    public DataSet show_category_details()
    {
        mycon();
        try
        {
            cmd = new SqlCommand("select * from category_master",con);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            con.Close();
            con.Dispose();
            return ds;
        }
        catch
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
    public DataSet show_previous_category_details(categoryBAL cBAL)
    {
        mycon();
        try
        {
            cmd = new SqlCommand("select * from category_master where cat_id = @cid", con);
            cmd.Parameters.AddWithValue("cid",cBAL.cat_id);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            con.Close();
            con.Dispose();
            return ds;
        }
        catch
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
    public int update_category_details(categoryBAL cBAL)
    {
        mycon();
        try
        {
            cmd = new SqlCommand("update category_master Set category= @ct, status= @st where cat_id = @cid", con);
            cmd.Parameters.AddWithValue("ct",cBAL.category);
            cmd.Parameters.AddWithValue("st",cBAL.status);
            cmd.Parameters.AddWithValue("cid", cBAL.cat_id);
            cmd.ExecuteNonQuery();
            con.Close();
            con.Dispose();
            return 1;
        }
        catch
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
    public DataSet already_category_details(categoryBAL cBAL)
    {
        mycon();
        try
        {
            cmd = new SqlCommand("select * from category_master where category = @ct", con);
            cmd.Parameters.AddWithValue("ct", cBAL.category);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            con.Close();
            con.Dispose();
            return ds;
        }
        catch
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
    public int delete_cateogry_details(categoryBAL cBAL)
    {
        mycon();
        try
        {
            cmd = new SqlCommand("delete from category_master where cat_id = @ct",con);
            cmd.Parameters.AddWithValue("ct",cBAL.cat_id);
            cmd.ExecuteNonQuery();
            con.Close();
            con.Dispose();
            return 1;
        }
        catch
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
}
public class subcategoryDAL : connection
{
    public int insert_subcateogry_details(subcategoryBAL sBAL)
    {
        mycon();
        try
        {
            cmd = new SqlCommand("insert into subcategory_master values(@cid,@sc,@st)", con);
            cmd.Parameters.AddWithValue("cid",sBAL.cat_id);
            cmd.Parameters.AddWithValue("sc", sBAL.subcategory);
            cmd.Parameters.AddWithValue("st", sBAL.status);
            cmd.ExecuteNonQuery();
            con.Close();
            con.Dispose();
            return 1;
        }
        catch
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
    public DataSet show_subcategory_details()
    {
        mycon();
        try
        {
            cmd = new SqlCommand("select sm.*,cm.category from subcategory_master as sm Inner Join category_master as cm On sm.cat_id = cm.cat_id Order By sub_cat_id DESC ",con);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            con.Close();
            con.Dispose();
            return ds;
        }
        catch
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
    public int delete_subcategory_details(subcategoryBAL sBAL)
    {
        mycon();
        try
        {
            cmd = new SqlCommand("delete from subcategory_master where sub_cat_id = @scid ",con);
            cmd.Parameters.AddWithValue("scid",sBAL.subcat_id);
            cmd.ExecuteNonQuery();
            con.Close();
            con.Dispose();
            return 1;
        }
        catch
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
    public DataSet show_previous_subcategory_details(subcategoryBAL sBAL)
    {
        mycon();
        try
        {
            cmd = new SqlCommand("select * from subcategory_master where sub_cat_id = @scid", con);
            cmd.Parameters.AddWithValue("scid", sBAL.subcat_id);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            con.Close();
            con.Dispose();
            return ds;
        }
        catch
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
    public int update_subcategory_details(subcategoryBAL sBAL)
    {
        mycon();
        try
        {
            cmd = new SqlCommand("update subcategory_master Set subcategory= @sct, status= @st,cat_id = @cid where sub_cat_id = @scid", con);
            cmd.Parameters.AddWithValue("sct", sBAL.subcategory);
            cmd.Parameters.AddWithValue("st", sBAL.status);
            cmd.Parameters.AddWithValue("cid", sBAL.cat_id);
            cmd.Parameters.AddWithValue("scid", sBAL.subcat_id);
            cmd.ExecuteNonQuery();
            con.Close();
            con.Dispose();
            return 1;
        }
        catch
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
    public DataSet already_subcategory_details(subcategoryBAL sBAL)
    {
        mycon();
        try
        {
            cmd = new SqlCommand("select * from subcategory_master where subcategory = @sct", con);
            cmd.Parameters.AddWithValue("sct", sBAL.subcategory);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            con.Close();
            con.Dispose();
            return ds;
        }
        catch
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
    public DataSet show_subcategory_thidcategoryform(subcategoryBAL sBAL)
    {
        mycon();
        try
        {
            cmd = new SqlCommand("select * from subcategory_master where cat_id = @cid",con);
            cmd.Parameters.AddWithValue("cid",sBAL.cat_id);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            con.Close();
            con.Dispose();
            return ds;
        }
        catch
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
    
}
public class thirdcategoryDAL : connection
{
    public DataSet show_thirdcatgory_name(thirdcategoryBAL tBAL)
    {
        mycon();
        try
        {
            cmd = new SqlCommand("select * from thirdcategory_master where sub_cat_id = @scid", con);
            cmd.Parameters.AddWithValue("scid",tBAL.sub_cat_id);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            con.Close();
            con.Dispose();
            return ds;
        }
        catch
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
    public int insert_thridcategry_details(thirdcategoryBAL tBAL)
    {
        mycon();
        try
        {
            cmd = new SqlCommand("insert into thirdcategory_master values(@cat_id,@sub_cat_id,@third_category,@status)",con);
            cmd.Parameters.AddWithValue("cat_id", tBAL.cat_id);
            cmd.Parameters.AddWithValue("sub_cat_id", tBAL.sub_cat_id);
            cmd.Parameters.AddWithValue("third_category", tBAL.third_category);
            cmd.Parameters.AddWithValue("status", tBAL.status);
            cmd.ExecuteNonQuery();
            con.Close();
            con.Dispose();
            return 1;
        }
        catch
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
    public DataSet show_thirdcategory_details()
    {
        mycon();
        try
        {
            cmd = new SqlCommand("select tcm.*,scm.subcategory,cm.category from thirdcategory_master as tcm Inner Join subcategory_master as scm On tcm.sub_cat_id = scm.sub_cat_id and tcm.cat_id = scm.cat_id Inner Join category_master as cm On tcm.cat_id = cm.cat_id Order By tc_id DESC ", con);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            con.Close();
            con.Dispose();
            return ds;
        }
        catch
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
    public DataSet show_previous_thirdcategory_details(thirdcategoryBAL cBAL)
    {
        mycon();
        try
        {
            cmd = new SqlCommand("select * from thirdcategory_master where tc_id = @tcid", con);
            cmd.Parameters.AddWithValue("tcid", cBAL.tc_id);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            con.Close();
            con.Dispose();
            return ds;
        }
        catch
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
    public int update_thirdcategory_details(thirdcategoryBAL cBAL)
    {
        mycon();
        try
        {
            cmd = new SqlCommand("update thirdcategory_master Set cat_id = @cid, sub_cat_id = @scid, third_category= @tc, status= @st where tc_id = @tcid", con);
            cmd.Parameters.AddWithValue("cid", cBAL.cat_id);
            cmd.Parameters.AddWithValue("scid", cBAL.sub_cat_id);
            cmd.Parameters.AddWithValue("tc", cBAL.third_category);
            cmd.Parameters.AddWithValue("st", cBAL.status);
            cmd.Parameters.AddWithValue("tcid", cBAL.tc_id);
            cmd.ExecuteNonQuery();
            con.Close();
            con.Dispose();
            return 1;
        }
        catch
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
    public DataSet already_thirdbcategory_details(thirdcategoryBAL cBAL)
    {
        mycon();
        try
        {
            cmd = new SqlCommand("select * from thirdcategory_master where third_category = @tc", con);
            cmd.Parameters.AddWithValue("tc", cBAL.third_category);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            con.Close();
            con.Dispose();
            return ds;
        }
        catch
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
    public int delete_thirdcategory_details(thirdcategoryBAL cBAL)
    {
        mycon();
        try
        {
            cmd = new SqlCommand("delete from thirdcategory_master where tc_id = @tcid ", con);
            cmd.Parameters.AddWithValue("tcid", cBAL.tc_id);
            cmd.ExecuteNonQuery();
            con.Close();
            con.Dispose();
            return 1;
        }
        catch
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
    public DataSet show_thirdcategory_productform(thirdcategoryBAL tBAL)
    {
        mycon();
        try
        {
            cmd = new SqlCommand("select * from thirdcategory_master where sub_cat_id = @scid", con);
            cmd.Parameters.AddWithValue("scid", tBAL.sub_cat_id);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            con.Close();
            con.Dispose();
            return ds;
        }
        catch
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
        
}
public class brandDAL : connection
{
    public int insert_brand_details(brandBAL bBAL)
    {
        mycon();
        try
        {
            cmd = new SqlCommand("insert into brand_master values(@brnm,@st)",con);
            cmd.Parameters.AddWithValue("brnm",bBAL.brand_name);
            cmd.Parameters.AddWithValue("st",bBAL.status);
            cmd.ExecuteNonQuery();
            con.Close();
            con.Dispose();
            return 1;
        }
        catch
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
    public DataSet show_brands()
    {
        mycon();
        try
        {
            cmd = new SqlCommand("select * from brand_master",con);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            con.Close();
            con.Dispose();
            return ds;
        }
        catch
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
    public DataSet show_previos_brands(brandBAL bBAL)
    {
        mycon();
        try
        {
            cmd = new SqlCommand("select * from brand_master where brand_id = @brid",con);
            cmd.Parameters.AddWithValue("brid",bBAL.brand_id);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            con.Close();
            con.Dispose();
            return ds;
        }
        catch
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
    public int update_brands(brandBAL bBAL)
    {
        mycon();
        try
        {
            cmd = new SqlCommand("update brand_master set brand_name = @brnm, status = @st where brand_id = @brid",con);
            cmd.Parameters.AddWithValue("brnm",bBAL.brand_name);
            cmd.Parameters.AddWithValue("st",bBAL.status);
            cmd.Parameters.AddWithValue("brid",bBAL.brand_id);
            cmd.ExecuteNonQuery();
            con.Close();
            con.Dispose();
            return 1;
        }
        catch
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
    public DataSet show_already_brands(brandBAL bBAL)
    {
        mycon();
        try
        {
            cmd = new SqlCommand("select * from brand_master where brand_name = @brnm",con);
            cmd.Parameters.AddWithValue("brnm",bBAL.brand_name);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            con.Close();
            con.Dispose();
            return ds;
        }
        catch
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
    public int delete_brands(brandBAL bBAL) 
    {
        mycon();
        try
        {
            cmd = new SqlCommand("delete from brand_master where brand_id = @brid",con);
            cmd.Parameters.AddWithValue("brid",bBAL.brand_id);
            cmd.ExecuteNonQuery();
            con.Close();
            con.Dispose();
            return 1;
        }
        catch
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
}
public class productDAL : connection
{
    public DataSet search_products(productBAL pBAL)
    {
        mycon();
        try
        {
            cmd = new SqlCommand("select * from product_master where" + "product_name like @pn + '%' ", con);
            cmd.Parameters.AddWithValue("pn", pBAL.tc_id);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            con.Close();
            con.Dispose();
            return ds;
        }
        catch
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
    public DataSet show_products(productBAL pBAL)
    {
        mycon();
        try
        {
            cmd = new SqlCommand("select * from product_master where tc_id = @tid",con);
            cmd.Parameters.AddWithValue("tid",pBAL.tc_id);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            con.Close();
            con.Dispose();
            return ds;
        }
        catch
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
    public DataSet show_subcat_products(productBAL pBAL)
    {
        mycon();
        try
        {
            cmd = new SqlCommand("select * from product_master where sub_cat_id = @scid", con);
            cmd.Parameters.AddWithValue("scid", pBAL.sub_cat_id);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            con.Close();
            con.Dispose();
            return ds;
        }
        catch
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
    public DataSet show_subcat_4products(productBAL pBAL)
    {
        mycon();
        try
        {
            cmd = new SqlCommand("select TOP(4)* from product_master where sub_cat_id = @scid", con);
            cmd.Parameters.AddWithValue("scid", pBAL.sub_cat_id);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            con.Close();
            con.Dispose();
            return ds;
        }
        catch
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
    public int insert_product_details(productBAL pBAL)
    {
        mycon();
        try
        {
            cmd = new SqlCommand("insert into product_master values(@ct,@sc,@tc,@bi,@pn,@pp,@pc,@pi,@pd,@ps)",con);
            cmd.Parameters.AddWithValue("ct",pBAL.cat_id);
            cmd.Parameters.AddWithValue("sc", pBAL.sub_cat_id);
            cmd.Parameters.AddWithValue("tc",pBAL.tc_id);
            cmd.Parameters.AddWithValue("bi",pBAL.brand_id);
            cmd.Parameters.AddWithValue("pn",pBAL.product_name);
            cmd.Parameters.AddWithValue("pp",pBAL.product_price);
            cmd.Parameters.AddWithValue("pc",pBAL.product_color);
            cmd.Parameters.AddWithValue("pi",pBAL.product_img);
            cmd.Parameters.AddWithValue("pd",pBAL.product_description);
            cmd.Parameters.AddWithValue("ps",pBAL.product_status);
            cmd.ExecuteNonQuery();
            con.Close();
            con.Dispose();
            return 1;
        }
        catch
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
    public DataSet show_product_details()
    {
        mycon();
        try
        {
            cmd = new SqlCommand("select pm.*,cm.category,scm.subcategory,tcm.third_category,bm.brand_name from product_master as pm Inner Join category_master as cm On pm.cat_id = cm.cat_id Inner Join subcategory_master as scm On scm.sub_cat_id = pm.sub_cat_id inner join thirdcategory_master as tcm On tcm.tc_id = pm.tc_id inner join brand_master as bm on bm.brand_id = pm.brand_id order by product_id DESC",con);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            con.Close();
            con.Dispose();
            return ds;
        }
        catch
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
    public DataSet show_previous_product_details(productBAL pBAL)
    {
        mycon();
        try
        {
            cmd = new SqlCommand("select * from product_master where product_id = @pid", con);
            cmd.Parameters.AddWithValue("pid", pBAL.product_id);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            con.Close();
            con.Dispose();
            return ds;
        }
        catch
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
    public int update_product_details(productBAL pBAL)
    {
        mycon();
        try
        {
            cmd = new SqlCommand("update product_master set cat_id = @cid, sub_cat_id = @scid, tc_id = @tid, brand_id = @brid, product_name= @pn, product_price=@pp, product_color= @pc, product_image=@pi, product_description=@pd, product_status=@ps where product_id = @pid",con);
            cmd.Parameters.AddWithValue("pid",pBAL.product_id);
            cmd.Parameters.AddWithValue("cid",pBAL.cat_id);
            cmd.Parameters.AddWithValue("scid",pBAL.sub_cat_id);
            cmd.Parameters.AddWithValue("tid",pBAL.tc_id);
            cmd.Parameters.AddWithValue("brid",pBAL.brand_id);
            cmd.Parameters.AddWithValue("pn",pBAL.product_name);
            cmd.Parameters.AddWithValue("pp",pBAL.product_price);
            cmd.Parameters.AddWithValue("pc",pBAL.product_color);
            cmd.Parameters.AddWithValue("pi",pBAL.product_img);
            cmd.Parameters.AddWithValue("pd",pBAL.product_description);
            cmd.Parameters.AddWithValue("ps",pBAL.product_status);
            cmd.ExecuteNonQuery();
            con.Close();
            con.Dispose();
            return 1;
        }
        catch
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
    public DataSet show_already_message_product(productBAL pBAL)
    {
        mycon();
        try
        {
            cmd = new SqlCommand("select * from product_master where product_name = @pn",con);
            cmd.Parameters.AddWithValue("pn",pBAL.product_name);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            con.Close();
            con.Dispose();
            return ds;
        }
        catch
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
    public int delete_product(productBAL pBAL)
    {
        mycon();
        try
        {
            cmd = new SqlCommand("delete from product_master where product_id = @pid",con);
            cmd.Parameters.AddWithValue("pid",pBAL.product_id);
            cmd.ExecuteNonQuery();
            con.Close();
            con.Dispose();
            return 1;
        }
        catch
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
}
public class contactDAL : connection
{
    public int insert_contact_details(contactBAL cBAL)
    {
        mycon();
        try
        {
            cmd = new SqlCommand("insert into contact_master values(@nm,@em,@ms)",con);
            cmd.Parameters.AddWithValue("nm",cBAL.name);
            cmd.Parameters.AddWithValue("em",cBAL.email);
            cmd.Parameters.AddWithValue("ms", cBAL.message);
            cmd.ExecuteNonQuery();
            con.Close();
            con.Dispose();
            return 1;
        }
        catch
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
    public DataSet show_contact_details()
    {
        mycon();
        try
        {
            cmd = new SqlCommand("select * from contact_master",con);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            con.Close();
            con.Dispose();
            return ds;
        }
        catch
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
    public int delete_contact_details(contactBAL cBAL)
    {
        mycon();
        try
        {
            cmd = new SqlCommand("delete from contact_master where id = @id",con);
            cmd.Parameters.AddWithValue("id",cBAL.id);
            cmd.ExecuteNonQuery();
            con.Close();
            con.Dispose();
            return 1;
        }
        catch
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
}
public class cartDAL : connection
{
    public int cart_insert(cartBAL cBAL)
    {
        mycon();
        try
        {
            cmd = new SqlCommand("insert into cart_master values(@uid,@pid,@qt,@cd) ",con);
            cmd.Parameters.AddWithValue("uid",cBAL.uid);
            cmd.Parameters.AddWithValue("pid",cBAL.product_id);
            cmd.Parameters.AddWithValue("qt",cBAL.quantity);
            cmd.Parameters.AddWithValue("cd",cBAL.cdate);
            cmd.ExecuteNonQuery();
            con.Close();
            con.Dispose();
            return 1;
        }
        catch
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
    public DataSet already_cart(cartBAL cBAL)
    {
        mycon();
        try
        {
            cmd = new SqlCommand("select * from cart_master where unique_id = @uid and product_id = @pid", con);
            cmd.Parameters.AddWithValue("pid",cBAL.product_id);
            cmd.Parameters.AddWithValue("uid", cBAL.uid);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            con.Close();
            con.Dispose();
            return ds;
        }
        catch
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
    public DataSet already_cart_btn(cartBAL cBAL)
    {
        mycon();
        try
        {
            cmd = new SqlCommand("select * from cart_master where  product_id = @pid and unique_id = @uid", con);
            cmd.Parameters.AddWithValue("pid", cBAL.product_id);
            cmd.Parameters.AddWithValue("uid", cBAL.uid);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            con.Close();
            con.Dispose();
            return ds;
        }
        catch
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
    public DataSet show_cart_product(cartBAL cBAL)
    {
        mycon();
        try
        {
            cmd = new SqlCommand("select cm.*,pm.product_id,pm.product_name,pm.product_price,pm.product_image from cart_master as cm Inner Join product_master as pm on cm.product_id = pm.product_id where unique_id = @uid ",con);
            cmd.Parameters.AddWithValue("uid",cBAL.uid);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            con.Close();
            con.Dispose();
            return ds;
        }
        catch
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
    public int delete_product_cart(cartBAL cBAL)
    {
        mycon();
        try
        {
            cmd = new SqlCommand("delete cart_master where product_id = @pid and unique_id = @uid",con);
            cmd.Parameters.AddWithValue("pid",cBAL.product_id);
            cmd.Parameters.AddWithValue("uid",cBAL.uid);
            cmd.ExecuteNonQuery();
            con.Close();
            con.Dispose();
            return 1;
        }
        catch
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
    public int update_quantity(cartBAL cBAL)
    {
        mycon();
        try
        {
            cmd = new SqlCommand("update cart_master set quantity = @qt where cart_id = @cid",con);
            cmd.Parameters.AddWithValue("qt",cBAL.quantity);
            cmd.Parameters.AddWithValue("cid",cBAL.cart_id);
            cmd.ExecuteNonQuery();
            con.Close();
            con.Dispose();
            return 1;
        }
        catch
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally{
            con.Close();
            con.Dispose();
        }
    }
}
public class tempcartDAL : connection
{
    public int tempcart_insert(tempcartBAL tcBAL)
    {
        mycon();
        try
        {
            cmd = new SqlCommand("insert into tempcart values(@pid,@qt,@cd,@uid) ", con);
            cmd.Parameters.AddWithValue("pid", tcBAL.product_id);
            cmd.Parameters.AddWithValue("qt", tcBAL.quantity);
            cmd.Parameters.AddWithValue("cd", tcBAL.cdate);
            cmd.Parameters.AddWithValue("uid", tcBAL.unique_id);
            cmd.ExecuteNonQuery();
            con.Close();
            con.Dispose();
            return 1;
        }
        catch
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
    public DataSet already_tempcart(tempcartBAL tcBAL)
    {
        mycon();
        try
        {
            cmd = new SqlCommand("select * from tempcart where pid = @pid", con);
            cmd.Parameters.AddWithValue("pid", tcBAL.product_id);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            con.Close();
            con.Dispose();
            return ds;
        }
        catch
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
    public DataSet forward_tempcart(tempcartBAL tcBAL)
    {
        mycon();
        try
        {
            cmd = new SqlCommand("select * from tempcart where unique_id = @uid ", con);
            cmd.Parameters.AddWithValue("uid", tcBAL.unique_id);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            con.Close();
            con.Dispose();
            return ds;
        }
        catch
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
    public DataSet show_tempcart_product(tempcartBAL tcBAL)
    {
        mycon();
        try
        {
            cmd = new SqlCommand("select cm.*,pm.product_id,pm.product_name,pm.product_price,pm.product_image from tempcart as cm Inner Join product_master as pm on cm.pid = pm.product_id where cm.unique_id = @uid", con);
            cmd.Parameters.AddWithValue("uid", tcBAL.unique_id);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            con.Close();
            con.Dispose();
            return ds;
        }
        catch
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
    public int delete_product_tempcart(tempcartBAL tcBAL)
    {
        mycon();
        try
        {
            cmd = new SqlCommand("delete tempcart where pid = @pid", con);
            cmd.Parameters.AddWithValue("pid", tcBAL.product_id);
            cmd.ExecuteNonQuery();
            con.Close();
            con.Dispose();
            return 1;
        }
        catch
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
    public int update_quantity(tempcartBAL tcBAL)
    {
        mycon();
        try
        {
            cmd = new SqlCommand("update tempcart set quantity = @qt where cart_id = @cid", con);
            cmd.Parameters.AddWithValue("qt", tcBAL.quantity);
            cmd.Parameters.AddWithValue("cid", tcBAL.cart_id);
            cmd.ExecuteNonQuery();
            con.Close();
            con.Dispose();
            return 1;
        }
        catch
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
}
public class shippingaddressDAL : connection
{
    public int insert_shipping_address(shippingaddressBAL sBAL)
    {
        mycon();
        try
        {
            cmd = new SqlCommand("insert into shipping_address_master values(@uid,@fm,@ct,@st,@pc,@ad,@mn)",con);
            cmd.Parameters.AddWithValue("uid", sBAL.user_id);
            cmd.Parameters.AddWithValue("fm", sBAL.full_name);
            cmd.Parameters.AddWithValue("ct", sBAL.city);
            cmd.Parameters.AddWithValue("st", sBAL.state);
            cmd.Parameters.AddWithValue("pc", sBAL.pincode);
            cmd.Parameters.AddWithValue("ad", sBAL.address);
            cmd.Parameters.AddWithValue("mn",sBAL.mobile_no);
            cmd.ExecuteNonQuery();
            con.Close();
            con.Dispose();
            return 1;
        }
        catch
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
    public DataSet show_shipping_address(shippingaddressBAL sBAL)
    {
        mycon();
        try
        {
            cmd = new SqlCommand("select * from shipping_address_master where user_id= @uid",con);
            cmd.Parameters.AddWithValue("uid",sBAL.user_id);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            con.Close();
            con.Dispose();
            return ds;

        }
        catch
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
    public int delete_shipping_address(shippingaddressBAL sBAL)
    {
        mycon();
        try
        {
            cmd = new SqlCommand("delete shipping_address_master where shipping_id = @sid",con);
            cmd.Parameters.AddWithValue("sid",sBAL.shipping_id);
            cmd.ExecuteNonQuery();
            con.Close();
            con.Dispose();
            return 1;
        }
        catch
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
    public int update_shipping_address(shippingaddressBAL sBAL)
    {
        mycon();
        try
        {
            cmd = new SqlCommand("update shipping_address_master set full_name=@fm, city=@ct, state=@st, pincode=@pc, address=@ad, mobile_number=@mn where shipping_id = @sid ", con);
            cmd.Parameters.AddWithValue("fm",sBAL.full_name);
            cmd.Parameters.AddWithValue("ct",sBAL.city);
            cmd.Parameters.AddWithValue("st",sBAL.state);
            cmd.Parameters.AddWithValue("pc",sBAL.pincode);
            cmd.Parameters.AddWithValue("ad",sBAL.address);
            cmd.Parameters.AddWithValue("mn",sBAL.mobile_no);
            cmd.Parameters.AddWithValue("sid",sBAL.shipping_id);
            cmd.ExecuteNonQuery();
            con.Close();
            con.Dispose();
            return 1;
        }
        catch
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
    public DataSet show_pervious_address(shippingaddressBAL sBAL)
    {
        mycon();
        try
        {
            cmd = new SqlCommand("select * from shipping_address_master where shipping_id = @sid",con);
            cmd.Parameters.AddWithValue("sid",sBAL.shipping_id);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            con.Close();
            con.Dispose();
            return ds;
        }
        catch
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
}
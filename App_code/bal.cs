using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class registrationBAL
{
    public int regid { get; set; }
    public string name { get; set; }
    public string  email { get; set;}
    public string password { get; set; }
    public string vcode { get; set; }
    public string status { get; set; }
    public string rtd { get; set; }
}
public class categoryBAL
{
    public int cat_id { get; set; }
    public string category { get; set; }
    public string status { get; set; }
}
public class subcategoryBAL
{
    public int subcat_id { get; set; }
    public string cat_id { get; set; }
    public string subcategory { get; set; }
    public string status { get; set; }
}
public class thirdcategoryBAL
{
    public int tc_id { get; set; }
    public int cat_id { get; set; }
    public int sub_cat_id { get; set; }
    public string third_category { get; set; }
    public string status { get; set; }
}
public class brandBAL
{
    public int brand_id { get; set; }
    public string brand_name { get; set; }
    public string status { get; set; }
}
public class productBAL
{
    public int product_id { get; set; }
    public int cat_id { get; set; }
    public int sub_cat_id { get; set; }
    public int tc_id { get; set; }
    public int brand_id{ get; set; }
    public string product_name { get; set; }
    public int product_price { get; set; }
    public string product_color { get; set; }
    public string product_img { get; set; }
    public string product_description { get; set; }
    public string product_status { get; set; }
}
public class contactBAL
{
    public int id { get; set; }
    public string name { get; set; }
    public string email { get; set; }
    public string message { get; set; }
}
public class cartBAL
{
    public int cart_id { get; set; }
    public string uid { get; set; }
    public string product_id { get; set; }
    public int quantity { get; set; }
    public string cdate { get; set; }
}
public class tempcartBAL
{
    public int cart_id { get; set; }
    public string product_id { get; set; }
    public int quantity { get; set; }
    public string cdate { get; set; }
    public string unique_id { get; set; }
}
public class shippingaddressBAL
{
    public int shipping_id { get; set; }
    public string user_id { get; set; }
    public string full_name { get; set; }
    public string city { get; set; }
    public string state { get; set; }
    public string pincode { get; set; }
    public string address { get; set; }
    public string mobile_no { get; set; }
}
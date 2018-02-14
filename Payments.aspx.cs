using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Payments : System.Web.UI.Page
{
    String connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
    string policyId = "";
    string userId = "";
    string amount = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        policyId = Request.QueryString["policyId"];
        userId = Session["userID"].ToString();
        amount = Request.QueryString["amount"];

        if (!IsPostBack)
        {
            if (Session["username"] != null && Session["role"].ToString() == "user")
            {
                
            }
            else
            {
                Response.Redirect("~/Error");
            }
        }
    }

    protected void pay_Click(object sender, EventArgs e)
    {
        MySqlConnection connection = new MySqlConnection(connectionString);
        MySqlCommand cmd;
        connection.Open();
        try
        {
            cmd = connection.CreateCommand();
            cmd.CommandText = "INSERT INTO requests(userId,policyId,policyPremium) VALUES(@userId,@policyId,@policyPremium)";
            cmd.Parameters.AddWithValue("@userId", userId);
            cmd.Parameters.AddWithValue("@policyId", policyId);
            cmd.Parameters.AddWithValue("@policyPremium", amount);
            cmd.ExecuteNonQuery();
        }
        catch (Exception)
        {
            Response.Redirect("~/Error");
        }
        finally
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
        ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('Payment Succcessfull');window.location='UserView.aspx';", true);
    }
}
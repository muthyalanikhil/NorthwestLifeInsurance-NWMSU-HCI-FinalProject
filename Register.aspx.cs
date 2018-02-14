using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.UI;
using NorthwestInsurance;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;

public partial class Register : Page
{
    string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void CreateUser_Click(object sender, EventArgs e)
    {
        string username = UserName.Text;
        string pass = Password.Text;
        string role = "user";
        
        MySqlConnection connection = new MySqlConnection(connectionString);
        MySqlCommand cmd;
        connection.Open();
        try
        {
            cmd = connection.CreateCommand();
            cmd.CommandText = "INSERT INTO users(userName,password,role,isBlocked) VALUES(@userName,@password,@role,0)";
            cmd.Parameters.AddWithValue("@userName", username);
            cmd.Parameters.AddWithValue("@password", pass);
            cmd.Parameters.AddWithValue("@role", role);
            cmd.ExecuteNonQuery();
        }
        catch (Exception)
        {
            Response.Redirect("~/Error");
        }
        finally {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
            ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('Registration successfull.');", true);
        }
        Response.Redirect("~/Login");
    }
}
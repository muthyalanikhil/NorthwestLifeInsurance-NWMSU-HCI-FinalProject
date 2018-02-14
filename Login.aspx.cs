using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Web.UI;

public partial class Login : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void LogIn(object sender, EventArgs e)
    {
        var username = UserName.Text;
        var password = Password.Text;
     
        var connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        MySqlConnection connection = new MySqlConnection(connectionString);
        try
        {
            connection.Open();
            MySqlCommand cmd = new MySqlCommand("select id,userName,role from users where userName=@user and password=@pass", connection);
            cmd.Parameters.AddWithValue("user", @username);
            cmd.Parameters.AddWithValue("pass", @password);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                var role = "user";
                foreach (DataRow row in dt.Rows)
                {
                    Session["userID"] = row.ItemArray[0].ToString();
                    role = row.ItemArray[2].ToString();
                    Session["username"] = row.ItemArray[1].ToString();
                    Session["role"] = row.ItemArray[2].ToString();
                }

                connection.Close();
                if (role == "agent")
                {
                    Response.Redirect("~/AdminView", false);
                }
                if (role == "user")
                {
                    Response.Redirect("~/UserView", false);
                }
            }
            else
            {
                connection.Close();
                ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Invalid Username and Password')</script>");
            }
        }
        catch (Exception ex)
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
    }
}
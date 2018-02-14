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

public partial class Settings : System.Web.UI.Page
{
    String connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadUserGV();
        }
    }

    private void LoadUserGV()
    {
        MySqlConnection connection = new MySqlConnection(connectionString);
        try
        {
            connection.Open();
            MySqlCommand cmd = new MySqlCommand("select * from users", connection);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            usersGV.DataSource = dt;
            usersGV.DataBind();

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

    protected void usersGV_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TableCell roleCell = e.Row.Cells[2];
            if (roleCell.Text == "agent")
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Button btnButton = (Button)e.Row.FindControl("userRole");
                    btnButton.Text = "Remove Agent";
                    btnButton.CssClass = "btn btn-success";
                }
            }
            else
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Button btnButton = (Button)e.Row.FindControl("userRole");
                    btnButton.Text = "Make Agent";
                    btnButton.CssClass = "btn btn-primary";
                }
            }

            TableCell statusCell = e.Row.Cells[3];
            if (statusCell.Text == "1")
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Button btnButton = (Button)e.Row.FindControl("blockUser");
                    btnButton.Text = "Unblock";
                    btnButton.CssClass = "btn btn-success";
                }
            }
            else
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Button btnButton = (Button)e.Row.FindControl("blockUser");
                    btnButton.Text = "Block";
                    btnButton.CssClass = "btn btn-danger";
                }
            }
        }
    }

    protected void blockUser_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        //Get the row that contains this button
        GridViewRow gvr = (GridViewRow)btn.NamingContainer;
        int rowIndex = gvr.RowIndex; // Get the current row
        string userId = usersGV.Rows[rowIndex].Cells[0].Text;
        string isBlocked = usersGV.Rows[rowIndex].Cells[3].Text;
        if (isBlocked == "1")
        {
            isBlocked = "0";
        }
        else
        {
            isBlocked = "1";
        }
        MySqlConnection connection = new MySqlConnection(connectionString);
        try
        {
            connection.Open();
            MySqlCommand cmd = new MySqlCommand("Update users set isBlocked=@isBlocked where id=@userId", connection);
            cmd.Parameters.AddWithValue("userId", userId);
            cmd.Parameters.AddWithValue("isBlocked", isBlocked);
            cmd.ExecuteNonQuery();

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
            if (isBlocked == "1")
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('User Blocked');", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('User Unblocked');", true);
            }
            LoadUserGV();
        }
    }

    protected void userRole_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        //Get the row that contains this button
        GridViewRow gvr = (GridViewRow)btn.NamingContainer;
        int rowIndex = gvr.RowIndex; // Get the current row
        string userId = usersGV.Rows[rowIndex].Cells[0].Text;
        string role = usersGV.Rows[rowIndex].Cells[2].Text;
        if (role == "agent")
        {
            role = "user";
        }
        else
        {
            role = "agent";
        }
        MySqlConnection connection = new MySqlConnection(connectionString);
        try
        {
            connection.Open();
            MySqlCommand cmd = new MySqlCommand("Update users set role=@role where id=@userId", connection);
            cmd.Parameters.AddWithValue("userId", userId);
            cmd.Parameters.AddWithValue("role", role);
            cmd.ExecuteNonQuery();

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
            ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('User role updated.');", true);
            LoadUserGV();
        }
    }

    protected void resetPassword_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        //Get the row that contains this button
        GridViewRow gvr = (GridViewRow)btn.NamingContainer;
        int rowIndex = gvr.RowIndex; // Get the current row
        string userId = usersGV.Rows[rowIndex].Cells[0].Text;
        MySqlConnection connection = new MySqlConnection(connectionString);
        try
        {
            connection.Open();
            MySqlCommand cmd = new MySqlCommand("Update users set password='bearcats' where id=@userId", connection);
            cmd.Parameters.AddWithValue("userId", userId);
            cmd.ExecuteNonQuery();

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
            ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('Password changed to bearcats');", true);
            LoadUserGV();
        }
    }
}
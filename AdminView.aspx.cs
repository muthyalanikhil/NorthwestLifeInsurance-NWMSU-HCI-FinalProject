using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.IO;

public partial class AdminView : Page
{
    String connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["username"] != null && Session["role"].ToString() == "agent")
            {
                LoadPolicyListGV();
            }
            else
            {
                Response.Redirect("~/Error");
            }
        }     
    }

    private void LoadPolicyListGV()
    {
        MySqlConnection connection = new MySqlConnection(connectionString);
        try
        {
            connection.Open();
            MySqlCommand cmd = new MySqlCommand("select id,policyName,description,amount from policies", connection);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            policyListGV.DataSource = dt;
            policyListGV.DataBind();
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

    protected void CreatePolicy_Click(object sender, EventArgs e)
    {
        string policyName = policyNameTB.Text;
        string description = descriptionTB.Text;
        string amount = premiumAmountTB.Text;

        MySqlConnection connection = new MySqlConnection(connectionString);
        MySqlCommand cmd;
        connection.Open();
        try
        {
            cmd = connection.CreateCommand();
            cmd.CommandText = "INSERT INTO policies(policyName,description,amount) VALUES(@policyName,@description,@amount)";
            cmd.Parameters.AddWithValue("@policyName", policyName);
            cmd.Parameters.AddWithValue("@description", description);
            cmd.Parameters.AddWithValue("@amount", amount);
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
            LoadPolicyListGV();
            policyNameTB.Text = "";
            descriptionTB.Text = "";
            premiumAmountTB.Text = "";
            ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('Policy Created successfully.');", true);
        }
    }

    protected void deletePolicy_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        //Get the row that contains this button
        GridViewRow gvr = (GridViewRow)btn.NamingContainer;
        int rowIndex = gvr.RowIndex; // Get the current row
        string policyId = policyListGV.Rows[rowIndex].Cells[0].Text;

        MySqlConnection connection = new MySqlConnection(connectionString);
        MySqlCommand cmdd;
        connection.Open();
        try
        {
            cmdd = connection.CreateCommand();
            cmdd.CommandText = "DELETE FROM policies WHERE id=@policyId";
            cmdd.Parameters.AddWithValue("@policyId", policyId);
            cmdd.ExecuteNonQuery();
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

        MySqlConnection connection2 = new MySqlConnection(connectionString);
        MySqlCommand cmd;
        connection.Open();
        try
        {
            cmd = connection.CreateCommand();
            cmd.CommandText = "DELETE FROM requests WHERE policyId=@policyId";
            cmd.Parameters.AddWithValue("@policyId", policyId);
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
            ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('Policy Created successfully.');", true);
        }
        LoadPolicyListGV();
    }
}
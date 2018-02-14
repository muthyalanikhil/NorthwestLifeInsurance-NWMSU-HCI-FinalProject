using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserView : System.Web.UI.Page
{
    String connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
    string userId = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        userId = Session["userID"].ToString();
        if (!IsPostBack)
        {
            if (Session["username"] != null && Session["role"].ToString() == "user")
            {
                LoadPolicyListGV();
                LoadActivePolicyListGV();
            }
            else
            {
                Response.Redirect("~/Error");
            }
        }     
    }

    private void LoadActivePolicyListGV()
    {
        MySqlConnection connection = new MySqlConnection(connectionString);
        try
        {
            connection.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT n.id,n.policyName,n.description,n.amount,r.isAccepted FROM requests as r join policies as n where r.policyId=n.id and r.userId=@userId", connection);
            cmd.Parameters.AddWithValue("userId", userId);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            activePoliciesGV.DataSource = dt;
            activePoliciesGV.DataBind();
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

    protected void buyPolicy_Click(object sender, EventArgs e)
    {
        int result = 0;
        MySqlConnection connection1 = new MySqlConnection(connectionString);
        connection1.Open();
        try
        {
            MySqlCommand mysqlcmd = connection1.CreateCommand();
            mysqlcmd.CommandText = "SELECT count(*) FROM profile WHERE userId=@userId";
            mysqlcmd.Parameters.AddWithValue("userId", Session["userID"].ToString());
            result = Convert.ToInt32(mysqlcmd.ExecuteScalar());
        }
        catch (Exception ex)
        {
            Response.Redirect("~/Error");
        }
        finally
        {
            if (connection1.State == ConnectionState.Open)
            {
                connection1.Close();
            }
        }
        if (result > 0)
        {
            Button btn = (Button)sender;
            //Get the row that contains this button
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowIndex = gvr.RowIndex; // Get the current row
            string policyId = policyListGV.Rows[rowIndex].Cells[0].Text;
            string amount = policyListGV.Rows[rowIndex].Cells[3].Text;
            Response.Redirect("Payments.aspx?policyId=" + policyId + "&amount=" + amount, false);
        }
        else {
            ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('Please update your profile to buy policies.');", true);
        }
    }

    protected void activePoliciesGV_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TableCell statusCell = e.Row.Cells[3];
            if (statusCell.Text == "1")
            {
                statusCell.Text = "Approved";

            }
            else
            {
                statusCell.Text = "Is Pending";
            }
        }
    }
}
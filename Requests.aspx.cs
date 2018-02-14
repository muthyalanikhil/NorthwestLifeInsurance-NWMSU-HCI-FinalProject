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

public partial class Requests : System.Web.UI.Page
{
    String connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadRequestsGV();
        }
    }

    private void LoadRequestsGV()
    {
        MySqlConnection connection = new MySqlConnection(connectionString);
        try
        {
            connection.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT p.userId,r.policyId, p.userName, p.email, a.policyName,r.policyPremium,r.isAccepted FROM profile as p join policies as a join requests as r where p.userId = r.userId and a.id = r.policyId", connection);
            cmd.Parameters.AddWithValue("userId", Session["userID"].ToString());
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            requestsGV.DataSource = dt;
            requestsGV.DataBind();

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

    protected void changeStatus_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        //Get the row that contains this button
        GridViewRow gvr = (GridViewRow)btn.NamingContainer;
        int rowIndex = gvr.RowIndex; // Get the current row
        string userId = requestsGV.Rows[rowIndex].Cells[0].Text;
        string policyId = requestsGV.Rows[rowIndex].Cells[1].Text;
        MySqlConnection connection = new MySqlConnection(connectionString);
        try
        {
            connection.Open();
            MySqlCommand cmd = new MySqlCommand("Update requests set isAccepted='1' where userId=@userId and policyId=@policyId", connection);
            cmd.Parameters.AddWithValue("userId", userId);
            cmd.Parameters.AddWithValue("policyId", policyId);
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
            LoadRequestsGV();
        }
    }

    protected void requestsGV_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TableCell statusCell = e.Row.Cells[6];
            if (statusCell.Text == "1")
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Button btnButton = (Button)e.Row.FindControl("changeStatus");
                    btnButton.Text = "Approved";
                    btnButton.CssClass = "btn btn-success";
                }
            }
            else
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Button btnButton = (Button)e.Row.FindControl("changeStatus");
                    btnButton.Text = "Pending";
                    btnButton.CssClass = "btn btn-primary";
                }
            }
        }
    }
}
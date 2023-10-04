using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["UserId"] != null)
            {
                string userId = Session["UserId"].ToString();
                GetProposals(userId);
                GetUser(userId);
            }
            else
            {
                Response.Redirect("~/Account/Login.aspx");
            }
        }
    }
    private void GetProposals(string userId)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Tarea1"].ConnectionString;

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "SELECT * FROM LegislativeProposals WHERE users_id = @UserId";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@UserId", userId);

                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    GridView1.DataSource = dataTable;
                    GridView1.DataBind();
                }
            }
        }
    }
    private void GetUser(string userId)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Tarea1"].ConnectionString;

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "SELECT IdType.name as id_type_name, Users.name as user_name, Users.phone as user_phone, Users.last_name as user_lastname,  Users.email as user_email," +
                           "IdType.name, Users.id as user_id, Province.name as province_name, Canton.name as canton_name " +
                           "FROM Users INNER JOIN IdType on Users.id_type = IdType.id INNER JOIN Canton on Users.canton_id = Canton.id " +
                           "INNER JOIN Province on Canton.province_id = Province.id WHERE Users.id = @UserId";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@UserId", userId);

                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    GridView2.DataSource = dataTable;
                    GridView2.DataBind();
                }
            }
        }
    }
}
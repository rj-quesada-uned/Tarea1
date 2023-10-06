using Microsoft.AspNet.Identity;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSite1;

public partial class Account_Register : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetProvinces();
        }
    }
    protected void CreateUser_Click(object sender, EventArgs e)
    {
        string id = UserName.Text.Replace("-", "");
        string idType = idOptions.Text;
        string name = Name.Text;
        string lastName = LastName.Text;
        string email = Email.Text;
        string phone = PhoneNumber.Text;
        string password = Password.Text;
        string cantonId = idCanton.Text;

        string connectionString = ConfigurationManager.ConnectionStrings["Tarea1"].ConnectionString;


        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "INSERT INTO Users (id, id_type, name, last_name, email, phone, password, canton_id) VALUES (@Id, @Id_Type, @Name, @Last_Name, @Email, @Phone, @Password, @Canton_Id)";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Id_Type", idType);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Last_Name", lastName);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Phone", phone);
                command.Parameters.AddWithValue("@Password", password);
                command.Parameters.AddWithValue("@Canton_Id", cantonId);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                connection.Close();

                if (rowsAffected > 0)
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }
    }

    private void GetProvinces()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Tarea1"].ConnectionString;

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "SELECT id, name from Province";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {

                    idProvince.Items.Clear();
                    idProvince.Items.Insert(0, new ListItem("Seleccione una provincia", ""));
                    while (reader.Read())
                    {
                        string id = reader["id"].ToString();
                        string name = reader["name"].ToString();

                        ListItem item = new ListItem(name, id);
                        idProvince.Items.Add(item);
                    }
                }
            }
        }
    }

    protected void idProvince_SelectedIndexChanged(object sender, EventArgs e)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Tarea1"].ConnectionString;
        int provinceId = int.Parse(idProvince.SelectedValue);

        if (provinceId > 0)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT id, name from Canton WHERE province_id = @Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", provinceId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        idCanton.Items.Clear();
                        idCanton.Items.Insert(0, new ListItem("Seleccione un canton", ""));
                        while (reader.Read())
                        {
                            string id = reader["id"].ToString();
                            string name = reader["name"].ToString();

                            ListItem item = new ListItem(name, id);
                            idCanton.Items.Add(item);
                            divCanton.Style["visibility"] = "initial";
                        }
                    }
                }
            }
        }
        else
        {
            divCanton.Style["visibility"] = "hidden";
        }
    }
}
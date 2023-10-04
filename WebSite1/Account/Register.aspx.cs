using Microsoft.AspNet.Identity;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI;
using WebSite1;

public partial class Account_Register : Page
{
    protected void CreateUser_Click(object sender, EventArgs e)
    {
        string id = UserName.Text;
        string idType = idOptions.Text;
        string name = Name.Text;
        string lastName = LastName.Text;
        string email = Email.Text;
        string phone = PhoneNumber.Text;
        string password = Password.Text;

        string connectionString = ConfigurationManager.ConnectionStrings["Tarea1"].ConnectionString;


        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "INSERT INTO Users (id, id_type, name, last_name, email, phone, password) VALUES (@Id, @Id_Type, @Name, @Last_Name, @Email, @Phone, @Password)";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Id_Type", idType);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Last_Name", lastName);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Phone", phone);
                command.Parameters.AddWithValue("@Password", password);

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

    protected void CleanFields_Click(object sender, EventArgs e)
    {
        UserName.Text = string.Empty;
        idOptions.Text = string.Empty;
        Name.Text = string.Empty;
        LastName.Text = string.Empty;
        Email.Text = string.Empty;
        PhoneNumber.Text = string.Empty;
        Password.Text = string.Empty;
    }
}
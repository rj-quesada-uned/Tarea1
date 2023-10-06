using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using WebSite1;

public partial class Account_Login : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["UserId"] != null)
            {
                Response.Redirect("~/");
            }
        }
    }
    protected void LogIn(object sender, EventArgs e)
        {
            string id = UserName.Text;
            string password = Password.Text;

            string connectionString = ConfigurationManager.ConnectionStrings["Tarea1"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT id FROM Users WHERE id = @Username AND password = @Password";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", id);
                    command.Parameters.AddWithValue("@Password", password);

                    connection.Open();
                    object result = command.ExecuteScalar();
                    connection.Close();

                    if (result != null)
                    {
                        Session["UserId"] = id;
                        Session["Authenticated"] = true;
                        Response.Redirect("~/Default.aspx");
                    }
                    else
                    {
                        lblMensajeError.Text = "Nombre de usuario o contraseña incorrectos.";
                    }
            }
            }
    }
}
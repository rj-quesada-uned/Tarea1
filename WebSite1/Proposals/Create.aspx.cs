using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;

public partial class Proposals_Create : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserId"] == null)
        {
            Response.Redirect("/");
        }
    }

    protected void Create_XML(string title, string content, string userId)
    {
        string path = Server.MapPath("~/");
        string fileName = "data.xml";
        string filePath = Path.Combine(path, fileName);

        if (File.Exists(filePath))
        {
            XDocument xmlDoc = XDocument.Load(filePath);

            XElement newProposal = new XElement("propuesta",
                new XElement("titulo", title),
                new XElement("descripcion", content),
                new XElement("user_id", userId)
            );

            xmlDoc.Root.Add(newProposal);



            xmlDoc.Save(filePath);
        }
        else
        {
            XDocument xmlDoc = new XDocument(
                new XElement("propuestas",
                    new XElement("propuesta",
                        new XElement("titulo", title),
                        new XElement("descripcion", content),
                        new XElement("user_id", userId)
                    )
                )
            );

            xmlDoc.Save(filePath);
        }
    }
    protected void Create_Click(object sender, EventArgs e)
    {
        string title = Title.Text;
        string content = Content.Text;
        string userId = Session["UserId"] as string;

        Create_XML(title, content, userId);

        if (content.Length >= 50 && content.Length <= 200)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Tarea1"].ConnectionString;


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO LegislativeProposals (title, description, users_id) VALUES (@Title, @Description, @User_Id)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Title", title);
                    command.Parameters.AddWithValue("@Description", content);
                    command.Parameters.AddWithValue("@User_Id", userId);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    connection.Close();
                    Response.Redirect("/");
                }
            }
        }
        
    }
}
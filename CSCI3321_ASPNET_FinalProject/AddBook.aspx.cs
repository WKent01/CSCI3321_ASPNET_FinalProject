using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;


namespace CSCI3321_ASPNET_FinalProject
{
    public partial class AddBook : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddBook_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = WebConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;

            SqlCommand cmdAuthor = new SqlCommand();
            SqlCommand cmdPublisher = new SqlCommand();
            SqlCommand cmdGenre = new SqlCommand();
            SqlCommand cmdBook = new SqlCommand();

            cmdAuthor.Connection = conn;
            cmdPublisher.Connection = conn;
            cmdGenre.Connection = conn;
            cmdBook.Connection = conn;

            cmdAuthor.CommandText = String.Format("SELECT AuthorID FROM Authors WHERE LastName = '{0}'", dropDownAuthor.SelectedItem.Text.Substring(dropDownAuthor.SelectedItem.Text.IndexOf(" ") + 1));
            cmdPublisher.CommandText = String.Format("SELECT PublisherID FROM Publishers WHERE PublisherName = '{0}'", dropDownPublisher.SelectedItem.Text);
            cmdGenre.CommandText = String.Format("SELECT GenreId FROM Genres WHERE GenreName = '{0}'", dropDownGenre.SelectedItem.Text);


            conn.Open();
            SqlDataReader authorReader = cmdAuthor.ExecuteReader();
            int authorID = 0;
            while (authorReader.Read())
            {
                authorID = authorReader.GetInt32(0);
            }
            authorReader.Close();

            SqlDataReader publisherReader = cmdPublisher.ExecuteReader();
            int publisherID = 0;
            while (publisherReader.Read())
            {
                publisherID = publisherReader.GetInt32(0);
            }
            publisherReader.Close();

            SqlDataReader genreReader = cmdGenre.ExecuteReader();
            int genreID = 0;
            while (genreReader.Read())
            {
                genreID = genreReader.GetInt32(0);
            }
            genreReader.Close();

            cmdBook.CommandText = String.Format("INSERT INTO Books VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')",
                txtBookTitle.Text,
                authorID,
                txtPrice.Text,
                txtPublishDate.Text,
                publisherID,
                genreID,
                txtWordCount.Text);

            cmdBook.ExecuteNonQuery();
            conn.Close();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace CSCI3321_ASPNET_FinalProject
{
    public partial class MyBooks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /// TODO: Dynamiclly build your book collection with the following information
            /// 1. Book title
            /// 2. Author's LastName and FirstName
            /// 3. Price
            /// 4. Publish date
            /// 5. Publisher's name
            /// 6. Genre
            /// 7. Word Count
            /// 
            // 1. Create a SqlConnection object
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = WebConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;

            SqlConnection conn_2 = new SqlConnection();
            conn_2.ConnectionString = WebConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;

            // 2. Create a SqlCommand object using the above connection object
            SqlCommand cmd = new SqlCommand();
            SqlCommand cmdAuthor = new SqlCommand();
            SqlCommand cmdPublisher = new SqlCommand();
            SqlCommand cmdGenre = new SqlCommand();

            cmdPublisher.Connection = conn_2;
            cmdAuthor.Connection = conn_2;
            cmdGenre.Connection = conn_2;
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM Books";

            // 3. Open the connection and execute the command
            // store the returned data in a SqlDataReader object
            conn.Open();
            conn_2.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            // 4. if there is data in the SqlDataReader object
            // then loop through each record to build the table to display the books
            TableRow tr = new TableRow();
            TableCell tc = new TableCell();

            if (reader.HasRows)
            {
                // Build the table 
                while (reader.Read())
                {
                    cmdAuthor.CommandText = String.Format("SELECT FirstName, LastName from Authors WHERE AuthorID = {0}",
                        reader["AuthorID"].ToString()
                        );
                    cmdPublisher.CommandText = String.Format("SELECT PublisherName FROM Publishers WHERE PublisherID = {0}",
                        reader["PublisherID"].ToString()
                        );
                    cmdGenre.CommandText = String.Format("SELECT GenreName FROM Genres WHERE GenreID = {0}",
                        reader["GenreID"].ToString()
                        );

                    tc.Text = reader["Title"].ToString();
                    tr.Cells.Add(tc);

                    SqlDataReader authorReader = cmdAuthor.ExecuteReader();
                    if (authorReader.HasRows)
                    {
                        while (authorReader.Read())
                        {
                            tc = new TableCell();
                            tc.Text = authorReader["FirstName"].ToString() + " " + authorReader["LastName"].ToString();
                            tr.Cells.Add(tc);
                        }
                    }
                    authorReader.Close();

                    tc = new TableCell();
                    tc.Text = reader["Price"].ToString();
                    tr.Cells.Add(tc);

                    tc = new TableCell();
                    tc.Text = String.Format("{0:MM/dd/yyyy}", reader["PublishDate"]);
                    tr.Cells.Add(tc);

                    //publisher name here
                    SqlDataReader publisherReader = cmdPublisher.ExecuteReader();
                    if (publisherReader.HasRows)
                    {
                        while (publisherReader.Read())
                        {
                            tc = new TableCell();
                            tc.Text = publisherReader["PublisherName"].ToString();
                            tr.Cells.Add(tc);
                        }
                    }
                    publisherReader.Close();

                    //genre here
                    SqlDataReader genreReader = cmdGenre.ExecuteReader();
                    if (genreReader.HasRows)
                    {
                        while (genreReader.Read())
                        {
                            tc = new TableCell();
                            tc.Text = genreReader["GenreName"].ToString();
                            tr.Cells.Add(tc);
                        }
                    }
                    genreReader.Close();

                    tc = new TableCell();
                    tc.Text = reader["WordCount"].ToString();
                    tr.Cells.Add(tc);

                    tblBooks.Rows.Add(tr);
                }
            }

            reader.Close();
        }
    }
}
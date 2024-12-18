using Microsoft.Data.SqlClient;
using System.Data;
using static System.Reflection.Metadata.BlobBuilder;

namespace ManagementLibraryMM.UI.Models
{
    public class BookSearch
    {
        public List<Book> SearchData()
        {
            List<Book> bookList = new List<Book>();

            string connectionString = "Data Source=DESKTOP-FTCVI92\\SQLEXPRESS;Initial Catalog=Library;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand insertComm = new SqlCommand("SELECT * FROM Books", conn);

            SqlDataReader reader = insertComm.ExecuteReader();

            while (reader.Read()) {
                Book book = new Book()
                {
                    Id = reader.GetInt32(0),
                    Title = reader.GetString(1),
                    Author = reader.GetString(2),
                    DatePublication = reader.GetDateTime(3)
                };
                bookList.Add(book); 
            }

            conn.Close();

            return bookList;
        }

        public int UpdateData(int id, string title, string author, DateTime datePublication)
        {
            int update = 0;
            string connectionString = "Data Source=DESKTOP-FTCVI92\\SQLEXPRESS;Initial Catalog=Library;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand updateComm = new SqlCommand("UPDATE Books SET Title = @title, Author = @author, YearPublication = @publicationYear WHERE Id = @id", conn);


            updateComm.Parameters.AddWithValue("@id", id);
            updateComm.Parameters.AddWithValue("@title", title);
            updateComm.Parameters.AddWithValue("@author", author);
            updateComm.Parameters.AddWithValue("@publicationYear", datePublication);

            update = updateComm.ExecuteNonQuery();

            conn.Close();

            return update;
        }

        public int DeleteData(int id)
        {
            int delete = 0;
            string connectionString = "Data Source=DESKTOP-FTCVI92\\SQLEXPRESS;Initial Catalog=Library;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand deleteComm = new SqlCommand("DELETE Books WHERE Id = @id", conn);

            deleteComm.Parameters.AddWithValue("@id", id);

            delete = deleteComm.ExecuteNonQuery();

            conn.Close();

            return delete;
        }
    }
}

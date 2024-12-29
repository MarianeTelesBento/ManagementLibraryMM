using Microsoft.Data.SqlClient;
using System.Data;
using static System.Reflection.Metadata.BlobBuilder;

namespace ManagementLibraryMM.UI.Models
{
    public class BookDataBase
    {
        private string _connectionString = "Data Source=PC-MARI\\SQLEXPRESS;Initial Catalog=Library;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        public List<Book> SearchData()
        {
            List<Book> bookList = new List<Book>();

            SqlConnection conn = new SqlConnection(_connectionString);
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

            SqlConnection conn = new SqlConnection(_connectionString);
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

            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();

            SqlCommand deleteComm = new SqlCommand("DELETE Books WHERE Id = @id", conn);

            deleteComm.Parameters.AddWithValue("@id", id);

            delete = deleteComm.ExecuteNonQuery();

            conn.Close();

            return delete;
        }

         public int RegisterData(string title, string author, DateTime datePublication)
        {
            int sucess = 0;
            string connectionString = "Data Source=PC-MARI\\SQLEXPRESS;Initial Catalog=Library;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand insertComm = new SqlCommand("INSERT INTO Books values(@title, @author, @publicationYear)", conn);

            insertComm.Parameters.AddWithValue("@title", title);
            insertComm.Parameters.AddWithValue("@author", author);
            insertComm.Parameters.AddWithValue("@publicationYear", datePublication);

            sucess = insertComm.ExecuteNonQuery();

            conn.Close();

            return sucess;
        }
    }
}

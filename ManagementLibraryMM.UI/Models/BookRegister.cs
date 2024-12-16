using Microsoft.Data.SqlClient;

namespace ManagementLibraryMM.UI.Models
{
    public class BookRegister
    {
        public int RegisterData(string title, string author, DateTime datePublication)
        {
            int sucess = 0;
            string connectionString = "Data Source=DESKTOP-FTCVI92\\SQLEXPRESS;Initial Catalog=Library;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

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

using Microsoft.Data.SqlClient;

namespace ManagementLibraryMM.UI.Models
{
    public class BookSearch
    {
        public List<Book> SearchData(int id)
        {
            int sucess = 0;
            string connectionString = "Data Source=DESKTOP-FTCVI92\\SQLEXPRESS;Initial Catalog=Library;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand insertComm = new SqlCommand("SELECT * FROM Books", conn);

            sucess = insertComm.ExecuteNonQuery();

            conn.Close();

            return sucess;
        }
    }
}

using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace lab4
{
    public class DatabaseAccess
    {
        private string connectionString;

        public DatabaseAccess()
        {
            connectionString = ConfigurationManager.ConnectionStrings["connectionString_ADO"].ConnectionString;
        }

        public DataTable GetBooks()
        {
            DataTable booksTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT ISBN, Name, Author, Publisher, Year FROM Books";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        connection.Open();
                        adapter.Fill(booksTable);
                    }
                }
            }

            return booksTable;
        }
    }
}

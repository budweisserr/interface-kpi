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

        public void AddBook(string isbn, string name, string author, string publisher, int year)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Books (ISBN, Name, Author, Publisher, Year) VALUES (@ISBN, @Name, @Author, @Publisher, @Year)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ISBN", isbn);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Author", author);
                    command.Parameters.AddWithValue("@Publisher", publisher);
                    command.Parameters.AddWithValue("@Year", year);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateBook(string isbn, string name, string author, string publisher, int year)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Books SET Name = @Name, Author = @Author, Publisher = @Publisher, Year = @Year WHERE ISBN = @ISBN";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ISBN", isbn);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Author", author);
                    command.Parameters.AddWithValue("@Publisher", publisher);
                    command.Parameters.AddWithValue("@Year", year);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteBook(string isbn)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Books WHERE ISBN = @ISBN";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ISBN", isbn);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}

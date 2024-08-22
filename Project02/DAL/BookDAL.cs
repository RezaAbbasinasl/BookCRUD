using Project02.Models;
using System.Data.SqlClient;
using System.Data;

namespace Project02.DAL
{
    public class BookDAL
    {

        private string connectionString = @"SERVER=(local);DATABASE = Test;USER ID = sa; PASSWORD = Reza3108; TrustServerCertificate=True;";

        public List<Book> GetAllBook()
        {
            List<Book> BookList = new List<Book>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryString = "SELECT BookId, Titel, Author, Genre, Price, PublishDate FROM Book2";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.CommandType = CommandType.Text;

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Book book = new Book();
                    book.BookId = (Int32)reader["BookId"];
                    book.Titel = (string)reader["Titel"];
                    book.Author = (string)reader["Author"];
                    book.Genre = (string)reader["Genre"];
                    book.Price = (decimal)reader["Price"];
                    book.PublishDate = (DateTime)reader["PublishDate"];
                    BookList.Add(book);
                }        
            };
            return BookList;
        }
    }
}

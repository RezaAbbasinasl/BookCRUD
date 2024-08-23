using Project02.Models;
using System.Data.SqlClient;
using System.Data;

namespace Project02.DAL
{
    public class BookDAL
    {

        private string connectionString = @"SERVER=.\SQL2022;DATABASE = Test;USER ID = sa; PASSWORD = ; TrustServerCertificate=True;";

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
        public void AddBook(Book book)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryString = "INSERT INTO Book2 (Titel, Author, Genre, Price, PublishDate) VALUES (@Titel, @Author, @Genre, @Price, @PublishDate)";
                SqlCommand command = new SqlCommand(queryString, connection);

                command.Parameters.AddWithValue("@Titel", book.Titel);
                command.Parameters.AddWithValue("@Author", book.Author);
                command.Parameters.AddWithValue("@Genre", book.Genre);
                command.Parameters.AddWithValue("@Price", book.Price);
                command.Parameters.AddWithValue("@PublishDate", book.PublishDate);

                connection.Open();
                command.ExecuteNonQuery();
            };
              
        }
        public void EditBook(Book book)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryString = "UPDATE Book2 SET Titel = @Titel, Author = @Author, Genre = @Genre, Price = @Price, PublishDate = @PublishDate WHERE BookId = @id";
                SqlCommand command = new SqlCommand(queryString, connection);

                command.Parameters.AddWithValue("@id", book.BookId);
                command.Parameters.AddWithValue("@Titel", book.Titel);
                command.Parameters.AddWithValue("@Author", book.Author);
                command.Parameters.AddWithValue("@Genre", book.Genre);
                command.Parameters.AddWithValue("@Price", book.Price);
                command.Parameters.AddWithValue("@PublishDate", book.PublishDate);                

                connection.Open();
                command.ExecuteNonQuery();
            };
        }
        public Book GetById(int id)
        {
            Book book =  null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT BookId, Titel, Author, Genre, Price, PublishDate FROM Book2 WHERE BookId = @BookId", connection);
                cmd.Parameters.AddWithValue("@BookId", id);
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    book = new Book
                    {
                        BookId = (Int32)rdr["BookId"],
                        Titel = (string)rdr["Titel"],
                        Author = (string)rdr["Author"],
                        Genre = (string)rdr["Genre"],
                        Price = (decimal)rdr["Price"],
                        PublishDate = (DateTime)rdr["PublishDate"]
                    };
                }                
            }
            return book;
        }
    }
}

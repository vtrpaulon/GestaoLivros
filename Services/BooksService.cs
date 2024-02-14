using System.Data.SqlClient;
using GestaoLivros.Database;

namespace GestaoLivros.Services
{
    internal static class BooksService
    {
        private static readonly string DbConnection = ConnectionString.DbConnection;
        
        public static void GetBooks()
        {
            using (SqlConnection connection = new SqlConnection(DbConnection))
            {
                connection.Open();
                string query = "select * from Livro";
                using (SqlCommand sqlCommand = new SqlCommand(query, connection))
                {
                    
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var titulo = reader["Titulo"];
                            var autorId = reader["AutorId"];
                            var anoPublicacao = reader["AnoPublicacao"];
                            
                            Console.WriteLine($"Título:{titulo}\nAutor: {autorId}\nAno de publicação: {anoPublicacao}");
                        }    
                    }
                }
            }                
        }

        public static void GetBookById(int id)
        {
            using (SqlConnection connection = new SqlConnection(DbConnection))
            {
                connection.Open();
                string query = $"select * from Livro where Id = '{id}';";
                using (SqlCommand sqlCommand = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var titulo = reader["Titulo"];
                            var autor = reader["AutorId"];
                            var anoPublicacao = reader["AnoPublicacao"];
                            
                            Console.WriteLine($"Título:{titulo}\nAutor: {autor}\nAno de publicação: {anoPublicacao}");
                        }    
                    }
                }
            }                
        }



        public static void AddBook(int authorId, string title, int year)
        {
            using (SqlConnection connection = new SqlConnection(DbConnection))
            {
                connection.Open();
                string query = $"insert into Livro (AutorId, Titulo, AnoPublicacao) values ('{authorId}','{title}', '{year}')";
                
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
                
            }
        }
    }
}
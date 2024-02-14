using System.Data.SqlClient;
using GestaoLivros.Database;

namespace GestaoLivros.Services;

public class AuthorsService
{
    private static readonly string DbConnection = ConnectionString.DbConnection;

    public static void GetAuthors()
    {
        using (SqlConnection connection = new SqlConnection(DbConnection))
        {
            connection.Open();
            string query = "select * from Autor";
            using (SqlCommand sqlCommand = new SqlCommand(query, connection))
            {                    
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["nome"]}");
                    }    
                }
            }
        } 
    }
    
    public static void GetAuthorById(int id)
    {
        using (SqlConnection connection = new SqlConnection(DbConnection))
        {
            connection.Open();
            string query = $"select Nome from Autor where Id = {id}";
            using (SqlCommand sqlCommand = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["nome"]}");
                    }    
                }
            }
        } 
    }

    public static void AddAuthor(string name)
    {
        using (SqlConnection connection = new SqlConnection(DbConnection))
        {
            connection.Open();
            string query = $"insert into Autor (Nome) values ('{name}');";
            using (SqlCommand sqlCommand = new SqlCommand(query, connection))
            {
                sqlCommand.ExecuteNonQuery();
            }
        }
    }

    public static void DeleteAuthor(int id)
    {
        using (SqlConnection connection = new SqlConnection(DbConnection))
        {
            connection.Open();

            string query = $"delete from Autor where Id = '{id}'";

            using (SqlCommand sqlCommand = new SqlCommand(query, connection))
            {
                sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
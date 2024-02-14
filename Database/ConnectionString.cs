using System.Data.SqlClient;

namespace GestaoLivros.Database;

public static class ConnectionString
{
    public static readonly string DbConnection = new SqlConnectionStringBuilder()
    {
        DataSource = "shmatriz.ddns.com.br,1430",
        InitialCatalog = "TESTES",
        UserID = "HUGODEV",
        Password = "hugo25",
        
    }.ConnectionString;
}
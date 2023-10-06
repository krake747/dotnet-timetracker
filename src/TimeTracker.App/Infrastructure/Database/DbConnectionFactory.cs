using System.Data;
using Microsoft.Data.Sqlite;

namespace TimeTracker.App.Infrastructure.Database;

internal sealed class DbConnectionFactory(string connectionString)
{
    internal IDbConnection CreateConnection()
    {
        var connection = new SqliteConnection(connectionString);
        connection.Open();
        return connection;
    }
}
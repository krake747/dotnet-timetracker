using Dapper;

namespace TimeTracker.App.Infrastructure.Database;

internal sealed class DbInitializer(DbConnectionFactory connectionFactory)
{
    internal bool InitializeTables()
    {
        using var connection = connectionFactory.CreateConnection();
        // lang=sqlite
        var created = connection.Execute(new CommandDefinition(
            """
            CREATE TABLE IF NOT EXISTS Activities (
                [Id] INTEGER PRIMARY KEY AUTOINCREMENT,
                [Date] TEXT NOT NULL,
                [Hours] REAL NOT NULL,
                [Description] TEXT NOT NULL
            );
            """));

        return created > 0;
    }
}
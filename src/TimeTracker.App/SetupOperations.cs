using TimeTracker.App.Domain.Extensions;
using TimeTracker.App.Infrastructure.Common;
using TimeTracker.App.Infrastructure.Database;

namespace TimeTracker.App;

internal static class SetupOperations
{
    internal static ConnectionString CreateDatabasePath(string databasePath, string database)
    {
        var userDirectoryInfo = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)
            .Pipe(Directory.CreateDirectory);

        var timeTrackerDbFullPath = Path.Combine(userDirectoryInfo.FullName, databasePath, database);
        if (File.Exists(timeTrackerDbFullPath))
        {
            return new ConnectionString(timeTrackerDbFullPath);
        }

        _ = Directory.CreateDirectory(Path.Combine(userDirectoryInfo.FullName, databasePath)); 
        return new ConnectionString(timeTrackerDbFullPath);
    }
    
    internal static void CreateLocalDbIfNotExists(string timeTrackerDbFullPath)
    {
        if (File.Exists(timeTrackerDbFullPath))
        {
            return;
        }

        var fileStream = File.Create(timeTrackerDbFullPath);
        fileStream.Close();
        Console.WriteLine($"Local Database created: {timeTrackerDbFullPath}");
    }

    internal static void InitializeDbTablesIfNotExists(DbConnectionFactory connectionFactory)
    {
        var dbInitializer = new DbInitializer(connectionFactory);
        _ = dbInitializer.InitializeTables();
    }
}
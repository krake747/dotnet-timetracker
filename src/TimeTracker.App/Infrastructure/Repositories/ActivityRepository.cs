using Dapper;
using TimeTracker.App.Application.Activities;
using TimeTracker.App.Domain.Activities;
using TimeTracker.App.Domain.Common;
using TimeTracker.App.Infrastructure.Database;

namespace TimeTracker.App.Infrastructure.Repositories;

internal sealed class ActivityRepository(DbConnectionFactory connectionFactory)
{
    internal bool CreateTimeRecord(CreateActivityCommand command)
    {
        using var connection = connectionFactory.CreateConnection();
        // lang=sqlite
        var createCommand = new CommandDefinition(
            "INSERT INTO Activities ([Date], [Hours], [Description]) VALUES (@Date, @Hours, @Description)",
            new { command.Date, command.Hours, command.Description });

        var inserted = connection.Execute(createCommand);
        return inserted > 0;
    }

    internal IEnumerable<Activity> GetAllActivities(GetAllActivitiesQuery query)
    {
        using var connection = connectionFactory.CreateConnection();
        // lang=sqlite
        var getAllQuery = new CommandDefinition(
            $"""
             SELECT a.[Id], a.[Date], a.[Hours], a.[Description]
             FROM Activities a
             ORDER BY a.[Id] {(query.Ordering is Ordering.Ascending ? "ASC" : "DESC")}
             LIMIT @Limit
             """, new { query.Limit });

        var results = connection.Query<Activity>(getAllQuery);
        return results;
    }
}
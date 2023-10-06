using TimeTracker.App.Application.Activities;
using TimeTracker.App.Domain.Common;
using TimeTracker.App.Domain.Extensions;
using TimeTracker.App.Infrastructure.Common;
using TimeTracker.App.Infrastructure.Repositories;

namespace TimeTracker.App;

internal static class MainOperations
{
    internal static void CreateNewActivityHandler(
        ActivityRepository activityRepository, 
        SystemDateTimeProvider dateTimeProvider,
        double hours, 
        string activity)
    {
        var today = dateTimeProvider.Today;
        var created = new CreateActivityCommand(today, hours, activity)
            .Pipe(activityRepository.CreateTimeRecord);
        if (created is false)
        {
            Console.WriteLine("New Activity not added");
            return;
        }

        Console.WriteLine("New Activity created");
        var activities = new GetAllActivitiesQuery(5, Ordering.Descending)
            .Pipe(activityRepository.GetAllActivities)
            .ToList();

        var activityDtos = activities.ConvertAll(ActivityView.From);
        foreach (var a in activityDtos)
        {
            Console.WriteLine(a);
        }
    }
}
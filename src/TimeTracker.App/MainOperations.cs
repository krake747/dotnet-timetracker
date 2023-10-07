using TimeTracker.App.Application.Activities;
using TimeTracker.App.Domain.Common;
using TimeTracker.App.Domain.Extensions;
using TimeTracker.App.Infrastructure.Common.Interfaces;
using TimeTracker.App.Infrastructure.Repositories;

namespace TimeTracker.App;

internal static class MainOperations
{
    internal static void CreateNewActivityHandler(
        ActivityRepository activityRepository,
        IDateTimeProvider dateTimeProvider,
        double hours,
        string activity)
    {
        _ = activityRepository.CreateActivity(new CreateActivityCommand(dateTimeProvider.Today, hours, activity));
        var activityViews = new GetAllActivitiesQuery(5, Ordering.Descending)
            .Pipe(activityRepository.GetAllActivities)
            .Select(ActivityView.From);

        foreach (var view in activityViews)
        {
            Console.WriteLine(view);
        }
    }
}
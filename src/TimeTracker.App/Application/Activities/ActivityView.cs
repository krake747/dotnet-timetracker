using TimeTracker.App.Domain.Activities;

namespace TimeTracker.App.Application.Activities;

public sealed record ActivityView(string Date, double Hours, string Description)
{
    internal static ActivityView From(Activity activity) => 
        new(activity.Date.ToString("O"), activity.Hours, activity.Description);
}
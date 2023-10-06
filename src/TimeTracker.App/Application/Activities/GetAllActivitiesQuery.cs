using TimeTracker.App.Domain.Common;

namespace TimeTracker.App.Application.Activities;

public sealed record GetAllActivitiesQuery(int Limit, Ordering Ordering);
namespace TimeTracker.App.Application.Activities;

public sealed record CreateActivityCommand(DateOnly Date, double Hours, string Description);
namespace TimeTracker.App.Infrastructure.Common;

internal sealed class SystemDateTimeProvider
{
    internal DateOnly Today => DateOnly.FromDateTime(DateTime.Today);
}
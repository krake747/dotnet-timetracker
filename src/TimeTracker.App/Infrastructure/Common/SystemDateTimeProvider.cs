using TimeTracker.App.Infrastructure.Common.Interfaces;

namespace TimeTracker.App.Infrastructure.Common;

internal sealed class SystemDateTimeProvider : IDateTimeProvider
{
    public DateOnly Today => DateOnly.FromDateTime(DateTime.Today);
}
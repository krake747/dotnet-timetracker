namespace TimeTracker.App.Infrastructure.Common.Interfaces;

public interface IDateTimeProvider
{
    DateOnly Today { get; }
}
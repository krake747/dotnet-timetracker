namespace TimeTracker.App.Domain.Extensions;

public static class FunctionalExtensions
{
    public static TOut Pipe<TIn, TOut>(this TIn source, Func<TIn, TOut> func) => func(source);
}
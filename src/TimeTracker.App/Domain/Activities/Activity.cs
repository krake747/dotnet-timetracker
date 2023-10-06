namespace TimeTracker.App.Domain.Activities;

public sealed class Activity
{
    public int Id { get; set; }
    public DateOnly Date { get; set; } 
    public double Hours { get; set; }
    public string Description { get; set; } = string.Empty;
}


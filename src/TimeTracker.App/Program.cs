using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Parsing;
using Dapper;
using TimeTracker.App;
using TimeTracker.App.Binders;
using TimeTracker.App.Infrastructure.Database;
using TimeTracker.App.Infrastructure.Database.SqliteTypeHandlers;

Console.WriteLine("Hello, TimeTracker App!");

const string timeTrackerDb = "TimeTracker.db";
const string databaseFolder = @"TimeTrackerApp\database";
var databaseFullPath = SetupOperations.CreateDatabasePath(databaseFolder, timeTrackerDb).Value;
SetupOperations.CreateLocalDbIfNotExists(databaseFullPath);

var connectionString = $"Data Source={databaseFullPath}";
var connectionFactory = new DbConnectionFactory(connectionString);
SetupOperations.InitializeDbTablesIfNotExists(connectionFactory);

// DI Binders

SqlMapper.AddTypeHandler(new DateOnlyHandler());
var activityRepositoryBinder = new ActivityRepositoryBinder(connectionFactory);
var systemDateTimeProviderBinder = new SystemDataTimeProviderBinder();

// Cli Setup

var hoursOption = new Option<double>("--time", "Time tracking (in hours)")
{
    IsRequired = true
};
hoursOption.AddAlias("-t");

var activityOption = new Option<string>("--activity", "Activity to track")
{
    IsRequired = true
};
activityOption.AddAlias("-a");

var rootCommand = new RootCommand("Crate a new time tracking activity")
{
    hoursOption,
    activityOption
};

rootCommand.SetHandler(MainOperations.CreateNewActivityHandler,
    activityRepositoryBinder,
    systemDateTimeProviderBinder,
    hoursOption,
    activityOption);

var commandLineBuilder = new CommandLineBuilder(rootCommand);

commandLineBuilder.AddMiddleware(async (context, next) => await next(context));

commandLineBuilder.UseDefaults();

var parser = commandLineBuilder.Build();

await parser.InvokeAsync(args);
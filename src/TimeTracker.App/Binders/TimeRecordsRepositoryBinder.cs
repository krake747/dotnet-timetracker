using System.CommandLine.Binding;
using TimeTracker.App.Infrastructure.Database;
using TimeTracker.App.Infrastructure.Repositories;

namespace TimeTracker.App.Binders;

internal sealed class ActivityRepositoryBinder(DbConnectionFactory factory) : BinderBase<ActivityRepository>
{ 
    protected override ActivityRepository GetBoundValue(BindingContext bindingContext) => new(factory);
}
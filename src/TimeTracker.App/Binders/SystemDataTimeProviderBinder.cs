using System.CommandLine.Binding;
using TimeTracker.App.Infrastructure.Common;

namespace TimeTracker.App.Binders;

internal sealed class SystemDataTimeProviderBinder : BinderBase<SystemDateTimeProvider>
{
    protected override SystemDateTimeProvider GetBoundValue(BindingContext bindingContext) => new();
}
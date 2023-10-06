using System.Data;
using static Dapper.SqlMapper;

namespace TimeTracker.App.Infrastructure.Database.SqliteTypeHandlers;

internal sealed class DateOnlyHandler : TypeHandler<DateOnly>
{
    public override void SetValue(IDbDataParameter parameter, DateOnly value) => parameter.Value = value.ToString("O");

    public override DateOnly Parse(object value) =>
        DateOnly.TryParse(value.ToString(), out var parsed) ? parsed : throw new Exception("DateOnly not parsed");
}
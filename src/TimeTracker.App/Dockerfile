﻿FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/TimeTracker.App/TimeTracker.App.csproj", "src/TimeTracker.App/"]
RUN dotnet restore "src/TimeTracker.App/TimeTracker.App.csproj"
COPY . .
WORKDIR "/src/src/TimeTracker.App"
RUN dotnet build "TimeTracker.App.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TimeTracker.App.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TimeTracker.App.dll"]

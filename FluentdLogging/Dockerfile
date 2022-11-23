FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["FluentdLogging/FluentdLogging.csproj", "FluentdLogging/"]
RUN dotnet restore "FluentdLogging/FluentdLogging.csproj"
COPY . .
WORKDIR "/src/FluentdLogging"
RUN dotnet build "FluentdLogging.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FluentdLogging.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FluentdLogging.dll"]
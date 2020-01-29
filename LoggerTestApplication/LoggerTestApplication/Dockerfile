FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["LoggerTestApplication/LoggerTestApplication.csproj", "LoggerTestApplication/"]
RUN dotnet restore "LoggerTestApplication/LoggerTestApplication.csproj"
COPY . .
WORKDIR "/src/LoggerTestApplication"
RUN dotnet build "LoggerTestApplication.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LoggerTestApplication.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LoggerTestApplication.dll"]
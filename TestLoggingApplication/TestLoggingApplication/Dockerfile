FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["TestLoggingApplication/TestLoggingApplication.csproj", "TestLoggingApplication/"]
RUN dotnet restore "TestLoggingApplication/TestLoggingApplication.csproj"
COPY . .
WORKDIR "/src/TestLoggingApplication"
RUN dotnet build "TestLoggingApplication.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "TestLoggingApplication.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TestLoggingApplication.dll"]
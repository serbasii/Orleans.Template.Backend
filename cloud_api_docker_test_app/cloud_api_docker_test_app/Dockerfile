FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["cloud_api_docker_test_app/cloud_api_docker_test_app.csproj", "cloud_api_docker_test_app/"]
RUN dotnet restore "cloud_api_docker_test_app/cloud_api_docker_test_app.csproj"
COPY . .
WORKDIR "/src/cloud_api_docker_test_app"
RUN dotnet build "cloud_api_docker_test_app.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "cloud_api_docker_test_app.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "cloud_api_docker_test_app.dll"]
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Cloud_Testing_App/Cloud_Testing_App.csproj", "Cloud_Testing_App/"]
RUN dotnet restore "Cloud_Testing_App/Cloud_Testing_App.csproj"
COPY . .
WORKDIR "/src/Cloud_Testing_App"
RUN dotnet build "Cloud_Testing_App.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Cloud_Testing_App.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Cloud_Testing_App.dll"]
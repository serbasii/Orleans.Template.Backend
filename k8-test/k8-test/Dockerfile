FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["k8-test/k8-test.csproj", "k8-test/"]
RUN dotnet restore "k8-test/k8-test.csproj"
COPY . .
WORKDIR "/src/k8-test"
RUN dotnet build "k8-test.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "k8-test.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "k8-test.dll"]
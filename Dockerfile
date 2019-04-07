FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

#FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
#WORKDIR /src
#COPY . /src
#COPY ["/Orleans.Example.Grains/Orleans.Example.Grains.csproj", "Orleans.Template/"]
#RUN nuget.exe restore Orleans.Example.Grains.csproj -SolutionDirectory ../ -Verbosity normal
#RUN dotnet restore "/Orleans.Example.Grains/Orleans.Example.Grains.csproj"
#COPY . .
#WORKDIR "/src/Orleans.Template"
#RUN dotnet build "Orleans.Example.Grains.csproj" -c Release -o /app

#FROM build AS publish
#RUN dotnet publish "Orleans.Example.Grains.csproj" -c Release -o /app


FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Orleans.Example.Silo", "Orleans.Template/"]
RUN dotnet restore "Orleans.Example.Silo.csproj"
COPY . .
WORKDIR "/src/Orleans.Template"
RUN dotnet build "Orleans.Example.Silo.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "/Orleans.Example.Silo/Orleans.Example.Silo.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Orleans.Template.Backend.dll"]

#COPY bin/Release/PublishOutput  /app/
#
#WORKDIR /app
#ENTRYPOINT ["dotnet", "/app/Orleans.Example.Silo.dll"]

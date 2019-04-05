FROM microsoft/netcoreapp2.2

COPY bin/Release/PublishOutput /app/

WORKDIR /app

ENTRYPOINT ["dotnet", "/app/orleans.template.silo.dll"]

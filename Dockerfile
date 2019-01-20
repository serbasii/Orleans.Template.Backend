FROM microsoft/aspnetcore:2.2

COPY bin/Release/PublishOutput  /app/

WORKDIR /app

ENTRYPOINT ["dotnet", "/app/orleans.template.silo.dll"]

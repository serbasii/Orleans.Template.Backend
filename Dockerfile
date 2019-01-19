FROM Orleans.Example.Silo\bin\Release\netcoreapp2.2
COPY bin/Release/PublishOutput  /app/
WORKDIR /app
ENTRYPOINT ["dotnet", "/app/Orleans.Example.Silo.dll"]

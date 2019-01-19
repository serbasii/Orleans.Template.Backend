FROM orleans.example.silo\bin\release\netcoreapp2.2
COPY bin/release/publishoutput  /app/
WORKDIR /app
ENTRYPOINT ["dotnet", "/app/orleans.example.silo.dll"]

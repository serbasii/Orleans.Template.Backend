FROM orleans.example.silo
COPY bin/release/publishoutput  /app/
WORKDIR /app
ENTRYPOINT ["dotnet", "/app/orleans.example.silo.dll"]

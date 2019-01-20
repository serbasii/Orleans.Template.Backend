FROM /app
COPY bin/release/publishoutput  /app/
WORKDIR /app
ENTRYPOINT ["dotnet", "/app/orleans.example.silo.dll"]

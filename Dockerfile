FROM /app/orleans.example.silo/bin
COPY bin/release/publishoutput  /app/
WORKDIR /app
ENTRYPOINT ["dotnet", "/app/orleans.example.silo.dll"]

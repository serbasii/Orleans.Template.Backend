FROM Orleans.Template.Backend
ADD publish/ /
ENTRYPOINT orleans.example.silo.exe

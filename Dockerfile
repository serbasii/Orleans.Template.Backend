FROM orleans.template.backend
ADD publish/ /
ENTRYPOINT orleans.example.silo.exe

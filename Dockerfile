FROM mcr.microsoft.com/dotnet/sdk:7.0.406-jammy-amd64 AS build-env

EXPOSE 80
EXPOSE 433
EXPOSE 8080
EXPOSE 5269

CMD [ "tail", "-f", "/dev/null" ]

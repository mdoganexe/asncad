FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY src/AscadWeb.Core/AscadWeb.Core.csproj AscadWeb.Core/
COPY src/AscadWeb.Infrastructure/AscadWeb.Infrastructure.csproj AscadWeb.Infrastructure/
COPY src/AscadWeb.Api/AscadWeb.Api.csproj AscadWeb.Api/
RUN dotnet restore AscadWeb.Api/AscadWeb.Api.csproj
COPY src/ .
RUN dotnet publish AscadWeb.Api/AscadWeb.Api.csproj -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app .
EXPOSE 8080
ENTRYPOINT ["dotnet", "AscadWeb.Api.dll"]

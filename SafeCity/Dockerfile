FROM mcr.microsoft.com/dotnet/sdk:3.1 AS base
ENV ASPNETCORE_URLS http://*:8090
WORKDIR /app
EXPOSE 8090

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY SafeCity.Server/SafeCity.Server.csproj SafeCity.Server/SafeCity.Server.csproj
COPY SafeCity.Server.Db/SafeCity.Server.Db.csproj SafeCity.Server.Db/SafeCity.Server.Db.csproj
COPY SafeCity.EmailSender/SafeCity.EmailSender.csproj SafeCity.EmailSender/SafeCity.EmailSender.csproj
COPY Model/Model.csproj Model/Model.csproj

RUN dotnet restore SafeCity.Server/SafeCity.Server.csproj
COPY . .
WORKDIR /src
RUN dotnet build SafeCity.Server/SafeCity.Server.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish SafeCity.Server/SafeCity.Server.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SafeCity.Server.dll"]
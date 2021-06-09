FROM mcr.microsoft.com/dotnet/sdk:3.1 AS base
ENV ASPNETCORE_URLS http://*:8080
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY SafeCity.UI.csproj SafeCity.UI/SafeCity.UI.csproj

RUN dotnet restore SafeCity.UI/SafeCity.UI.csproj
COPY . .
WORKDIR /src
RUN dotnet build SafeCity.UI/SafeCity.UI.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish SafeCity.UI/SafeCity.UI.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SafeCity.UI.dll"]
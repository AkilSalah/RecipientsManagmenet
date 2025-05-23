# Étape 1 : build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copie du csproj et restore
COPY *.csproj ./
RUN dotnet restore

# Copie du reste du code
COPY . ./
RUN dotnet publish -c Release -o out

# Étape 2 : runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

# Spécifier le port
ENV ASPNETCORE_URLS=http://+:10000
EXPOSE 10000

# Commande de démarrage
ENTRYPOINT ["dotnet", "Gestion_Destinataire.dll"]

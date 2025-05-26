# Étape de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Gestion_Destinataire.csproj", "."]
RUN dotnet restore "Gestion_Destinataire.csproj"
COPY . .
RUN dotnet build "Gestion_Destinataire.csproj" -c Release -o /app/build
RUN dotnet publish "Gestion_Destinataire.csproj" -c Release -o /app/publish

# Étape d'exécution
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

# Set environment variables
ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Production

EXPOSE 8080

ENTRYPOINT ["dotnet", "Gestion_Destinataire.dll"]
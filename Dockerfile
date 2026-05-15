# Etapa 1: Construcción
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copiamos el archivo de proyecto apuntando a la subcarpeta
COPY ["Bovix-Platform/Bovix-Platform.csproj", "Bovix-Platform/"]
RUN dotnet restore "Bovix-Platform/Bovix-Platform.csproj"

# Copiamos el resto de las carpetas y compilamos
COPY . .
WORKDIR "/src/Bovix-Platform"
RUN dotnet publish "Bovix-Platform.csproj" -c Release -o /app/publish

# Etapa 2: Servidor de producción
FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=build /app/publish .

# Exponemos el puerto de Render
ENV ASPNETCORE_HTTP_PORTS=8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "Bovix-Platform.dll"]

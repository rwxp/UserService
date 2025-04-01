# Imagen base para compilar la aplicación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar archivos de la solución y restaurar dependencias
COPY *.sln ./
COPY src/Core/*.csproj src/Core/
COPY src/Adapter.PostgreSQL/*.csproj src/Adapter.PostgreSQL/
COPY src/Adapter.Api/*.csproj src/Adapter.Api/

RUN dotnet restore src/Adapter.Api/Adapter.Api.csproj

# Copiar el código fuente y compilar en modo Release
COPY . .
RUN dotnet publish src/Adapter.Api/Adapter.Api.csproj -c Release -o /app/publish

# Imagen base para ejecutar la aplicación (runtime)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copiar los archivos publicados desde la etapa anterior
COPY --from=build /app/publish .

# Configurar la API como entrypoint
ENTRYPOINT ["dotnet", "Adapter.Api.dll"]

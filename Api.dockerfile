# Usa la imagen base de .NET 8 SDK
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Establece el directorio de trabajo
WORKDIR /app

# Copia los archivos de proyecto y restaura las dependencias
COPY API ./
RUN dotnet restore

# Copia el resto de los archivos y compila la aplicación
COPY . ./
RUN dotnet publish -c Release -o out

# Usa la imagen base de .NET 8 Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

# Establece el directorio de trabajo
WORKDIR /app

# Copia los archivos compilados desde la etapa de construcción
COPY --from=build /app/out .

# Expone el puerto en el que la aplicación escuchará
EXPOSE 7269

# Define el comando de entrada para ejecutar la aplicación
ENTRYPOINT ["dotnet", "API.dll

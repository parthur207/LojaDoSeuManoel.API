# Etapa base de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["LojaDoSeuManoel.API.csproj", "."]
RUN dotnet restore "LojaDoSeuManoel.API.csproj"
COPY . .
RUN dotnet build "LojaDoSeuManoel.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Etapa de publish
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "LojaDoSeuManoel.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Imagem final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LojaDoSeuManoel.API.dll"]

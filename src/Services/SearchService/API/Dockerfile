#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 7002

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Services/SearchService/API/API.csproj", "src/Services/SearchService/API/"]
COPY ["src/Services/SearchService/Application/Application.csproj", "src/Services/SearchService/Application/"]
COPY ["src/Services/SearchService/Domain/Domain.csproj", "src/Services/SearchService/Domain/"]
COPY ["src/Services/SearchService/Persistence/Persistence.csproj", "src/Services/SearchService/Persistence/"]
RUN dotnet restore "./src/Services/SearchService/API/API.csproj"
COPY . .
WORKDIR "/src/src/Services/SearchService/API"
RUN dotnet build "./API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API.dll"]
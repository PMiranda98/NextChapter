#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 7001

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Services/AuctionService/API/API.csproj", "src/Services/AuctionService/API/"]
COPY ["src/Services/AuctionService/Application/Application.csproj", "src/Services/AuctionService/Application/"]
COPY ["src/Services/AuctionService/Domain/Domain.csproj", "src/Services/AuctionService/Domain/"]
COPY ["src/Services/AuctionService/Persistence/Persistence.csproj", "src/Services/AuctionService/Persistence/"]
RUN dotnet restore "./src/Services/AuctionService/API/API.csproj"
COPY . .
WORKDIR "/src/src/Services/AuctionService/API"
RUN dotnet build "./API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API.dll"]
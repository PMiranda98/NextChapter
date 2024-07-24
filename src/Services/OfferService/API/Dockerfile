#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# Stage 1: Build the base runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 80

# Stage 2: Install the specific .NET SDK version and build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
# Copy the project file and restore dependencies
COPY ["src/Services/OfferService/API/API.csproj", "src/Services/OfferService/API/"]
COPY ["src/Services/OfferService/Application/Application.csproj", "src/Services/OfferService/Application/"]
COPY ["src/Services/OfferService/Domain/Domain.csproj", "src/Services/OfferService/Domain/"]
COPY ["src/Services/OfferService/Persistence/Persistence.csproj", "src/Services/OfferService/Persistence/"]
COPY ["src/Services/OfferService/Infrastructure/Infrastructure.csproj", "src/Services/OfferService/Infrastructure/"]
COPY ["src/EventBus/EventBus/EventBus.csproj", "src/EventBus/EventBus/"]
RUN dotnet restore "./src/Services/OfferService/API/API.csproj"
# Copy the remaining project files
COPY . .
# Build the project
WORKDIR "/src/src/Services/OfferService/API"
RUN dotnet build "./API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Stage 3: Publish the application
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Stage 4: Final image setup
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API.dll"]
#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# Stage 1: Build the base runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0.3 AS base
USER app
WORKDIR /app
EXPOSE 80

# Stage 2: Install the specific .NET SDK version and build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0.202 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
# Copy the project file and restore dependencies
COPY ["src/Services/IdentityService/Identity/Identity.csproj", "src/Services/IdentityService/Identity/"]
RUN dotnet restore "./src/Services/IdentityService/Identity/Identity.csproj"
# Copy the remaining project files
COPY . .
# Build the project
WORKDIR "/src/src/Services/IdentityService/Identity"
RUN dotnet build "./Identity.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Stage 3: Publish the application
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Identity.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Stage 4: Final image setup
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Identity.dll"]
#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# Stage 1: Build the base runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0.3 AS base
USER app
WORKDIR /app
EXPOSE 8080

# Stage 2: Install the specific .NET SDK version and build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0.202 AS build
ARG BUILD_CONFIGURATION=Release

# Ensure global.json is copied first to match SDK version
#COPY global.json ./
#RUN dotnet --list-sdks # Optional: check installed SDKs

# Install necessary tools (including jq)
#RUN apt-get update && \
#    apt-get install -y wget jq && \
#    apt-get clean && \
#    rm -rf /var/lib/apt/lists/*

# Install the specified .NET SDK version if not already present
#RUN apt-get update && \
#    apt-get install -y wget && \
#    SDK_VERSION=$(jq -r .sdk.version global.json) && \
#    wget https://dotnetcli.azureedge.net/dotnet/Sdk/$SDK_VERSION/dotnet-sdk-$SDK_VERSION-linux-x64.tar.gz && \
#    mkdir -p /usr/share/dotnet && \
#    tar -zxf dotnet-sdk-$SDK_VERSION-linux-x64.tar.gz -C /usr/share/dotnet && \
#    rm dotnet-sdk-$SDK_VERSION-linux-x64.tar.gz

# Remove existing symbolic link if it exists
#RUN rm -f /usr/bin/dotnet
# Create symbolic link to installed .NET SDK version
#RUN ln -s /usr/share/dotnet/dotnet /usr/bin/dotnet

WORKDIR /src
# Copy the project file and restore dependencies
COPY ["src/Services/GatewayService/GatewayService/GatewayService.csproj", "src/Services/GatewayService/GatewayService/"]
RUN dotnet restore "./src/Services/GatewayService/GatewayService/GatewayService.csproj"
# Copy the remaining project files
COPY . .
# Build the project
WORKDIR "/src/src/Services/GatewayService/GatewayService"
RUN dotnet build "./GatewayService.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Stage 3: Publish the application
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./GatewayService.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Stage 4: Final image setup
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GatewayService.dll"]
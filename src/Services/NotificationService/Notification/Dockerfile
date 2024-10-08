#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Services/NotificationService/Notification/Notification.csproj", "src/Services/NotificationService/Notification/"]
COPY ["src/Services/NotificationService/Infrastructure/Infrastructure.csproj", "src/Services/NotificationService/Infrastructure/"]
COPY ["src/EventBus/EventBus/EventBus.csproj", "src/EventBus/EventBus/"]
RUN dotnet restore "./src/Services/NotificationService/Notification/Notification.csproj"
COPY . .
WORKDIR "/src/src/Services/NotificationService/Notification"
RUN dotnet build "./Notification.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Notification.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Notification.dll"]
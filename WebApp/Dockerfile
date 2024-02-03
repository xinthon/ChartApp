#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["WebApp/WebApp.csproj", "WebApp/"]
COPY ["Modules.Auth.Infrastructure/Modules.Auth.Infrastructure.csproj", "Modules.Auth.Infrastructure/"]
COPY ["Modules.Auth.Application/Modules.Auth.Application.csproj", "Modules.Auth.Application/"]
COPY ["Modules.Auth.Domain/Modules.Auth.Domain.csproj", "Modules.Auth.Domain/"]
COPY ["Modules.Auth.Intergration/Modules.Auth.Intergration.csproj", "Modules.Auth.Intergration/"]
COPY ["SharedKhernel/SharedKhernel.csproj", "SharedKhernel/"]
RUN dotnet restore "./WebApp/./WebApp.csproj"
COPY . .
WORKDIR "/src/WebApp"
RUN dotnet build "./WebApp.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./WebApp.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApp.dll"]
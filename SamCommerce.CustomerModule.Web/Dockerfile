#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["SamCommerce.CustomerModule.Web/SamCommerce.CustomerModule.Web.csproj", "SamCommerce.CustomerModule.Web/"]
RUN dotnet restore "./SamCommerce.CustomerModule.Web/./SamCommerce.CustomerModule.Web.csproj"
COPY . .
WORKDIR "/src/SamCommerce.CustomerModule.Web"
RUN dotnet build "./SamCommerce.CustomerModule.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./SamCommerce.CustomerModule.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SamCommerce.CustomerModule.Web.dll"]
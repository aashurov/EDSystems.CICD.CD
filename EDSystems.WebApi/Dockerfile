#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["EDSystems.WebApi/EDSystems.WebApi.csproj", "EDSystems.WebApi/"]
COPY ["EDSystems.Application/EDSystems.Application.csproj", "EDSystems.Application/"]
COPY ["EDSystems.Domain/EDSystems.Domain.csproj", "EDSystems.Domain/"]
COPY ["EDSystems.Persistence/EDSystems.Persistence.csproj", "EDSystems.Persistence/"]
RUN dotnet restore "EDSystems.WebApi/EDSystems.WebApi.csproj"
COPY . .
WORKDIR "/src/EDSystems.WebApi"
RUN dotnet build "EDSystems.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EDSystems.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EDSystems.WebApi.dll"]
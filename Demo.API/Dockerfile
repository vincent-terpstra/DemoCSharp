﻿FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Demo.API/Demo.API.csproj", "Demo.API/"]
RUN dotnet restore "Demo.API/Demo.API.csproj"
COPY . .
WORKDIR "/src/Demo.API"
RUN dotnet build "Demo.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Demo.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Demo.API.dll"]

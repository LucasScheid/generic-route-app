#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["generic-route-app/generic-route-app.csproj", "generic-route-app/"]
RUN dotnet restore "generic-route-app/generic-route-app.csproj"
COPY . .
WORKDIR "/src/generic-route-app"
RUN dotnet build "generic-route-app.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "generic-route-app.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "generic-route-app.dll"]
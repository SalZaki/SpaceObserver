#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["SpaceObserver.ISS.Api.Host/SpaceObserver.ISS.Api.Host.csproj", "SpaceObserver.ISS.Api.Host/"]
RUN dotnet restore "SpaceObserver.ISS.Api.Host/SpaceObserver.ISS.Api.Host.csproj"
COPY . .
WORKDIR "/src/SpaceObserver.ISS.Api.Host"
RUN dotnet build "SpaceObserver.ISS.Api.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SpaceObserver.ISS.Api.Host.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SpaceObserver.ISS.Api.Host.dll"]
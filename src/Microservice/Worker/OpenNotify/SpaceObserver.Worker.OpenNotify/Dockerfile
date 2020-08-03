#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Microservice/Worker/OpenNotify/SpaceObserver.Worker.OpenNotify/SpaceObserver.Worker.OpenNotify.csproj", "src/Microservice/Worker/OpenNotify/SpaceObserver.Worker.OpenNotify/"]
RUN dotnet restore "src/Microservice/Worker/OpenNotify/SpaceObserver.Worker.OpenNotify/SpaceObserver.Worker.OpenNotify.csproj"
COPY . .
WORKDIR "/src/src/Microservice/Worker/OpenNotify/SpaceObserver.Worker.OpenNotify"
RUN dotnet build "SpaceObserver.Worker.OpenNotify.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SpaceObserver.Worker.OpenNotify.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SpaceObserver.Worker.OpenNotify.dll"]
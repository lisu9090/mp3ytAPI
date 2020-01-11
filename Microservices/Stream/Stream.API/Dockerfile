FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["Microservices/Stream/Stream.API/Stream.API.csproj", "Microservices/Stream/Stream.API/"]
RUN dotnet restore "Microservices/Stream/Stream.API/Stream.API.csproj"
COPY . .
WORKDIR "/src/Microservices/Stream/Stream.API"
RUN dotnet build "Stream.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Stream.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Stream.API.dll"]
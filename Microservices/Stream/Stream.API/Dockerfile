FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["Microservices/Stream/Stream.API/Stream.API.csproj", "Microservices/Stream/Stream.API/"]
COPY ["Core/APIComponents/APIComponents.csproj", "Core/APIComponents/"]
COPY ["Microservices/Stream/Stream.Domain/Stream.Domain.csproj", "Microservices/Stream/Stream.Domain/"]
COPY ["Core/Infrastructure/Infrastructure.csproj", "Core/Infrastructure/"]
COPY ["Microservices/Stream/Stream.Infrastructure/Stream.Infrastructure.csproj", "Microservices/Stream/Stream.Infrastructure/"]
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
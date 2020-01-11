FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["WebFront/AudioStreamer/AudioStreamer.csproj", "WebFront/AudioStreamer/"]
RUN dotnet restore "WebFront/AudioStreamer/AudioStreamer.csproj"
COPY . .
WORKDIR "/src/WebFront/AudioStreamer"
RUN dotnet build "AudioStreamer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AudioStreamer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AudioStreamer.dll"]
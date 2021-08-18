FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/FSharp/HeartBeats/HeartBeats.fsproj", "HeartBeats/"]
RUN dotnet restore "src/FSharp/HeartBeats/HeartBeats.fsproj"
COPY . .
WORKDIR "/src/HeartBeats"
RUN dotnet build "HeartBeats.fsproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HeartBeats.fsproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HeartBeats.dll"]

FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/CSharp/HeartBeats/HeartBeats.csproj", "HeartBeats/"]
RUN dotnet restore "src/CSharp/HeartBeats/HeartBeats.csproj"
COPY . .
WORKDIR "/src/HeartBeats"
RUN dotnet build "HeartBeats.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HeartBeats.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HeartBeats.dll"]

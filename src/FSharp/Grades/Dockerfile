FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/FSharp/FSharp.fsproj", "FSharp/"]
RUN dotnet restore "src/FSharp/FSharp.fsproj"
COPY . .
WORKDIR "/src/FSharp"
RUN dotnet build "FSharp.fsproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FSharp.fsproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FSharp.dll"]

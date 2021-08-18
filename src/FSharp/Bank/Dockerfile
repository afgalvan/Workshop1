FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/FSharp/Bank/Bank.fsproj", "Bank/"]
RUN dotnet restore "src/FSharp/Bank/Bank.fsproj"
COPY . .
WORKDIR "/src/Bank"
RUN dotnet build "Bank.fsproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Bank.fsproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Bank.dll"]

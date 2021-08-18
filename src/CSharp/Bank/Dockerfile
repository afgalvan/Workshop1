FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/CSharp/Bank/Bank.csproj", "Bank/"]
RUN dotnet restore "src/CSharp/Bank/Bank.csproj"
COPY . .
WORKDIR "/src/Bank"
RUN dotnet build "Bank.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Bank.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Bank.dll"]

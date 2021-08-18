FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/CSharp/CSharp.csproj", "CSharp/"]
RUN dotnet restore "src/CSharp/CSharp.csproj"
COPY . .
WORKDIR "/src/CSharp"
RUN dotnet build "CSharp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CSharp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CSharp.dll"]

FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/CSharpSkeleton/CSharpSkeleton.csproj", "CSharpSkeleton/"]
RUN dotnet restore "src/CSharpSkeleton/CSharpSkeleton.csproj"
COPY . .
WORKDIR "/src/CSharpSkeleton"
RUN dotnet build "CSharpSkeleton.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CSharpSkeleton.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CSharpSkeleton.dll"]

FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/CSharp/Grades/Grades.csproj", "Grades/"]
RUN dotnet restore "src/CSharp/Grades/Grades.csproj"
COPY . .
WORKDIR "/src/Grades"
RUN dotnet build "Grades.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Grades.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Grades.dll"]

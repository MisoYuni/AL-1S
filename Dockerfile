FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["AL-1S.csproj", "."]
RUN dotnet restore "./AL-1S.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "AL-1S.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AL-1S.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AL-1S.dll"]
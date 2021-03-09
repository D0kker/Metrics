#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["SonarAPI/SonarAPI.csproj", "SonarAPI/"]
RUN dotnet restore "SonarAPI/SonarAPI.csproj"
COPY . .
WORKDIR "/src/SonarAPI"
RUN dotnet build "SonarAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SonarAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SonarAPI.dll"]
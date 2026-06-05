FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Skilladd.API/Skilladd.API.csproj", "src/Skilladd.API/"]
COPY ["src/Skilladd.Application/Skilladd.Application.csproj", "src/Skilladd.Application/"]
COPY ["src/Skilladd.Domain/Skilladd.Domain.csproj", "src/Skilladd.Domain/"]
COPY ["src/Skilladd.Infrastructure/Skilladd.Infrastructure.csproj", "src/Skilladd.Infrastructure/"]
RUN dotnet restore "src/Skilladd.API/Skilladd.API.csproj"
COPY . .
WORKDIR "/src/src/Skilladd.API"
RUN dotnet build "./Skilladd.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Skilladd.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Skilladd.API.dll"]

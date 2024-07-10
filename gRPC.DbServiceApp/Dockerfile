FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["gRPC.DbServiceApp/gRPC.DbServiceApp.csproj", "gRPC.DbServiceApp/"]
RUN dotnet restore "gRPC.DbServiceApp/gRPC.DbServiceApp.csproj"
COPY . .
WORKDIR "/src/gRPC.DbServiceApp"
RUN dotnet build "gRPC.DbServiceApp.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "gRPC.DbServiceApp.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "gRPC.DbServiceApp.dll"]

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
ENV AuthenticationDb="Server=192.168.0.246,1433;Database=UserAPIDb;Trusted_Connection=false;TrustServerCertificate=True;User Id=sa;Password=Pa$$w0rd2019"


FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["UserAPI/UserAPI.csproj", "UserAPI/"]
COPY ["User.Infrastructure/User.Infrastructure.csproj", "User.Infrastructure/"]
COPY ["User.ApplicationCore/User.ApplicationCore.csproj", "User.ApplicationCore/"]
COPY ["JWTAuthenticationsManager/JWTAuthenticationsManager.csproj", "JWTAuthenticationsManager/"]
RUN dotnet restore "UserAPI/UserAPI.csproj"
COPY . .
WORKDIR "/src/UserAPI"
RUN dotnet build "UserAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UserAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UserAPI.dll"]

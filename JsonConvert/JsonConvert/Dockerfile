FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["JsonConvert/JsonConvert.csproj", "JsonConvert/"]
RUN dotnet restore "JsonConvert/JsonConvert.csproj"
COPY . .
WORKDIR "/src/JsonConvert"
RUN dotnet build "JsonConvert.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "JsonConvert.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "JsonConvert.dll"]

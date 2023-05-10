FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ReceiverNotificationApp/ReceiverNotificationApp.csproj", "ReceiverNotificationApp/"]
RUN dotnet restore "ReceiverNotificationApp/ReceiverNotificationApp.csproj"
COPY . .
WORKDIR "/src/ReceiverNotificationApp"
RUN dotnet build "ReceiverNotificationApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ReceiverNotificationApp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ReceiverNotificationApp.dll"]

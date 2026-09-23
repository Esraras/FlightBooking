# 1. Aşama: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 5182
ENV ASPNETCORE_URLS=http://+:5182

# 2. Aşama: Build & SDK
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ["FlightBooking.csproj", "./"]
RUN dotnet restore "FlightBooking.csproj"

COPY . .
RUN dotnet build "FlightBooking.csproj" -c Release -o /app/build

# 3. Aşama: Publish
FROM build AS publish
RUN dotnet publish "FlightBooking.csproj" -c Release -o /app/publish /p:UseAppHost=false

# 4. Aşama: Final
FROM base AS final
WORKDIR /app
EXPOSE 5182
ENV ASPNETCORE_ENVIRONMENT=Development
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FlightBooking.dll"]
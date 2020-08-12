FROM mcr.microsoft.com/dotnet/core/aspnet:3.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
WORKDIR /src
COPY ["MiniCarsales.API/MiniCarsales.API.csproj", "MiniCarsales.API/"]
RUN dotnet restore "MiniCarsales.API/MiniCarsales.API.csproj"
COPY . .
WORKDIR "/src/MiniCarsales.API"
RUN dotnet build "MiniCarsales.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MiniCarsales.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MiniCarsales.API.dll"]

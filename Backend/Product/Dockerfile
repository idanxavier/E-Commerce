FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ECommerceProductAPI.csproj", "."]
RUN dotnet restore "./ECommerceProductAPI.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "ECommerceProductAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ECommerceProductAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ECommerceProductAPI.dll"]
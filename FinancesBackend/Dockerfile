FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["FinancesBackend/FinancesBackend.csproj", "FinancesBackend/"]
RUN dotnet restore "FinancesBackend/FinancesBackend.csproj"
COPY . .
WORKDIR "/src/FinancesBackend"
RUN dotnet build "FinancesBackend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FinancesBackend.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FinancesBackend.dll"]

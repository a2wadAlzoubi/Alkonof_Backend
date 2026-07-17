# ============================
# Build Stage
# ============================

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

WORKDIR /src

COPY . .

RUN dotnet restore "src/Web/Web.csproj"

RUN dotnet publish "src/Web/Web.csproj" \
    -c Release \
    -o /app/publish \
    --no-restore


# ============================
# Runtime Stage
# ============================

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final

WORKDIR /app

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "Alkonof_Backend.Web.dll"]
# syntax=docker/dockerfile:1.7

# ==========================================================
# Stage 1 : Runtime
# ==========================================================
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base

WORKDIR /app

EXPOSE 8080
EXPOSE 8081

ENV ASPNETCORE_URLS=http://+:8080

# ==========================================================
# Stage 2 : Build
# ==========================================================
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

ARG BUILD_CONFIGURATION=Release

WORKDIR /src

# تحسين سرعة واستقرار NuGet
ENV NUGET_XMLDOC_MODE=skip \
    DOTNET_CLI_TELEMETRY_OPTOUT=1 \
    DOTNET_SKIP_FIRST_TIME_EXPERIENCE=1

# ----------------------------------------------------------
# Copy solution files
# ----------------------------------------------------------

COPY Alkonof_Backend.slnx ./
COPY Directory.Build.props ./
COPY Directory.Packages.props ./
COPY global.json ./

# إذا كان لديك NuGet.Config داخل المشروع فقم بإلغاء التعليق
# COPY NuGet.Config ./

# ----------------------------------------------------------
# Copy project files
# ----------------------------------------------------------

COPY src/Application/Application.csproj src/Application/
COPY src/Domain/Domain.csproj src/Domain/
COPY src/Infrastructure/Infrastructure.csproj src/Infrastructure/
COPY src/ServiceDefaults/ServiceDefaults.csproj src/ServiceDefaults/
COPY src/Shared/Shared.csproj src/Shared/
COPY src/Web/Web.csproj src/Web/

# ----------------------------------------------------------
# Restore
# ----------------------------------------------------------

RUN --mount=type=cache,target=/root/.nuget/packages \
    dotnet restore src/Web/Web.csproj \
    --disable-parallel

# ----------------------------------------------------------
# Copy source code
# ----------------------------------------------------------

COPY . .

WORKDIR /src/src/Web

# ----------------------------------------------------------
# Publish
# ----------------------------------------------------------

RUN dotnet publish \
    -c $BUILD_CONFIGURATION \
    -o /app/publish \
    --no-restore \
    /p:UseAppHost=false

# ==========================================================
# Stage 3 : Final
# ==========================================================

FROM base AS final

WORKDIR /app

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "Alkonof_Backend.Web.dll"]
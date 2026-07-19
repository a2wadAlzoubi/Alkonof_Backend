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


# تقليل الضوضاء وتحسين سلوك NuGet
ENV NUGET_XMLDOC_MODE=skip \
    DOTNET_CLI_TELEMETRY_OPTOUT=1 \
    DOTNET_SKIP_FIRST_TIME_EXPERIENCE=1


# ----------------------------------------------------------
# Copy complete solution
# ----------------------------------------------------------
# ننسخ المشروع كاملًا لضمان أن Restore يرى:
# - Directory.Packages.props
# - Directory.Build.props
# - جميع Project References
# - أي ملفات MSBuild إضافية
# ----------------------------------------------------------

COPY . .


# ----------------------------------------------------------
# Restore
# ----------------------------------------------------------

RUN dotnet restore src/Web/Web.csproj


# ----------------------------------------------------------
# Publish
# ----------------------------------------------------------

RUN dotnet publish src/Web/Web.csproj \
    -c $BUILD_CONFIGURATION \
    -o /app/publish \
    --no-restore \
    /p:UseAppHost=false



# ==========================================================
# Stage 3 : Final Runtime Image
# ==========================================================
FROM base AS final

WORKDIR /app


COPY --from=build /app/publish .


ENTRYPOINT ["dotnet", "Alkonof_Backend.Web.dll"]
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["CaseConversion.API/CaseConversion.API.csproj", "CaseConversion.API/"]
COPY ["CaseConversion.Lib/CaseConversion.Lib.csproj", "CaseConversion.Lib/"]
RUN dotnet restore "CaseConversion.API/CaseConversion.API.csproj"
COPY . .
WORKDIR "/src/CaseConversion.API"
RUN dotnet build "CaseConversion.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "CaseConversion.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CaseConversion.API.dll"]
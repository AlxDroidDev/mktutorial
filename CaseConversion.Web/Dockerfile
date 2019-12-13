FROM mcr.microsoft.com/dotnet/core/aspnet:2.2.7-alpine3.9 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2.402-alpine3.9 AS build
WORKDIR /src
ENV DOTNET_CLI_TELEMETRY_OPTOUT 1
COPY ["CaseConversion.Web.csproj", "CaseConversion.Web/"]
RUN dotnet restore "CaseConversion.Web/CaseConversion.Web.csproj"
COPY . CaseConversion.Web/
WORKDIR "/src/CaseConversion.Web"
RUN dotnet build "CaseConversion.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "CaseConversion.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CaseConversion.Web.dll"]
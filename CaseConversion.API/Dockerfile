FROM mcr.microsoft.com/dotnet/core/sdk:2.2.402-alpine3.9 AS build-env
WORKDIR /app

ENV DOTNET_CLI_TELEMETRY_OPTOUT 1

# copy csproj and restore as distinct layers
COPY CaseConversion.API.csproj .
RUN dotnet restore

# copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o /app

# build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2.7-alpine3.9 AS runtime
WORKDIR /app
COPY --from=build-env /app .
ENTRYPOINT ["dotnet", "CaseConversion.API.dll"]

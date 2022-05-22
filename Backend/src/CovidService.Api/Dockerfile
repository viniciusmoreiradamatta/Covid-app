#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Backend/src/CovidService.Api/CovidService.Api.csproj", "Backend/src/CovidService.Api/"]
COPY ["Backend/src/CovidService.Data/CovidService.Data.csproj", "Backend/src/CovidService.Data/"]
COPY ["Backend/src/CovidService.Domain/CovidService.Domain.csproj", "Backend/src/CovidService.Domain/"]
COPY ["Backend/src/CovidService.Application/CovidService.Application.csproj", "Backend/src/CovidService.Application/"]
RUN dotnet restore "Backend/src/CovidService.Api/CovidService.Api.csproj"
COPY . .
WORKDIR "/src/Backend/src/CovidService.Api"
RUN dotnet build "CovidService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CovidService.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CovidService.Api.dll"]
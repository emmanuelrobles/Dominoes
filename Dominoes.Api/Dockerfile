FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Dominoes.Api/Dominoes.Api.csproj", "Dominoes.Api/"]
RUN dotnet restore "Dominoes.Api/Dominoes.Api.csproj"
COPY . .
WORKDIR "/src/Dominoes.Api"
RUN dotnet build "Dominoes.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Dominoes.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Dominoes.Api.dll"]

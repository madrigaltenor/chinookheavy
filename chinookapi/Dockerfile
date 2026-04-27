FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 5036

ENV ASPNETCORE_URLS=http://+:5036

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["chinookapi/chinookapi.csproj", "chinookapi/"]
RUN dotnet restore "chinookapi/chinookapi.csproj"
COPY . .
WORKDIR "/src/chinookapi"
RUN dotnet build "chinookapi.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "chinookapi.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "chinookapi.dll"]

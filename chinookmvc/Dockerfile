FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 5222

ENV ASPNETCORE_URLS=http://+:5222

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["chinookmvc.csproj", "."]
RUN dotnet restore "chinookmvc.csproj"
COPY . .
WORKDIR "/src/chinookmvc"
RUN dotnet build "../chinookmvc.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "../chinookmvc.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "chinookmvc.dll"]

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["YourOSBB.Web/YourOSBB.Web.csproj", "YourOSBB.Web/"]
RUN dotnet restore "YourOSBB.Web/YourOSBB.Web.csproj"
COPY . .
WORKDIR "/src/YourOSBB.Web"
RUN dotnet build "YourOSBB.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "YourOSBB.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "YourOSBB.Web.dll"]

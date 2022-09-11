#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Nomis.Web.Client.Bsc/Nomis.Web.Client.Bsc.csproj", "src/Nomis.Web.Client.Bsc/"]
RUN dotnet restore "src/Nomis.Web.Client.Bsc/Nomis.Web.Client.Bsc.csproj"
COPY . .
WORKDIR "/src/src/Nomis.Web.Client.Bsc"
RUN dotnet build "Nomis.Web.Client.Bsc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Nomis.Web.Client.Bsc.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Nomis.Web.Client.Bsc.dll"]
#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["manageServer/manageServer.csproj", "manageServer/"]
COPY ["Service/Solid.Service.csproj", "Service/"]
COPY ["Solid.Core/Solid.Core.csproj", "Solid.Core/"]
COPY ["Solid/Solid.Data.csproj", "Solid/"]
RUN dotnet restore "manageServer/manageServer.csproj"
COPY . .
WORKDIR "/src/manageServer"
RUN dotnet build "manageServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "manageServer.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "manageServer.dll"]
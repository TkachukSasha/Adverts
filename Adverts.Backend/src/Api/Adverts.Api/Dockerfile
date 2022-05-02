#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Api/Adverts.Api/Adverts.Api.csproj", "src/Api/Adverts.Api/"]
COPY ["src/Application/Adverts.Application/Adverts.Application.csproj", "src/Application/Adverts.Application/"]
COPY ["src/Domain/Adverts.Domain/Adverts.Domain.csproj", "src/Domain/Adverts.Domain/"]
COPY ["src/Dal/Adverts.Dal/Adverts.Dal.csproj", "src/Dal/Adverts.Dal/"]
COPY ["src/Extensions/Adverts.Extensions/Adverts.Extensions.csproj", "src/Extensions/Adverts.Extensions/"]
RUN dotnet restore "src/Api/Adverts.Api/Adverts.Api.csproj"
COPY . .
WORKDIR "/src/src/Api/Adverts.Api"
RUN dotnet build "Adverts.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Adverts.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Adverts.Api.dll"]

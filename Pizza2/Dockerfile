#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Pizza2/Pizza2.csproj", "Pizza2/"]
COPY ["PizzaManager/PizzaManager.csproj", "PizzaManager/"]
RUN dotnet restore "Pizza2/Pizza2.csproj"
COPY . .
WORKDIR "/src/Pizza2"
RUN dotnet build "Pizza2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Pizza2.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Pizza2.dll"]
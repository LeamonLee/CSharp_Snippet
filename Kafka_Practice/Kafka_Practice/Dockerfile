#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Kafka_Practice/Kafka_Producer_Practice.csproj", "Kafka_Practice/"]
RUN dotnet restore "Kafka_Practice/Kafka_Producer_Practice.csproj"
COPY . .
WORKDIR "/src/Kafka_Practice"
RUN dotnet build "Kafka_Producer_Practice.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Kafka_Producer_Practice.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Kafka_Producer_Practice.dll"]
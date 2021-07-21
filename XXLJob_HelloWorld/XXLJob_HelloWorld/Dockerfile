#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["XXLJob_HelloWorld/XXLJob_HelloWorld.csproj", "XXLJob_HelloWorld/"]
COPY ["XxlJob.Executor/XxlJob.Executor.csproj", "XxlJob.Executor/"]
COPY ["XxlJob.Core/XxlJob.Core.csproj", "XxlJob.Core/"]
RUN dotnet restore "XXLJob_HelloWorld/XXLJob_HelloWorld.csproj"
COPY . .
WORKDIR "/src/XXLJob_HelloWorld"
RUN dotnet build "XXLJob_HelloWorld.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "XXLJob_HelloWorld.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "XXLJob_HelloWorld.dll"]
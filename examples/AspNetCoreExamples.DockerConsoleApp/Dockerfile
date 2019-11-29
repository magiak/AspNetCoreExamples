FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY . .
ENTRYPOINT ["dotnet", "run"]

# Multi stage docker file
#FROM mcr.microsoft.com/dotnet/core/runtime:3.0-buster-slim AS base
#WORKDIR /app
#
#FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
#WORKDIR /src
#COPY ["examples/AspNetCoreExamples.DockerConsoleApp/AspNetCoreExamples.DockerConsoleApp.csproj", "examples/AspNetCoreExamples.DockerConsoleApp/"]
#RUN dotnet restore "examples/AspNetCoreExamples.DockerConsoleApp/AspNetCoreExamples.DockerConsoleApp.csproj"
#COPY . .
#WORKDIR "/src/examples/AspNetCoreExamples.DockerConsoleApp"
#RUN dotnet build "AspNetCoreExamples.DockerConsoleApp.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "AspNetCoreExamples.DockerConsoleApp.csproj" -c Release -o /app/publish
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "AspNetCoreExamples.DockerConsoleApp.dll"]
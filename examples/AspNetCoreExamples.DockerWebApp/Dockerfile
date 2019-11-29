# build from command line
# C:\Users\lukas\Source\Repos\AspNetCoreExamples> docker build . -t dockerwebapp -f .\examples\AspNetCoreExamples.DockerWebApp\Dockerfile
FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["examples/AspNetCoreExamples.DockerWebApp/AspNetCoreExamples.DockerWebApp.csproj", "examples/AspNetCoreExamples.DockerWebApp/"]
RUN dotnet restore "examples/AspNetCoreExamples.DockerWebApp/AspNetCoreExamples.DockerWebApp.csproj"
COPY . .
WORKDIR "/src/examples/AspNetCoreExamples.DockerWebApp"
RUN dotnet build "AspNetCoreExamples.DockerWebApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AspNetCoreExamples.DockerWebApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AspNetCoreExamples.DockerWebApp.dll"]
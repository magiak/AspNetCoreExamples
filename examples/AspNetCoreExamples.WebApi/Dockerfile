FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["AspNetCoreExamples.WebApi/AspNetCoreExamples.WebApi.csproj", "AspNetCoreExamples.WebApi/"]
RUN dotnet restore "AspNetCoreExamples.WebApi/AspNetCoreExamples.WebApi.csproj"
COPY . .
WORKDIR "/src/AspNetCoreExamples.WebApi"
RUN dotnet build "AspNetCoreExamples.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AspNetCoreExamples.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AspNetCoreExamples.WebApi.dll"]
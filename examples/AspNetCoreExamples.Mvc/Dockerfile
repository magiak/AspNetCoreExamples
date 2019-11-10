FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["AspNetCoreExamples.Mvc/AspNetCoreExamples.Mvc.csproj", "AspNetCoreExamples.Mvc/"]
RUN dotnet restore "AspNetCoreExamples.Mvc/AspNetCoreExamples.Mvc.csproj"
COPY . .
WORKDIR "/src/AspNetCoreExamples.Mvc"
RUN dotnet build "AspNetCoreExamples.Mvc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AspNetCoreExamples.Mvc.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AspNetCoreExamples.Mvc.dll"]
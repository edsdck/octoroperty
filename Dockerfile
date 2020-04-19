FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /source

COPY . .

RUN dotnet restore octoroperty.sln

WORKDIR /source/Octo.Web/
RUN dotnet publish Octo.Web.csproj -c Release -o /app/published

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine as runtime
WORKDIR /app
COPY --from=build /app/published .

ENTRYPOINT ["dotnet", "Octo.Web.dll"]
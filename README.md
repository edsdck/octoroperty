# octoroperty
```dotnet ef migrations add HereGoesMigrationName --context octocontext -p ../Octo.Infrastructure/Octo.Infrastructure.csproj -s Octo.Web.csproj -o Data/Migrations```

```dotnet ef database update -c octocontext -p ../Octo.Infrastructure/Octo.Infrastructure.csproj -s Octo.Web.csproj```
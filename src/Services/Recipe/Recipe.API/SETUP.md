# Recipe API

### nuget package

- EntityFrameworkCore.Design
- EntityFrameworkCore
- Npgsql.EntityFrameworkCore
- Npgsql

### Model

- Convention class name:
> API_NameTable_Name.cs

### Infrastructure

1. create `context.cs`
   1. implement `: DbContext`
   2. init ctor
      1. param: `DbContextOptions<context.cs> options`
      2. `: base(options)`
   3. set `DbSet<ModelClassName>` ModelClassName + `s`
   4. ovveride `OnModelCreating`
      1. Custom `ApplyConfiguration` (new Class())
2. create folder `EntityConfigurations`
   1. Create class form `ApplyConfiguration`
   2. Extend use `: ITypeEntityConfigurations<ModelClassName>`
   3. Implement override interface
      1. builder toTable
      2. builder property
      3. builder relationship

3. implement use dbcontext in `startup.cs`
   1. add `AddDbContext<Context File>(options`
      `UseNpgsql(configuration.GetConnectionStrings("Context")`
   > appsetting json format for connect string
   
example:
   ```
      "ConnectionStrings": {
         "Context": "Host=;Database=;Username=;Password="
      }
   ```
      
   > var connecStr = configuration["ConnectionStrings:Context"]

4. Create `Migrations` folder
5. dotnet ef add migrations <name> --output-dir <folder>
6. dotnet ef database update

### Integrate EFCore vs Dapper

https://codewithmukesh.com/blog/using-entity-framework-core-and-dapper/


### IDbConnection Dapper

```
using (var connec = new NgqlConnection(<get connec from configuration>))
{

}
```

### Integrate with CQRS

https://alexcodetuts.com/2020/03/07/asp-net-core-3-1-repository-pattern-and-unit-of-work-using-dapper/




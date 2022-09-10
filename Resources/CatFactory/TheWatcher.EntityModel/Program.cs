using System.Dynamic;
using CatFactory.EntityFrameworkCore;
using CatFactory.ObjectRelationalMapping;
using CatFactory.SqlServer;
using CatFactory.SqlServer.CodeFactory;
using CatFactory.SqlServer.DatabaseObjectModel;
using CatFactory.SqlServer.ObjectRelationalMapping;

var db = SqlServerDatabase.CreateWithDefaults("TheWatcher");

db.AddDefaultTypeMapFor(typeof(string), "nvarchar");
db.AddDefaultTypeMapFor(typeof(DateTime), "datetime");

var resourceCategory = db
    .DefineEntity(new
    {
        Id = (short)0,
        Name = ""
    })
    .SetNaming("ResourceCategory")
    .SetColumnFor(e => e.Name, length: 100)
    .SetIdentity(e => e.Id)
    .SetPrimaryKey(e => e.Id)
    .AddUnique(e => e.Name)
    ;

var environment = db
    .DefineEntity(new
    {
        Id = (short)0,
        Name = ""
    })
    .SetNaming("Environment")
    .SetColumnFor(e => e.Name, length: 100)
    .SetIdentity(e => e.Id)
    .SetPrimaryKey(e => e.Id)
    ;

var resource = db
    .DefineEntity(new
    {
        Id = (short)0,
        Name = "",
        ResourceCategoryId = (short)0
    })
    .SetNaming("Resource")
    .SetColumnFor(e => e.Name, length: 100, nullable: true)
    .SetIdentity(e => e.Id)
    .SetPrimaryKey(e => e.Id)
    .AddForeignKey(e => e.ResourceCategoryId, resourceCategory.Table)
    ;

var resourceWatch = db
    .DefineEntity(new
    {
        Id = (short)0,
        ResourceId = (short)0,
        EnvironmentId = (short)0,
        Interval = 0,
        Description = ""
    })
    .SetNaming("ResourceWatch")
    .SetIdentity(e => e.Id)
    .SetPrimaryKey(e => e.Id)
    .AddUnique(e => new { e.ResourceId, e.EnvironmentId })
    .AddForeignKey(e => e.ResourceId, resource.Table)
    .AddForeignKey(e => e.EnvironmentId, environment.Table)
    ;

var resourceWatcherParameter = db
    .DefineEntity(new
    {
        Id = (short)0,
        ResourceId = (short)0,
        Parameter = "",
        Description = ""
    })
    .SetNaming("ResourceWatcherParameter")
    .SetColumnFor(e => e.Parameter, length: 100)
    .SetIdentity(e => e.Id)
    .SetPrimaryKey(e => e.Id)
    .AddUnique(e => new { e.ResourceId, e.Parameter })
    .AddForeignKey(e => e.ResourceId, resource.Table)
    ;

var watcher = db
    .DefineEntity(new
    {
        Id = (short)0,
        AssemblyQualifiedName = "",
        Name = "",
        Description = ""
    })
    .SetNaming("Watcher")
    .SetColumnFor(e => e.AssemblyQualifiedName, length: 511)
    .SetColumnFor(e => e.Name, length: 100)
    .SetIdentity(e => e.Id)
    .SetPrimaryKey(e => e.Id)
    .AddUnique(e => e.AssemblyQualifiedName)
    .AddUnique(e => e.Name)
    ;

var resourceWatcher = db
    .DefineEntity(new
    {
        Id = (short)0,
        ResourceId = (short)0,
        WatcherId = (short)0
    })
    .SetNaming("ResourceWatcher")
    .SetIdentity(e => e.Id)
    .SetPrimaryKey(e => e.Id)
    .AddUnique(e => new { e.ResourceId, e.WatcherId })
    .AddForeignKey(e => e.ResourceId, resource.Table)
    .AddForeignKey(e => e.WatcherId, watcher.Table)
    ;

dynamic importBag = new ExpandoObject();

importBag.ExtendedProperties = new List<ExtendedProperty>();

db.AddColumnForTables(new Column { Name = "Active", Type = "bit", ImportBag = importBag });
db.AddColumnForTables(new Column { Name = "CreationUser", Type = "nvarchar", Length = 50, ImportBag = importBag });
db.AddColumnForTables(new Column { Name = "CreationDateTime", Type = "datetime", ImportBag = importBag });
db.AddColumnForTables(new Column { Name = "LastUpdateUser", Type = "nvarchar", Length = 50, Nullable = true, ImportBag = importBag });
db.AddColumnForTables(new Column { Name = "LastUpdateDateTime", Type = "datetime", Nullable = true, ImportBag = importBag });
db.AddColumnForTables(new Column { Name = "Version", Type = "rowversion", Nullable = true, ImportBag = importBag });

SqlServerDatabaseScriptCodeBuilder.CreateScript(db, @"C:\Temp\Databases", true, true);

// Create instance of Entity Framework Core project
var project = EntityFrameworkCoreProject
    .CreateForV3x("Correos.Domain.Core", db, @"C:\Temp\TheWatcher.Domain.Core");

// Apply settings for Entity Framework Core project
project.GlobalSelection(settings =>
{
    settings.ForceOverwrite = true;
    settings.DeclareNavigationProperties = true;
    settings.DeclareNavigationPropertiesAsVirtual = true;
    settings.AddConfigurationForForeignKeysInFluentAPI = true;
});

// Build features for project, group all entities by schema into a feature
project.BuildFeatures();

// Scaffolding =^^=
project
    .ScaffoldDomain()
    ;

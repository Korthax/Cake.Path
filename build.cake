var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");
var version = Argument("version", "*");

Task("Clean")
    .Does(() =>
    {
        CleanDirectories("./artifacts/Cake.Path");
        CleanDirectories("./src/**/bin");
        CleanDirectories("./src/**/obj");
        CleanDirectories("./tests/**/bin");
        CleanDirectories("./tests/**/obj");
    });

Task("Restore")
    .IsDependentOn("Clean")
    .Does(() =>
    {
        var settings = new DotNetCoreRestoreSettings
        {
            Verbose = false
        };

        DotNetCoreRestore(settings);
    });

Task("BuildNet45")
    .IsDependentOn("Restore")
    .Does(() =>
    {
        var settings = new DotNetCoreBuildSettings
        {
            Configuration = configuration,
            Framework = "net45"
        };

        foreach(var file in GetFiles("./src/*/*.csproj"))
        {
            DotNetCoreBuild(file.ToString(), settings);
        }
    });

Task("BuildNetStandard1.6")
    .IsDependentOn("BuildNet45")
    .Does(() =>
    {
        var settings = new DotNetCoreBuildSettings
        {
            Configuration = configuration,
            Framework = "netstandard1.6"
        };

        foreach(var file in GetFiles("./src/*/*.csproj"))
        {
            DotNetCoreBuild(file.ToString(), settings);
        }
    });


Task("BuildNetCoreApp1.1")
    .IsDependentOn("BuildNetStandard1.6")
    .Does(() =>
    {
        var settings = new DotNetCoreBuildSettings
        {
            Configuration = "Debug",
            Framework = "netcoreapp1.1"
        };

        foreach(var file in GetFiles("./tests/*/*.csproj"))
        {
            DotNetCoreBuild(file.ToString(), settings);
        }
    });

Task("Test")
    .IsDependentOn("BuildNetCoreApp1.1")
    .Does(() =>
    {
        var settings = new DotNetCoreTestSettings
        {
            Configuration = "Debug"
        };

        foreach(var file in GetFiles("./tests/*/*.csproj"))
        {
            DotNetCoreTest(file.ToString(), settings);
        }
    });

Task("Pack")
    .IsDependentOn("Test")
    .Does(() =>
    {
        var settings = new DotNetCorePackSettings
        {
            Configuration = "Release",
            OutputDirectory = "./artifacts/Cake.Path"
        };

        DotNetCorePack("./src/Cake.Path/Cake.Path.csproj", settings);
    });

Task("Default")
    .IsDependentOn("Pack");

RunTarget(target);
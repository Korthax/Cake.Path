#r "src\Cake.Path\bin\Release\net45\Cake.Path.dll"

Task("TestAdd")
    .Does(() =>
    {
        AddToPath("C:\\test");
    });

Task("VerifyAdd")
    .IsDependentOn("TestAdd")
    .Does(() =>
    {
        ReloadPath();

        var path = EnvironmentVariable("PATH");
        if(!path.Contains(";C:/test")) {
            throw new Exception(string.Format("Add failed. Path was '{0}'", path)); 
        }
    });

Task("TestRemove")
    .IsDependentOn("VerifyAdd")
    .Does(() =>
    {
        RemoveFromPath("C:\\test");
    });

Task("VerifyRemove")
    .IsDependentOn("TestRemove")
    .Does(() =>
    {
        ReloadPath();

        var path = EnvironmentVariable("PATH");
        if(path.Contains(";C:/test")) {
            throw new Exception(string.Format("Remove failed. Path was '{0}'", path)); 
        }
    });

RunTarget("VerifyRemove");
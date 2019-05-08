var target = Argument("target", "Default");

Task("Build")
    .IsDependentOn("Restore")
    .Does(() =>
    {
        DotNetCoreBuild("./Microservices.API.csproj");
    });

Task("Restore")
    .IsDependentOn("Default")
    .Does(() =>
    {
        DotNetCoreRestore();
    });

Task("Default")
  .Does(() =>
{
  Information("Hello Microservices! I'm the TODO api");
});

RunTarget(target);
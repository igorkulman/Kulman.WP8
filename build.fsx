// include Fake lib
#r @"tools\FAKE\tools\FakeLib.dll"
open Fake
 
RestorePackages()

// Properties
let buildDir = @".\build\"
let testDir  = @".\test\"
let packagesDir = @".\packages"
let packagingRoot = "./packaging/"
let packagesVersion = "1.0.13"

// Targets
Target "Clean" (fun _ ->
    CleanDirs [buildDir; testDir; packagingRoot]
)

Target "Build" (fun _ ->
    !! @"Kulman.WP8\Kulman.WP8.csproj"
      |> MSBuildRelease buildDir "Build"
      |> Log "AppBuild-Output: "
)

Target "CreateNugetPackage" (fun _ ->    
    NuGet (fun p -> 
        {p with                  
            Project = "Kulman.WP8"          
            OutputPath = packagingRoot
            WorkingDir = buildDir
            Version = packagesVersion           
            Publish = true
            }) "Kulman.WP8.nuspec"
)

Target "Default" (fun _ ->
    trace "Build completed"
)

// Dependencies
"Clean"  
  ==> "Build"
  ==> "CreateNugetPackage"
  ==> "Default"
 
// start build
Run "Default"
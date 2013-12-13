#Different nuspec file for same c# project for ocotpus deploy

##Introduction
We still use branches during development we have use dev and rel branches. Every month we create a new branch from our dev branch. We want to use octopusdeploy for deploying our 
applications.  Because we use teamcity as our Ocotpus nuget repo we have only one place that contains the dev and release packages. 
So we want create different package for dev and rel branches four example the dev packages always have a prefix dev.<package>.  To create a package we use the octopack of ocotpus deploy

##How it works 
We defined a extra variable called PackageMode in our msbuild WebApp.Proj and when we set the packagemode to dev we will specify the nuspec file via the OctoPackNuSpecFileName
property of the octopack target

##Build package
###Build dev packages
```xml
msbuild .\OneProjectMultiNuSpecFiles.sln /p:configuration=release /p:RunOctoPack=true /p:VisualStudioVersion=12.0 /p:outdir=c:\temp\sampledev /p:PackageMode=Dev
```
###Build release packages
```xml
msbuild .\OneProjectMultiNuSpecFiles.sln /p:configuration=release /p:RunOctoPack=true /p:VisualStudioVersion=12.0 /p:outdir=c:\temp\samplerel /p:PackageMode=Release
```

$env:Path = '..\bin;%CD%'

nuget pack .\src\LeagueOfMonads\LeagueOfMonads.csproj -properties Configuration=Release -OutputDirectory .\release 
nuget pack .\src\LeagueOfMonads.Pcl\LeagueOfMonads.Pcl.csproj -properties Configuration=Release -OutputDirectory .\release

# visual studio builds the core guy automatically
Copy-Item -Path '.\src\LeagueOfMonads.Core\bin\Release\*.nupkg' -Destination '.\release'

$packages = Get-ChildItem -File -Path '.\release'

foreach ($package in $packages)
{
    nuget push $package $env:nuget_key -Source https://www.nuget.org/    
}
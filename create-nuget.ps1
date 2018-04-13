

nuget pack '.\src\LeagueOfMonads\LeagueOfMonads.csproj' -properties Configuration=Release -OutputDirectory '.\release '
nuget pack '.\src\LeagueOfMonads.Pcl\LeagueOfMonads.Pcl.csproj' -properties Configuration=Release -OutputDirectory '.\release'
# visual studio builds the core guy automatically
Copy-Item -Path '.\src\LeagueOfMonads.Core\bin\Release\*.nupkg' -Destination '.\release'

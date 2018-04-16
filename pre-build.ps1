
$old_version = '1.5.2.5'
$gnu_version = '1.5.2.6'
$files = ".\src\LeagueOfMonads.Core\LeagueOfMonads.Core.csproj", `
         ".\src\LeagueOfMonads.Shared\AssemblyInfo.cs"

Write-Host "APPLYING VERSION: " $gnu_version

foreach ($file in $files) { 
    (Get-Content $file).Replace($old_version, $gnu_version) | Set-Content $file 
}
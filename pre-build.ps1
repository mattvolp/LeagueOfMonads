
$old_version = '1.5.2.4'
$gnu_version = '1.5.2.5'
$files = ".\src\LeagueOfMonads.Core\LeagueOfMonads.Core.csproj", `
         ".\src\LeagueOfMonads.Core\Properties\AssemblyInfo.cs"

Write-Host "APPLYING VERSION: " $gnu_version

foreach ($file in $files) { 
    (Get-Content $file).Replace($old_version, $gnu_version) | Set-Content $file 
}
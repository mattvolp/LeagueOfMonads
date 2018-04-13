@ECHO off

SET VERSION=1.5.2.1
SET PATH=3rd\Ssed

ssed.exe "s/<Version>.*<\/Version>/<Version>%VERSION%<\/Version>/g" ".\src\LeagueOfMonads.Core\LeagueOfMonads.Core.csproj"
ssed.exe "s/Version\(.*\)/Version\(%VERSION%\)/g" ".\src\LeagueOfMonads.Core\Properties\AssemblyInfo.cs"

PAUSE

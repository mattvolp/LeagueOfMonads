@ECHO off

SET VERSION=1.5.2.1
SET PATH=3rd\Ssed

SET CSPROJ_BAK=".\src\LeagueOfMonads.Core\LeagueOfMonads.Core.csproj.bak"
SET ASSEMB_BAK=".\src\LeagueOfMonads.Core\Properties\AssemblyInfo.cs.bak"

IF EXIST %CSPROJ_BAK% DEL /F /Q %CSPROJ_BAK%
IF EXIST %ASSEMB_BAK% DEL /F /Q %ASSEMB_BAK%

ssed.exe -i.bak "s/<Version>.*<\/Version>/<Version>%VERSION%<\/Version>/g" ".\src\LeagueOfMonads.Core\LeagueOfMonads.Core.csproj"
ssed.exe -i.bak "s/Version\(.*\)/Version\(%VERSION%\)/g" ".\src\LeagueOfMonads.Core\Properties\AssemblyInfo.cs"

DEL /F /Q %CSPROJ_BAK%
DEL /F /Q %ASSEMB_BAK%

PAUSE

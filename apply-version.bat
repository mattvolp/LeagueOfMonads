@ECHO off

SET VERSION=1.5.2
SET PATH=3rd\Ploeh;3rd\Ssed

ECHO.
ECHO CURRENT VERSION: %VERSION%
ECHO.

Zero29.exe -a %VERSION%

IF EXIST ".\3rd\NuGet\LeagueOfMonads.nuspec.bak" del /F /Q ".\LeagueOfMonads.nuspec.bak"
IF EXIST ".\3rd\NuGet\LeagueOfMonads.Pcl.nuspec.bak" del /F /Q ".\LeagueOfMonads.Pcl.nuspec.bak"

IF EXIST ".\build-nuget.bat.bak" del /F /Q ".\build-nuget.bat.bak"
IF EXIST ".\build-nuget.bat.pcl.bak" del /F /Q ".\build-nuget-pcl.bat.bak"

IF EXIST ".\release.msbuild.bak" del /F /Q ".\release.msbuild.bak"

ssed.exe -i.bak "s/<version>.*<\/version>/<version>%VERSION%<\/version>/g" ".\3rd\NuGet\LeagueOfMonads.nuspec"
ssed.exe -i.bak "s/<version>.*<\/version>/<version>%VERSION%<\/version>/g" ".\3rd\NuGet\LeagueOfMonads.Pcl.nuspec"

ssed.exe -i.bak "s/LeagueOfMonads\..*\.nupkg/LeagueOfMonads\.%VERSION%\.nupkg/g" ".\build-nuget.bat"
ssed.exe -i.bak "s/LeagueOfMonads.Pcl\..*\.nupkg/LeagueOfMonads.Pcl\.%VERSION%\.nupkg/g" ".\build-nuget-pcl.bat"

ssed.exe -i.bak "s/LeagueOfMonads\..*\.zip/LeagueOfMonads\.%VERSION%\.zip/g" ".\build-all.msbuild"
ssed.exe -i.bak "s/LeagueOfMonads.Pcl\..*\.zip/LeagueOfMonads.Pcl\.%VERSION%\.zip/g" ".\build-all-pcl.msbuild"

DEL /F /Q ".\3rd\NuGet\LeagueOfMonads.nuspec.bak"
DEL /F /Q ".\3rd\NuGet\LeagueOfMonads.Pcl.nuspec.bak"

DEL /F /Q ".\build-nuget.bat.bak"
DEL /F /Q ".\build-nuget-pcl.bat.bak"

DEL /F /Q ".\build-all.msbuild.bak"
DEL /F /Q ".\build-all-pcl.msbuild.bak"

ECHO.
PAUSE

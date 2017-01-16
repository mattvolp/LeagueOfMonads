@echo off

SET PATH=.\3rd\NuGet
SET EnableNuGetPackageRestore=true

NuGet Update -self
NuGet Pack .\3rd\NuGet\LeagueOfMonads.nuspec -OutputDirectory .\Release

ECHO.
ECHO.

SET /p PUBLISH="Publish to NuGet (y/n): " %=%

ECHO.
ECHO.

IF "%PUBLISH%" == "y" (
	ECHO Publishing to Nuget...
	NuGet Push .\release\LeagueOfMonads.0.4.0.nupkg %NUGET_API_KEY_DRIVENDB% -Source https://www.nuget.org/
	ECHO "Publish complete."
) ELSE (
	ECHO "Publish cancelled."
)

ECHO.
ECHO.

PAUSE
@ECHO off

REM SET PATH=C:\Program Files (x86)\MSBuild\14.0\Bin;
SET PATH=C:\Program Files (x86)\Microsoft Visual Studio\2017\Enterprise\MSBuild\15.0\Bin

msbuild.exe build-all-pcl.msbuild

ECHO.
PAUSE

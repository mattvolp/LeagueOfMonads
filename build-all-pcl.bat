@ECHO off

SET PATH=C:\Program Files (x86)\MSBuild\14.0\Bin;

msbuild.exe build-all-pcl.msbuild

ECHO.
PAUSE

#!/bin/bash
set -e

function downloadSemrel() {
    curl -L -o release https://gitlab.com/juhani/go-semrel-gitlab/uploads/222a87259f6162c1a59c8586226f61cf/release
    chmod +x release    
    ./release -v
    export SEMVER=$(./release next-version)
    echo $SEMVER 
}

function downloadEzrep() {
    curl -L -o ezrep.tar.gz https://gitlab.com/adleatherwood/ezrep/uploads/d2d08afed4a63d8756df7b3fee94d7db/ezrep-0.2.0.tar.gz
    tar xf ezrep.tar.gz
    chmod +x ezrep
    ./ezrep process -c .ezrep.yml $SEMVER
}

function runTests() {
    cd ./src/LeagueOfMonads.Tests
    dotnet test
    cd ../..
}

function buildDebug() {
    cd ./src/LeagueOfMonads.Core
    dotnet build 
    cd ../..
}

function buildRelease() {    
    cd ./src/LeagueOfMonads.Core
    dotnet build -c Release
    cd ../..
}

function packageRelease() {    
    cd ./src/LeagueOfMonads.Core
    dotnet pack -c Release
    cd ../..
}

function publishRelease() {    
    cd ./src/LeagueOfMonads.Core/bin/Release
    NUGET_PKG=$(ls *.nupkg)
    echo $NUGET_PKG
    dotnet nuget push $NUGET_PKG -k $NUGET_KEY -s https://api.nuget.org/v3/index.json
    cd ../../../..
}

function tagRelease() {    
    ./release changelog
    ./release commit-and-tag \
        CHANGELOG.md \
        ./src/LeagueOfMonads.Core/LeagueOfMonads.Core.csproj \
        ./src/LeagueOfMonads.Shared/AssemblyInfo.cs
}

for arg in "$@"
do
    case "$arg" in 
        "download-semrel") downloadSemrel ;;
        "download-ezrep") downloadEzrep ;;
        "run-tests") runTests ;;
        "build-debug") buildDebug ;;
        "build-release") buildRelease ;;
        "package-release") packageRelease ;;
        "tag-release") tagRelease ;;
        "publish-release") publishRelease ;;
        *) echo "Command: '$arg' not understood!"; exit 1
    esac
done

#!/bin/bash
tar -xvzf zero29-core.tar.gz --overwrite

dotnet Zero29.Core.dll "$@"

rm -f FSharp.Core.dll
rm -f Zero29.Core.dll
rm -f Zero29.Core.runtimeconfig.json

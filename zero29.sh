#!/bin/bash
tar -xvzf zero29-core.tar.gz --overwrite &>/dev/null

dotnet Zero29.Core.dll "$@"

rm -f FSharp.Core.dll                    &>/dev/null
rm -f Zero29.Core.dll                    &>/dev/null
rm -f Zero29.Core.runtimeconfig.json     &>/dev/null

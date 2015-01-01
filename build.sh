#!/bin/sh
mono .nuget/NuGet.exe restore
xbuild /p:Configuration=Release

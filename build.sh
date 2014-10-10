#!/bin/sh
cd ./src
EnableNugetPackageRestore=true xbuild Msg.sln /p:Configuration=Release

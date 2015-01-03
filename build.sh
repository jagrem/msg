#!/bin/sh
NUGET=.nuget/NuGet.exe
NUNIT_VERSION=2.6.4

# NuGet package restore
mono $NUGET restore

# Build solution
xbuild /p:Configuration=Release

# Install NUnit test runner
mono $NUGET install NUnit.Runners -Version $NUNIT_VERSION -OutputDirectory packages

# Run tests
mono packages/NUnit.Runners.$NUNIT_VERSION/tools/nunit-console.exe */*/bin/Release/*.Specs.dll -nologo -noxml -nodots -labels
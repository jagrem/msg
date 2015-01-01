#!/bin/sh

# NuGet package restore
mono .nuget/NuGet.exe restore

# Build solution
xbuild /p:Configuration=Release

# Test
NUNIT_VERSION=2.6.4

# Install NUnit test runner
mono .nuget/NuGet.exe install NUnit.Runners -Version $NUNIT_VERSION -OutputDirectory packages

# Run tests
mono --runtime=v4.5 packages/NUnit.Runners.$NUNIT_VERSION/tools/nunit-console.exe */bin/Release/*.Specs.dll -nologo -noxml -nodots -labels
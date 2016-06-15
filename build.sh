#!/usr/bin/env bash

#exit if any command fails
set -e

artifactsFolder="./artifacts"

if [ -d $artifactsFolder ]; then  
  rm -R $artifactsFolder
fi

dotnet restore

dotnet test ./test/Piwik.Analytics.NetCore.Tests -c Release -f netcoreapp1.0

revision=${TRAVIS_JOB_ID:=1}  
revision=$(printf "%04d" $revision) 

dotnet pack ./src/Piwik.Analytics.NetCore -c Release -o ./artifacts --version-suffix=$revision
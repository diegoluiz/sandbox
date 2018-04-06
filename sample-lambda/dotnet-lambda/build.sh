#!/bin/bash

dotnet build
dotnet lambda package -c release -f netcoreapp1.0
serverless deploy --account $AWS_ACCOUNT


#!/bin/bash

clear

echo "Migration name:"
read ident

dotnet ef migrations add $ident --project AspNetCoreExamples.Mvc

read -n 1 -s #read key
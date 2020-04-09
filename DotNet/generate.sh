#!/bin/sh
find ../ConfigNode/ -iname *.cs > generate-cs.txt
sed "/.*Compile Include.*/d" -i ConfigNodeParser.csproj
sed "s/^/    <Compile Include=\"/g" -i generate-cs.txt
sed "s/$/\"\/>/g" -i generate-cs.txt
sed "/<ItemGroup>/r generate-cs.txt" -i ConfigNodeParser.csproj
rm generate-cs.txt

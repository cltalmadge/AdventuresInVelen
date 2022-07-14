#!/bin/bash
pushd content/ || exit
mkdir velen_content/
cp ./*.tlk velen_content
cp ./*.hak velen_content
zip -r velen_content.zip velen_content/
rm -rf velen_content
#rm ./*.tlk
#rm ./*.hak
popd || exit
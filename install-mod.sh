#!/bin/bash
# get dir from user
if [ $# -eq 0 ]; then
    echo "No directory specified."
    echo "Usage: $0 <directory>"
    exit 1
fi
# Set the directory to install to.
DIR=$1
# Make sure the directory isn't root.
if [ "$DIR" == "/" ]; then
    echo "Cannot install to root."
    exit 1
fi

# pushd mod/
pushd mod/ || exit
# Run pack-module.sh to create the mod file.
./pack-module.sh
# move mod to dir
mv ./*.mod "$DIR"
# popd mod/
popd || exit
#!/bin/bash
# This script will install the server files for the Velen server.
# Check if user has sudo privileges.
if [ "$(id -u)" -ne 0 ]; then
    echo "Due to some janky behavior with the build system, this script must be run as a privileged user. Run as sudo."
    exit 1
fi
# Get the directory to install to from the command line.
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
# Make sure the directory exists and create it if not
if [ ! -d "$DIR" ]; then
    echo "Directory $DIR does not exist."
    echo "Creating directory $DIR"
    mkdir -p "$DIR"
fi
# Verify directory created successfully
if [ ! -d "$DIR" ]; then
    echo "Failed to create directory $DIR. Ensure that you have permission to create the directory."
    exit 1
fi
# Make sure the directory is empty and clear it out if not.
if [ ! -z "$(ls -A $DIR)" ]; then
    echo "Directory $DIR is not empty."
    echo "Clearing directory $DIR"
    rm -rf "$DIR"/*
fi
# Make sure the directory is writable.
if [ ! -w "$DIR" ]; then
    echo "Directory $DIR is not writable. Is the path set to a restricted directory?"
    exit 1
fi

# Copy server contents to DIR
echo "Copying server contents to $DIR"
cp -r server/* "$DIR"

# create directory dir/live-server if it doesn't exist
if [ ! -d "$DIR/live-server" ]; then
    echo "Creating directory $DIR/live-server"
    mkdir -p "$DIR/live-server"
fi
# Create directory dir/live-server/hak if it doesn't exist
if [ ! -d "$DIR/live-server/hak" ]; then
    echo "Creating directory $DIR/live-server/hak"
    mkdir -p "$DIR/live-server/hak"
fi
# Create directory dir/live-server/tlk if it doesn't exist
if [ ! -d "$DIR/live-server/tlk" ]; then
    echo "Creating directory $DIR/live-server/tlk"
    mkdir -p "$DIR/live-server/tlk"
fi
# Create directory dir/live-server/mod if it doesn't exist
if [ ! -d "$DIR/live-server/mod" ]; then
    echo "Creating directory $DIR/live-server/modules"
    mkdir -p "$DIR/live-server/modules"
fi

dos2unix ./*.sh
dos2unix ./*/*.sh

# pack all targets with bundle-all.sh
echo "Packing all targets"
./bundle-all.sh
# copy velen_content.zip to DIR
echo "Copying velen_content.zip to $DIR"
cp content/velen_content.zip "$DIR"

# unzip velen_content.zip to DIR/
echo "Unzipping velen_content.zip to $DIR"
unzip -o "$DIR"/velen_content.zip -d "$DIR"
# Delete content/velen_content.zip
echo "Deleting velen_content.zip"
rm content/velen_content.zip

# Pack the module with mod/pack-module.sh
echo "Packing module"
# pushd to mod directory
pushd mod || exit
./pack-module.sh
# popd
popd || exit
# move mod/*.mod to DIR/live-server/mod
echo "Moving mod/*.mod to $DIR/live-server/modules"
mv mod/*.mod "$DIR/live-server/modules"
# pushd to DIR/
echo "Pushing to $DIR"
pushd "$DIR" || exit
# Move *.hak to live-server/hak
echo "Moving *.hak to live-server/hak"
mv ./*.hak live-server/hak
# Move *.tlk to live-server/tlk
echo "Moving *.tlk to live-server/tlk"
mv ./*.tlk live-server/tlk
# popd
popd || exit
# Finished!
echo "Finished!"
#!/bin/bash
pushd content/ || exit
dir=$1
# Exit if directory not exists
if [ ! -d "$dir" ]; then
    echo "Directory $dir does not exists"
    exit 1
fi
# Check if directory has tlk and hak directories
if [ ! -d "$dir/tlk" ] || [ ! -d "$dir/hak" ]; then
    echo "Invalid installation. Directory $dir does not have tlk and hak directories"
    exit 1
fi

mkdir velen_content/
docker run --rm -t -v $(pwd):/nasher -v $(pwd):"/root/.local/share/Neverwinter Nights/hak/" urothis/nwnee-community-images:nasher-8193.34 pack --clean --verbose --yes velen_2das
docker run --rm -t -v $(pwd):/nasher -v $(pwd):"/root/.local/share/Neverwinter Nights/hak/" urothis/nwnee-community-images:nasher-8193.34 pack --clean --verbose --yes velen_armors
docker run --rm -t -v $(pwd):/nasher -v $(pwd):"/root/.local/share/Neverwinter Nights/hak/" urothis/nwnee-community-images:nasher-8193.34 pack --clean --verbose --yes velen_core0
docker run --rm -t -v $(pwd):/nasher -v $(pwd):"/root/.local/share/Neverwinter Nights/hak/" urothis/nwnee-community-images:nasher-8193.34 pack --clean --verbose --yes velen_core1
docker run --rm -t -v $(pwd):/nasher -v $(pwd):"/root/.local/share/Neverwinter Nights/hak/" urothis/nwnee-community-images:nasher-8193.34 pack --clean --verbose --yes velen_core2
docker run --rm -t -v $(pwd):/nasher -v $(pwd):"/root/.local/share/Neverwinter Nights/hak/" urothis/nwnee-community-images:nasher-8193.34 pack --clean --verbose --yes velen_doors
docker run --rm -t -v $(pwd):/nasher -v $(pwd):"/root/.local/share/Neverwinter Nights/hak/" urothis/nwnee-community-images:nasher-8193.34 pack --clean --verbose --yes velen_facelift
docker run --rm -t -v $(pwd):/nasher -v $(pwd):"/root/.local/share/Neverwinter Nights/hak/" urothis/nwnee-community-images:nasher-8193.34 pack --clean --verbose --yes velen_phenos
docker run --rm -t -v $(pwd):/nasher -v $(pwd):"/root/.local/share/Neverwinter Nights/hak/" urothis/nwnee-community-images:nasher-8193.34 pack --clean --verbose --yes velen_portraits
docker run --rm -t -v $(pwd):/nasher -v $(pwd):"/root/.local/share/Neverwinter Nights/hak/" urothis/nwnee-community-images:nasher-8193.34 pack --clean --verbose --yes velen_reskins
docker run --rm -t -v $(pwd):/nasher -v $(pwd):"/root/.local/share/Neverwinter Nights/hak/" urothis/nwnee-community-images:nasher-8193.34 pack --clean --verbose --yes velen_skies
docker run --rm -t -v $(pwd):/nasher -v $(pwd):"/root/.local/share/Neverwinter Nights/hak/" urothis/nwnee-community-images:nasher-8193.34 pack --clean --verbose --yes velen_tiles
docker run --rm -t -v $(pwd):/nasher -v $(pwd):"/root/.local/share/Neverwinter Nights/hak/" urothis/nwnee-community-images:nasher-8193.34 pack --clean --verbose --yes velen_vfx
docker run --rm -t -v $(pwd):/nasher -v $(pwd):"/root/.local/share/Neverwinter Nights/tlk/" urothis/nwnee-community-images:nasher-8193.34 pack --clean --verbose --yes tlk
mv ./*.hak velen_content
mv velen.tlk velen_content
zip -r velen_content.zip velen_content/**
echo "Copying hak files to server..."
sudo cp -R velen_content/*.hak "$1/hak/"
echo "Copying tlk files to server..."
sudo cp -R velen_content/*.tlk "$1/tlk/"
rm -rf velen_content
popd || exit
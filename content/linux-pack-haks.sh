#!/bin/bash
pushd content
docker run --rm -t -v $(pwd):/nasher -v $(pwd):"/root/.local/share/Neverwinter Nights/hak/" urothis/nwnee-community-images:nasher-8193.34 pack --clean --verbose velen_top
docker run --rm -t -v $(pwd):/nasher -v $(pwd):"/root/.local/share/Neverwinter Nights/hak/" urothis/nwnee-community-images:nasher-8193.34 pack --clean --verbose velen_tiles8
docker run --rm -t -v $(pwd):/nasher -v $(pwd):"/root/.local/share/Neverwinter Nights/hak/" urothis/nwnee-community-images:nasher-8193.34 pack --clean --verbose velen_tiles7
docker run --rm -t -v $(pwd):/nasher -v $(pwd):"/root/.local/share/Neverwinter Nights/hak/" urothis/nwnee-community-images:nasher-8193.34 pack --clean --verbose velen_tiles6
docker run --rm -t -v $(pwd):/nasher -v $(pwd):"/root/.local/share/Neverwinter Nights/hak/" urothis/nwnee-community-images:nasher-8193.34 pack --clean --verbose velen_tiles5
docker run --rm -t -v $(pwd):/nasher -v $(pwd):"/root/.local/share/Neverwinter Nights/hak/" urothis/nwnee-community-images:nasher-8193.34 pack --clean --verbose velen_tiles4
docker run --rm -t -v $(pwd):/nasher -v $(pwd):"/root/.local/share/Neverwinter Nights/hak/" urothis/nwnee-community-images:nasher-8193.34 pack --clean --verbose velen_tiles3
docker run --rm -t -v $(pwd):/nasher -v $(pwd):"/root/.local/share/Neverwinter Nights/hak/" urothis/nwnee-community-images:nasher-8193.34 pack --clean --verbose velen_tiles2
docker run --rm -t -v $(pwd):/nasher -v $(pwd):"/root/.local/share/Neverwinter Nights/hak/" urothis/nwnee-community-images:nasher-8193.34 pack --clean --verbose velen_tiles1
docker run --rm -t -v $(pwd):/nasher -v $(pwd):"/root/.local/share/Neverwinter Nights/hak/" urothis/nwnee-community-images:nasher-8193.34 pack --clean --verbose velen_robe
docker run --rm -t -v $(pwd):/nasher -v $(pwd):"/root/.local/share/Neverwinter Nights/hak/" urothis/nwnee-community-images:nasher-8193.34 pack --clean --verbose velen_plcs 
docker run --rm -t -v $(pwd):/nasher -v $(pwd):"/root/.local/share/Neverwinter Nights/hak/" urothis/nwnee-community-images:nasher-8193.34 pack --clean --verbose velen_cont
docker run --rm -t -v $(pwd):/nasher -v $(pwd):"/root/.local/share/Neverwinter Nights/hak/" urothis/nwnee-community-images:nasher-8193.34 pack --clean --verbose velen_ccoh
docker run --rm -t -v $(pwd):/nasher -v $(pwd):"/root/.local/share/Neverwinter Nights/hak/" urothis/nwnee-community-images:nasher-8193.34 pack --clean --verbose velen_anim
popd
#!/bin/bash
pushd content/ || exit
mkdir velen_content/
docker run --rm -t -v $(pwd):/nasher -v $(pwd):"/root/.local/share/Neverwinter Nights/hak/" urothis/nwnee-community-images:nasher-8193.34 pack --clean --verbose --yes velen_top
mv velen_top.hak velen_content 
docker run --rm -t -v $(pwd):/nasher -v $(pwd):"/root/.local/share/Neverwinter Nights/hak/" urothis/nwnee-community-images:nasher-8193.34 pack --clean --verbose --yes velen_tiles8
mv velen_tiles8.hak velen_content
docker run --rm -t -v $(pwd):/nasher -v $(pwd):"/root/.local/share/Neverwinter Nights/hak/" urothis/nwnee-community-images:nasher-8193.34 pack --clean --verbose --yes velen_tiles7
mv velen_tiles7.hak velen_content
docker run --rm -t -v $(pwd):/nasher -v $(pwd):"/root/.local/share/Neverwinter Nights/hak/" urothis/nwnee-community-images:nasher-8193.34 pack --clean --verbose --yes velen_tiles6
mv velen_tiles6.hak velen_content
docker run --rm -t -v $(pwd):/nasher -v $(pwd):"/root/.local/share/Neverwinter Nights/hak/" urothis/nwnee-community-images:nasher-8193.34 pack --clean --verbose --yes velen_tiles5
mv velen_tiles5.hak velen_content
docker run --rm -t -v $(pwd):/nasher -v $(pwd):"/root/.local/share/Neverwinter Nights/hak/" urothis/nwnee-community-images:nasher-8193.34 pack --clean --verbose --yes velen_tiles4
mv velen_tiles4.hak velen_content
docker run --rm -t -v $(pwd):/nasher -v $(pwd):"/root/.local/share/Neverwinter Nights/hak/" urothis/nwnee-community-images:nasher-8193.34 pack --clean --verbose --yes velen_tiles3
mv velen_tiles3.hak velen_content
docker run --rm -t -v $(pwd):/nasher -v $(pwd):"/root/.local/share/Neverwinter Nights/hak/" urothis/nwnee-community-images:nasher-8193.34 pack --clean --verbose --yes velen_tiles2
mv velen_tiles2.hak velen_content
docker run --rm -t -v $(pwd):/nasher -v $(pwd):"/root/.local/share/Neverwinter Nights/hak/" urothis/nwnee-community-images:nasher-8193.34 pack --clean --verbose --yes velen_tiles1
mv velen_tiles1.hak velen_content
docker run --rm -t -v $(pwd):/nasher -v $(pwd):"/root/.local/share/Neverwinter Nights/hak/" urothis/nwnee-community-images:nasher-8193.34 pack --clean --verbose --yes velen_robe
mv velen_robe.hak velen_content
docker run --rm -t -v $(pwd):/nasher -v $(pwd):"/root/.local/share/Neverwinter Nights/hak/" urothis/nwnee-community-images:nasher-8193.34 pack --clean --verbose --yes velen_plcs
mv velen_plcs.hak velen_content 
docker run --rm -t -v $(pwd):/nasher -v $(pwd):"/root/.local/share/Neverwinter Nights/hak/" urothis/nwnee-community-images:nasher-8193.34 pack --clean --verbose --yes velen_cont
mv velen_cont.hak velen_content
docker run --rm -t -v $(pwd):/nasher -v $(pwd):"/root/.local/share/Neverwinter Nights/hak/" urothis/nwnee-community-images:nasher-8193.34 pack --clean --verbose --yes velen_ccoh
mv velen_ccoh.hak velen_content
docker run --rm -t -v $(pwd):/nasher -v $(pwd):"/root/.local/share/Neverwinter Nights/hak/" urothis/nwnee-community-images:nasher-8193.34 pack --clean --verbose --yes velen_anim
mv velen_anim.hak velen_content
docker run --rm -t -v $(pwd):/nasher -v $(pwd):"/root/.local/share/Neverwinter Nights/tlk/" urothis/nwnee-community-images:nasher-8193.34 pack --clean --verbose --yes tlk
mv velen.tlk velen_content
zip -r velen_content.zip velen_content/
#rm -rf velen_content
popd || exit
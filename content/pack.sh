#!/bin/bash
pushd content
docker run --rm -t -v $(pwd):/nasher -v $(pwd):"/root/.local/share/Neverwinter Nights/$2/" urothis/nwnee-community-images:nasher-8193.34 pack --clean --verbose --yes $2
popd
#!/bin/bash
pushd content
docker run --rm -it -v $(pwd):/nasher -v $(pwd):"/root/.local/share/Neverwinter Nights/$2/" urothis/nwnee-community-images:nasher-8193.34 unpack --clean --verbose $2
popd
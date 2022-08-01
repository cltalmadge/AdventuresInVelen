#!/bin/bash
docker run --rm -t -v $(pwd):/nasher -v $(pwd):"/root/.local/share/Neverwinter Nights/modules/" urothis/nwnee-community-images:nasher-8193.34 unpack --clean --verbose --yes

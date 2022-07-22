#!/bin/bash
# Get the directory the script file is in.
SCRIPTDIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )"
pushd "$SCRIPTDIR" || exit
docker run --rm -t -v $(pwd):/nasher urothis/nwnee-community-images:nasher-8193.34 pack --clean --verbose --yes
popd || exit
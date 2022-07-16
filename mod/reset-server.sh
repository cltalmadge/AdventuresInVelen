#!/bin/bash
pushd /home/zoltan/velen_mod || exit
docker-compose down
docker-compose up -d
popd || exit
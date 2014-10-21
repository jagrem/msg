#!/bin/sh
sudo add-apt-repository ppa:directhex/monoxide
sudo apt-get install mono-devel mono-gmcs
cd ./src
xbuild Msg.sln /p:Configuration=Release

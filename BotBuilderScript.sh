#!/bin/bash
MY_PATH="`dirname \"$0\"`"              # relative
MY_PATH="`( cd \"$MY_PATH\" && pwd )`"  # absolutized and normalized
if [ -z "$MY_PATH" ] ; then
  # error; for some reason, the path is not accessible
  # to the script (e.g. permissions re-evaled after suid)
  exit 1  # fail
fi
xbuild /p:Configuration=Release /p:UseInteropDll=false /p:UseSqliteStandard=true $MY_PATH/SQlitesrc/System.Data.SQLite/System.Data.SQLite.2013.csproj;
xbuild /p:Configuration=Release /p:UserInteropDll=false /p:UseSqliteStandard=true $MY_PATH/DeathmicChatbot/DeathmicChatbot.csproj;
cp $MY_PATH/SQlitesrc/bin/2013/Release/bin/System.Data.SQLite.dll $MY_PATH/DeathmicChatbot/bin/Release

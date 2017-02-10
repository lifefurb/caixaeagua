#!/bin/sh
LD_LIBRARY_PATH=/home/mint/Qt/5.6/Src/qtbase/lib${LD_LIBRARY_PATH:+:$LD_LIBRARY_PATH}
export LD_LIBRARY_PATH
QT_PLUGIN_PATH=/home/mint/Qt/5.6/Src/qtbase/plugins${QT_PLUGIN_PATH:+:$QT_PLUGIN_PATH}
export QT_PLUGIN_PATH
exec /home/mint/Qt/5.6/Src/qtbase/bin/uic "$@"

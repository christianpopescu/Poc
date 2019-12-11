#usr/bin/bash
g++ -std=c++17 UIMain.cc MainWindow.cc MainApplication.cc -o UIMain.exe  $(pkg-config gtkmm-3.0 --cflags --libs | sed 's/ -I/ -isystem /g')

TEMPLATE = app
TARGET = simpleappwithoutQt

QT = core gui

greaterThan(QT_MAJOR_VERSION, 4): QT += widgets

SOURCES +=  main.cpp
HEADERS += window.h
SOURCES += window.cpp
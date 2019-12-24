#include "window.h"
#include <QTextEdit>

Window::Window(QWidget *parent) :
 QWidget(parent)
 {
 // Set size of the window
 setFixedSize(300, 250);

 // Create and position the button
 m_textEdit = new QTextEdit("Hello World", this);
 m_textEdit->setGeometry(10, 10, 100, 50);
 m_textEdit2 = new QTextEdit("Second text", this);
 m_textEdit2->setGeometry(10, 70, 100, 50);
 
}

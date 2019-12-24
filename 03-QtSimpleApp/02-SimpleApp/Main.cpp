#include <QApplication>
#include <QPushButton>
#include <QTextEdit>

int main(int argc, char **argv)
{
 QApplication app (argc, argv);

// QPushButton button ("Hello world !");
// button.show();
 QTextEdit textEdit("My Text");
 textEdit.show();

 return app.exec();
}

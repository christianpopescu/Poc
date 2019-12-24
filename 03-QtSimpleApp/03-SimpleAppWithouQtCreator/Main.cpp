#include <QApplication>
#include <QColor>
#include <QTextEdit>

int main(int argc, char **argv)
{
 QApplication app (argc, argv);

 QTextEdit textEdit("My Text in text edit");
 textEdit.show();

 return app.exec();
}

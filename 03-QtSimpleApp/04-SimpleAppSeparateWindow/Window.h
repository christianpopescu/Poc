#ifndef WINDOW_H
#define WINDOW_H

#include <QWidget>

class QTextEdit;
class Window : public QWidget
{
 public:
  explicit Window(QWidget *parent = 0);
 private:
 QTextEdit *m_textEdit;
 QTextEdit *m_textEdit2;
};

#endif // WINDOW_H

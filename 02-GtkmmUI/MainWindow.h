#ifndef MAIN_WINDOW_H
#define MAIN_WINDOW_H

#include <gtkmm/button.h>
#include <gtkmm/window.h>

class MainWindow : public Gtk::Window {
 public :
  MainWindow();
  virtual ~MainWindow();
 protected:
  // Signal handlers:
   void on_button_clicked();

  // Member widgets:
    Gtk::Button m_button;
};
#endif  //  MAIN_WINDOW_H

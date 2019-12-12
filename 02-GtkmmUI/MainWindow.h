#ifndef MAIN_WINDOW_H
#define MAIN_WINDOW_H

#include <gtkmm/button.h>
#include <gtkmm/window.h>
#include <gtkmm/box.h>
#include <gtkmm/entry.h>

class MainWindow : public Gtk::Window {
 public :
  MainWindow();
  virtual ~MainWindow();
 protected:
  // Signal handlers:
   void on_button_clicked();
  void on_button_action();

  //Container widget
  Gtk::Box m_box;
  
  // Member widgets:
  Gtk::Button m_button;
  Gtk::Button m_button_action;
  Gtk::Entry m_Entry;
};
#endif  //  MAIN_WINDOW_H

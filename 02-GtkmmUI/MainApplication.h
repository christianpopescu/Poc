#ifndef MAIN_APPLICATION_H
#define MAIN_APPLICATION_H

#include <gtkmm/application.h>
#include <string>
#include "MainWindow.h"

class MainApplication {
 public:
  
  MainApplication() = delete;
  MainApplication(int argc, char** argv, std::string message);
  int Run();
 private:
  //   MainWindow mainWindow;
  Glib::RefPtr<Gtk::Application> app;
};

#endif

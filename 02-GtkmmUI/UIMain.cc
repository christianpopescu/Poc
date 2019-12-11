#include "MainApplication.h"
#include "MainWindow.h"
#include <gtkmm/application.h>

int main (int argc, char *argv[])
{
  /*   Glib::RefPtr<Gtk::Application>  app = Gtk::Application::create(argc, argv, "org.gtkmm.example");

  MainWindow mainWindow;

  //Shows the window and returns when it is closed.
  return app->run(mainWindow);
  */
  MainApplication mainApplication(argc, argv, "org.gtkmm.example");
  mainApplication.Run();
  return 0;

}

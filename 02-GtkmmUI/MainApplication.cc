#include "MainApplication.h"
#include "MainWindow.h"

MainApplication::MainApplication(int argc, char** argv, std::string message){
  app = Gtk::Application::create(argc, argv, message);
}

int MainApplication::Run(){
  return app->run(mainWindow);
}

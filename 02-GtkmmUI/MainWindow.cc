#include "MainWindow.h"
#include <iostream>

MainWindow::MainWindow()
  : m_button("Hello World!"),
    m_button_action("Action now!"){
  // Sets the border width of the window
   set_border_width(15);


   // When the button receives the "clicked" signal, it will call the
  // following method
   m_button.signal_clicked().connect(sigc::mem_fun(*this,
						  &MainWindow::on_button_clicked));
   m_button_action.signal_clicked().connect(sigc::mem_fun(*this,
						  &MainWindow::on_button_action));

  
   add(m_box);  
  // Packs the button into the Window (a container).
  m_box.pack_start(m_button);
  m_button.show();
  
  m_box.pack_start(m_button_action);
  m_button_action.show();

  m_box.show();
}

MainWindow::~MainWindow(){
}

void MainWindow::on_button_clicked() {
  std::cout << "Hello world!" << std::endl;
}

void MainWindow::on_button_action() {
  std::cout << "Action button" << std::endl;
}


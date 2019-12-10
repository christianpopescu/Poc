#include "MainWindow.h"
#include <iostream>

MainWindow::MainWindow()
  : m_button("Hello World!") {
  // Sets the border width of the window
  set_border_width(15);

  // When the button receives the "clicked" signal, it will call the
  // following method
  m_button.signal_clicked().connect(sigc::mem_fun(*this,
						  &MainWindow::on_button_clicked));

  // Packs the button into the Window (a container).
  add(m_button);

  // Dispalay the newly created widget ...
  m_button.show();
}

MainWindow::~MainWindow(){
}

void MainWindow::on_button_clicked() {
  std::cout << "Hello world!" << std::endl;
}
    

#include "MainWindow.h"

void MainWindow::OnInitialized(EventArgs^ e)  
{
    Window::OnInitialized(e);   // Important to call
    this->Title = "Code Only Window";
    this->Background = System::Windows::Media::Brushes::White;
    Button^ closeButton = gcnew Button();
    closeButton->Content = "Close";
    closeButton->Background = System::Windows::Media::Brushes::Blue;
    this->Content = closeButton;
//    closeButton->Click += delegate{
//      this.Close();
closeButton->Click += gcnew System::Windows::RoutedEventHandler(this, &MainWindow::CloseWindow);

}

void MainWindow::CloseWindow(System::Object^ sender, System::Windows::RoutedEventArgs^ e)
{
    this->Close();
}

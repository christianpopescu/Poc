#include "MainWindow.h"

void MainWindow::OnInitialized(EventArgs^ e)  
{
    Window::OnInitialized(e);   // Important to call
    this->Title = "Code Only Window";
    this->Background = System::Windows::Media::Brushes::Gray;
    
    this->closeButton = gcnew Button();
    closeButton->Content = "Close";
    closeButton->Background = System::Windows::Media::Brushes::Blue;
    closeButton->Width = 100;
    closeButton->Height = 50;

//    closeButton->Click += delegate{
//      this.Close();
    closeButton->Click += gcnew System::Windows::RoutedEventHandler(this, &MainWindow::CloseWindow);
 
    this->tb = gcnew TextBox();
    tb->Text = "this is a text box";
    tb->Visibility = System::Windows::Visibility::Visible;
    tb->Width = 300;
    tb-> Height = 50;
    tb->Background = System::Windows::Media::Brushes::Blue;
    tb->HorizontalAlignment = System::Windows::HorizontalAlignment::Center;
    
    canvas = gcnew Canvas();
 //   canvas->Height = 300;
 //   canvas->Width = 500;
    canvas->Background = System::Windows::Media::Brushes::LightGray;

    canvas->Children->Add(closeButton);
    canvas->Children->Add(tb);
    canvas->SetLeft(tb, 400);
    this->Content = canvas;
}

void MainWindow::CloseWindow(System::Object^ sender, System::Windows::RoutedEventArgs^ e)
{
    this->Close();
}

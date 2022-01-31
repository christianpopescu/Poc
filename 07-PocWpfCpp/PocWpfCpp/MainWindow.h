#pragma once

using namespace System;
using namespace System::Windows;
using namespace System::Windows::Controls;
ref class MainWindow :
    public Window
{
protected:
      virtual void  OnInitialized(EventArgs^ e) override;
      Button^ closeButton;
      TextBox^ tb;
      Canvas^ canvas;


private:
    void CloseWindow(System::Object^ sender, System::Windows::RoutedEventArgs^ e);
};


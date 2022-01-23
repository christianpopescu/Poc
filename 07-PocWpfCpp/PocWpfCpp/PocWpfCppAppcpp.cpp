
using namespace System;
using namespace System::Windows;
[STAThread()]
void main()
{
	// Create the application.
	Application^ app = gcnew Application();
	// Create the main window.
	Window^ win = gcnew Window();
	// Launch the application and show the main window.
	app->Run(win);
};

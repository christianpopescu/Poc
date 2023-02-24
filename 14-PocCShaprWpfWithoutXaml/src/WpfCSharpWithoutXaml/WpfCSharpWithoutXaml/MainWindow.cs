using System;
using System.Reflection.Emit;
using System.Windows;
using System.Windows.Controls;

namespace WpfCSharpWithoutXaml
{
    internal class MainWindow : Window
    {
        private TextBox tb;

        
        public MainWindow() 
        { 
            Width= 600;
            Height= 600;

            Grid grid= new Grid();
            Content= grid;
            tb = new TextBox();
            tb.Margin = new Thickness(84, 115, 74, 119);
            grid.Children.Add(tb);  

            Button btn = new Button();
            btn.Height = 23;
            btn.Content = "Click to see!";
            btn.Margin = new Thickness(96, 50, 107, 0);
            btn.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            btn.Click += new RoutedEventHandler(btn_Click);
            grid.Children.Add(btn);
            
        }

        void btn_Click(object sender, RoutedEventArgs e)
        {
            tb.Text += "WPW without Xaml";
        }
    }
}

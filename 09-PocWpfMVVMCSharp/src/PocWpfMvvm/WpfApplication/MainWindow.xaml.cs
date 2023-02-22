using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowModel theModel = new();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = theModel;
            this.lstNames.ItemsSource = theModel.ListOfElements;
            TreeViewItem tvi = new();
            tvi.Header = "Root";
            
            TreeViewItem sun = new();
            sun.Header = "sun 01";
            tvi.Items.Add(sun);

            TreeViewItem sun1 = new();
            sun1.Header = "sun 02";
            tvi.Items.Add(sun1);


            this.treeBooks.Items.Add(tvi);
        }
    }
}

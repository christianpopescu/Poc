using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication
{
    internal class MainWindowModel : INotifyPropertyChanged
    {
        private string _text;
        private string _textView;
        public event PropertyChangedEventHandler? PropertyChanged;

        public string Text
        {
            get { return _text; }
            set { _text = value; OnPropertyChanged(); }
        }

        public string TextView
        {
            get { return _textView; }
            set { _textView = value; OnPropertyChanged(); }
        }

        // Create the OnPropertyChanged method to raise the event
        // The calling member's name will be used as the parameter.
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}

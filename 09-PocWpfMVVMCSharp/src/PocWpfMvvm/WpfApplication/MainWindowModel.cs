using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace WpfApplication
{
    internal class MainWindowModel : INotifyPropertyChanged
    {

        /// <summary>
        /// Transform - Used for command button
        /// Exectue action when button pressed
        /// </summary>
        private class Transform : ICommand
        {
            private Action _action;
            public Transform(Action action)
            { 
                _action = action;
            }

            public event EventHandler? CanExecuteChanged;

            public bool CanExecute(object? parameter)
            {
                
                return true;
            }

            public void Execute(object? parameter)
            {
                _action();
            }
        }

        private string _text;
        private string _textView;
        private Transform _transformText;
        private Transform _clearView;
        public event PropertyChangedEventHandler? PropertyChanged;

        public MainWindowModel()
        {
            _transformText = new(TransformAction);
            _clearView = new(ClearAction);
        }

        public ICommand OnTransformButton
        {
            get { return _transformText; }
        }

        public ICommand OnClear
        { 
            get { return _clearView; } 
        }
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

        protected void TransformAction ()
        {
            TextView = Text + "\n" + Text + "\nTransformed";
        } 

        protected void ClearAction () 
        {
            TextView = "";
        }

        // Create the OnPropertyChanged method to raise the event
        // The calling member's name will be used as the parameter.
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}

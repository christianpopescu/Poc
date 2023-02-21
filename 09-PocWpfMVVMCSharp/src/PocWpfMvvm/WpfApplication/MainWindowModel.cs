using System;
using System.Collections.Generic;
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
        private Transform _secondFunctionality;

        public event PropertyChangedEventHandler? PropertyChanged;

        public MainWindowModel()
        {
            _transformText = new(TransformAction);
            _clearView = new(ClearAction);
            _secondFunctionality = new(OpenSecondWindow);
        }

        public ICommand OnTransformButton
        {
            get { return _transformText; }
        }

        public ICommand OnClear
        { 
            get { return _clearView; } 
        }

        public ICommand OnOpenSecondWindow
        {
            get { return _secondFunctionality; }    
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

        public System.Collections.ObjectModel.ObservableCollection<ListElement> ListOfElements = new ();

        // Transform action add elements also to the list
        protected void TransformAction ()
        {
            TextView = Text + "\n" + Text + "\nTransformed";
            ListOfElements.Add(new ListElement(Text, Text, Text.Length));
        } 

        protected void ClearAction () 
        {
            TextView = "";
        }

        protected void OpenSecondWindow()
        {
            SecondWindow sw = new SecondWindow();
            sw.ShowDialog();
        }
        // Create the OnPropertyChanged method to raise the event
        // The calling member's name will be used as the parameter.
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}

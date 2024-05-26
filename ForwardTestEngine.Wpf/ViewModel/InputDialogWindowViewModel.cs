using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ForwardTestEngine.Wpf.ViewModel
{
    public class InputDialogViewModel : INotifyPropertyChanged
    {
        private string _message;
        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged(nameof(Message));
            }
        }

        private double _inputValue;
        public double InputValue
        {
            get { return _inputValue; }
            set
            {
                _inputValue = value;
                OnPropertyChanged(nameof(InputValue));
            }
        }

        public ICommand OKCommand { get; private set; }
        public ICommand CancelCommand { get; private set; }

        public bool? DialogResult { get; private set; }

        public InputDialogViewModel(string message)
        {
            Message = message;
            OKCommand = new RelayCommand(OK);
            CancelCommand = new RelayCommand(Cancel);
        }

        private void OK(object parameter)
        {
            DialogResult = true;
            ((Window)parameter).Close();
        }

        private void Cancel(object parameter)
        {
            DialogResult = false;
            ((Window)parameter).Close();
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

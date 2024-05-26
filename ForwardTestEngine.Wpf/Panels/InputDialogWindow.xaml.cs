using System.Windows;

namespace ForwardTestEngine.Wpf.Panels
{
    public partial class InputDialogWindow : Window
    {
        public double InputValue { get; set; }
        public string Message { get; set; }

        public InputDialogWindow(string message)
        {
            InitializeComponent();
            DataContext = this;
            Message = message;
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(InputTextBox.Text, out double value))
            {
                InputValue = value;
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Invalid input. Please enter a valid number.");
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}

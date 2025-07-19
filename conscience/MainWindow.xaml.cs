using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace conscience
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.Closing += OnWindowClosing;
            TaskCheckBox.Checked += (s, e) => ValidateInput();
            TaskCheckBox.Unchecked += (s, e) => ValidateInput();
            ConfirmationTextBox.TextChanged += (s, e) => ValidateInput();
        }

        private void OnWindowClosing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void ValidateInput()
        {
            UnlockButton.IsEnabled = TaskCheckBox.IsChecked == true
                && !string.IsNullOrWhiteSpace(ConfirmationTextBox.Text)
                && ConfirmationTextBox.Text.Contains("Я сделал дело и считаю сегодняшний день удачным!");
        }

        private void UnlockButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
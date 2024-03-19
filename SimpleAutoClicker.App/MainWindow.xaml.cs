using SimpleAutoClicker.Core;
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

namespace SimpleAutoClicker.App
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            KeyboardHook hook = new KeyboardHook();
            Action<string> act = (string test) =>
            {
                StartBtn.Content = test;
            };

            hook.CreateKeyboardHook(ref act);

            hook.Print();
        }

        private void StartBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
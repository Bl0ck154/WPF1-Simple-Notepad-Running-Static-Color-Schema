using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace ColorSchema
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<string, string> memory = new Dictionary<string, string>();
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            txtboxName.GotFocus += TxtboxName_GotFocus;
            txtboxName.LostFocus += TxtboxName_LostFocus;
            txtboxName.TextChanged += TxtboxName_TextChanged;
            txtboxColor.GotFocus += TxtboxName_GotFocus;
            txtboxColor.LostFocus += TxtboxColor_LostFocus;
        }
        private void TxtboxColor_LostFocus(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtboxName.Text))
                txtboxColor.Text = "Enter string color like Red, Blue, Green...";
        }

        private void TxtboxName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtboxName.Text))
                txtboxName.Text = "Enter name here...";
        }

        private void TxtboxName_GotFocus(object sender, RoutedEventArgs e)
        {
            (sender as TextBox).Text = "";
        }

        private void TxtboxName_TextChanged(object sender, TextChangedEventArgs e)
        {
            ChangeBackground();
        }
        private void ChangeBackground()
        {
            string value;
            if (memory.TryGetValue(txtboxName.Text, out value))
            {
                try
                {
                    grid.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(value));
                }
                catch { }
            }
            else
                grid.Background = Background;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            memory[txtboxName.Text] = txtboxColor.Text;
            ChangeBackground();
        }
    }
}

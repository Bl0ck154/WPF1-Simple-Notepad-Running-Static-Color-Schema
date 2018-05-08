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

namespace SimpleNotepad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Cut(object sender, RoutedEventArgs e)
        {
            txtbox.Cut();
        }
        private void Button_Copy(object sender, RoutedEventArgs e)
        {
            txtbox.Copy();
        }
        private void Button_Paste(object sender, RoutedEventArgs e)
        {
            txtbox.Paste();
        }
    }
}

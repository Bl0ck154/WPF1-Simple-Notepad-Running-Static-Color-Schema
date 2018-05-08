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

namespace RunningStatic
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
            this.MouseMove += MainWindow_MouseMove;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            ClearValue(SizeToContentProperty);
        }

        private void MainWindow_MouseMove(object sender, MouseEventArgs e)
        {
            Point curPos = e.GetPosition(this);
            double left = Canvas.GetLeft(ClickMeButton);
            double top = Canvas.GetTop(ClickMeButton);
            if (curPos.X >= left-15 && curPos.X <= left+ClickMeButton.ActualWidth + 15 
                && curPos.Y >= top - 15 && curPos.Y <= top+ ClickMeButton.ActualHeight + 15)
            {
                if (left <= 0 || left + ClickMeButton.ActualWidth > field.ActualWidth)
                    left = field.ActualWidth /2;
              
                if(top <= 0 || top + ClickMeButton.ActualHeight > field.ActualHeight)
                    top = field.ActualHeight /2;

                if (curPos.X >= left + ClickMeButton.ActualWidth / 2)
                    Canvas.SetLeft(ClickMeButton, left - 2);
                else if(curPos.X < left + ClickMeButton.ActualWidth / 2)
                    Canvas.SetLeft(ClickMeButton, left + 2);
                else if (curPos.Y >= top + ClickMeButton.ActualHeight / 2)
                    Canvas.SetTop(ClickMeButton, top - 2);
                else
                    Canvas.SetTop(ClickMeButton, top + 2);
            }
            Title = $"left:{left} top:{top} cursor:{curPos.ToString()} actualHeight: {field.ActualHeight}";
        }
    }
}

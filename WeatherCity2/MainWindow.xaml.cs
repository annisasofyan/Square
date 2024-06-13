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

namespace WeatherCity2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
            BtnRestoreDown.Style = (Style)FindResource("bt_RestoreDownWindow");
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void BtnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void BtnRestoreDown_Click(object sender, RoutedEventArgs e)
        {
            if(this.WindowState == WindowState.Normal)
            {
                this.WindowState=WindowState.Maximized;
                BtnRestoreDown.Style = (Style)FindResource("bt_RestoreDownWindow");
            }
            else
            {
                this.WindowState = WindowState.Normal;
                BtnRestoreDown.Style = (Style)FindResource("bt_MaximizeWindow");


            }
        }

        private void BtnClos_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

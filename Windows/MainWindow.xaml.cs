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
using System.Windows.Threading;

namespace Project.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loading();
        }

        DispatcherTimer timer = new DispatcherTimer();

        private void timer_tick(object sender, EventArgs e)
        {
            timer.Stop();
            load.Visibility = Visibility.Hidden;
            Border_content.Visibility = Visibility.Visible;
        }
        void Loading()
        {
            timer.Tick += timer_tick;
            timer.Interval = new TimeSpan(0, 0, 2);
            timer.Start();
        }

        private void Button_register_Click(object sender, RoutedEventArgs e)
        {
            Window_register_login.Navigate(new Pages.Page_register());
            Button_register.Style = this.Resources["CheckedRightButtonStyle"] as Style;
            Button_login.Style = this.Resources["LeftButtonStyle"] as Style;
        }
        private void Button_login_Click(object sender, RoutedEventArgs e)
        {
            Window_register_login.Navigate(new Pages.Page_login());
            Button_login.Style = this.Resources["CheckedLeftButtonStyle"] as Style;
            Button_register.Style = this.Resources["RightButtonStyle"] as Style;
        }


    }
}

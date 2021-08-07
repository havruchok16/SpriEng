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
using System.Windows.Shapes;

namespace Project.Windows
{
    /// <summary>
    /// Логика взаимодействия для Window_error.xaml
    /// </summary>
    public partial class Window_error : Window
    {
        public Window_error()
        {
            InitializeComponent();
        }

        private void ErrorButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

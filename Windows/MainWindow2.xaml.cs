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
    /// Логика взаимодействия для MainWindow2.xaml
    /// </summary>
    public partial class MainWindow2 : Window
    {
        public MainWindow2()
        {
            InitializeComponent();
        }

        private void Home_page_Click(object sender, RoutedEventArgs e)
        {
            Info_page.Navigate(new Pages.Page_home());
            Home_page.Style = this.Resources["CheckedButtonStyle"] as Style;
            Profile_page.Style = Progress_page.Style = Texts_page.Style = Words_page.Style =
            Grammar_page.Style = Dictionary_page.Style = Exit_page.Style= this.Resources["ButtonStyle"] as Style;
        }

        private void Profile_page_Click(object sender, RoutedEventArgs e)
        {
            Info_page.Navigate(new Pages.Page_profile());
            Profile_page.Style = this.Resources["CheckedButtonStyle"] as Style;
            Home_page.Style = Progress_page.Style = Texts_page.Style = Words_page.Style =
            Grammar_page.Style = Dictionary_page.Style = Exit_page.Style = this.Resources["ButtonStyle"] as Style;
        }

        private void Progress_page_Click(object sender, RoutedEventArgs e)
        {
            Info_page.Navigate(new Pages.Page_progress());
            Progress_page.Style = this.Resources["CheckedButtonStyle"] as Style;
            Home_page.Style = Profile_page.Style = Texts_page.Style = Words_page.Style =
            Grammar_page.Style = Dictionary_page.Style = Exit_page.Style = this.Resources["ButtonStyle"] as Style;
        }

        private void Texts_page_Click(object sender, RoutedEventArgs e)
        {
            Pages.Page_texts pg = new Pages.Page_texts();
            pg.Back_to_Home.Visibility = Visibility.Hidden;
            Info_page.Navigate(pg);
            Texts_page.Style = this.Resources["CheckedButtonStyle"] as Style;
            Home_page.Style = Profile_page.Style = Progress_page.Style = Words_page.Style =
            Grammar_page.Style = Dictionary_page.Style = Exit_page.Style = this.Resources["ButtonStyle"] as Style;
        }

        private void Words_page_Click(object sender, RoutedEventArgs e)
        {
            Pages.Page_words pg = new Pages.Page_words();
            pg.Back_to_Home.Visibility = Visibility.Hidden;
            Info_page.Navigate(pg);
            Words_page.Style = this.Resources["CheckedButtonStyle"] as Style;
            Home_page.Style = Profile_page.Style = Progress_page.Style = Texts_page.Style =
            Grammar_page.Style = Dictionary_page.Style = Exit_page.Style = this.Resources["ButtonStyle"] as Style;
        }

        private void Grammar_page_Click(object sender, RoutedEventArgs e)
        {
            Pages.Page_grammar pg = new Pages.Page_grammar();
            pg.Back_to_Home.Visibility = Visibility.Hidden;
            Info_page.Navigate(pg);
            Grammar_page.Style = this.Resources["CheckedButtonStyle"] as Style;
            Home_page.Style = Profile_page.Style = Progress_page.Style = Texts_page.Style =
            Words_page.Style = Dictionary_page.Style = Exit_page.Style = this.Resources["ButtonStyle"] as Style;
        }

        private void Dictionary_page_Click(object sender, RoutedEventArgs e)
        {
            Info_page.Navigate(new Pages.Page_dictionary());
            Dictionary_page.Style = this.Resources["CheckedButtonStyle"] as Style;
            Home_page.Style = Profile_page.Style = Progress_page.Style = Texts_page.Style =
            Words_page.Style = Grammar_page.Style = Exit_page.Style = this.Resources["ButtonStyle"] as Style;
        }

        private void Exit_page_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Windows.MainWindow mw = new Windows.MainWindow();
            mw.Show();

        }

    }
}

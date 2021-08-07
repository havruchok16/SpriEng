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

namespace Project.Pages
{
    /// <summary>
    /// Логика взаимодействия для Page_home.xaml
    /// </summary>
    public partial class Page_home : Page
    {
        
        public Page_home()
        {
            InitializeComponent();
        }

        private void Open_texts_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/Page_texts.xaml", UriKind.Relative));
        }

        private void Open_words_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/Page_words.xaml", UriKind.Relative));
        }

        private void Open_grammar_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/Page_grammar.xaml", UriKind.Relative));
        }

        private void SectionsText_MouseEnter(object sender, MouseEventArgs e)
        {
            SectionsText.Text = "Выберите задание..";
        }

        private void SectionsText_MouseLeave(object sender, MouseEventArgs e)
        {
            SectionsText.Text = "Choose a Task..";
        }

        private void TextAboutTexts_MouseEnter(object sender, MouseEventArgs e)
        {
            TextAboutTexts.Text = "Здесь вы можете читать и переводить тексты";
        }

        private void TextAboutTexts_MouseLeave(object sender, MouseEventArgs e)
        {
            TextAboutTexts.Text = "Here You can read and translate Texts";
        }

        private void TextAboutWords_MouseEnter(object sender, MouseEventArgs e)
        {
            TextAboutWords.Text = "Здесь вы можете учить новые слова";
        }

        private void TextAboutWords_MouseLeave(object sender, MouseEventArgs e)
        {
            TextAboutWords.Text = "Here You can learn new Words";
        }

        private void TextAboutGrammar_MouseEnter(object sender, MouseEventArgs e)
        {
            TextAboutGrammar.Text = "Здесь вы можете учить грамматику";
        }

        private void TextAboutGrammar_MouseLeave(object sender, MouseEventArgs e)
        {
            TextAboutGrammar.Text = "Here You can learn Grammar";
        }

    }
}

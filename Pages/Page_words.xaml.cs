using Project.Data;
using Project.Database;
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
    /// Логика взаимодействия для Page_words.xaml
    /// </summary>
    public partial class Page_words : Page
    {
        public Page_words()
        {
            InitializeComponent();
        }

        private void SectionsText_MouseEnter(object sender, MouseEventArgs e)
        {
            SectionsText.Text = "Учите новые слова..";
        }

        private void SectionsText_MouseLeave(object sender, MouseEventArgs e)
        {
            SectionsText.Text = "Learn new Words..";
        }

        private void Instruction_MouseEnter(object sender, MouseEventArgs e)
        {
            Instruction.Text = "Нажмите ''Добавить это слово!'', чтобы добавить новое слово в ваш словарь";
        }

        private void Instruction_MouseLeave(object sender, MouseEventArgs e)
        {
            Instruction.Text = "Click ''Add this Word!'' to add new Word to Your Dictionary";
        }

        List<string> engList = new List<string>();
        List<string> ruList = new List<string>();

        private void Pagewords_Loaded(object sender, RoutedEventArgs e)
        {
            using (SpriengEntities context = new SpriengEntities())
            {
                var words = context.Word.ToList();
                foreach (Word w in words)
                {
                    engList.Add(w.Word1);
                    ruList.Add(w.Translate);
                }
            }
        }
        public int i = 0;
        private void Next_word_Click(object sender, RoutedEventArgs e)
        {
            if (i == engList.Count)
            {
                i = 0;
            }
            if (i < engList.Count) 
            {
                enword.Text = engList[i];
                ruword.Text = ruList[i];
                i++;
            }
        }

        private void Add_word_Click(object sender, RoutedEventArgs e)
        {
            bool check = false;
            using (SpriengEntities context = new SpriengEntities())
            {
                var dictionary = context.Dictionary.ToList();
                Dictionary dictio = new Dictionary(CurrentUser.CurUser.UserId, enword.Text, ruword.Text);
                foreach (Dictionary d in dictionary)
                {
                    if (d.UserId == CurrentUser.CurUser.UserId && d.Word == enword.Text && d.Translate == ruword.Text)
                    {
                        check = true;
                        break;
                    }
                }
                if (check == false)
                {
                    context.Dictionary.Add(dictio);
                    context.SaveChanges();
                    Windows.Window_done mwd = new Windows.Window_done();
                    mwd.DoneText.Text = "Слово было добавлено в ваш словарь..";
                    mwd.Show();
                }
                else
                {
                    Windows.Window_error mwe = new Windows.Window_error();
                    mwe.ErrorText.Text = "Это слово уже есть в вашем словаре..";
                    mwe.Show();
                }
            }
        }

        private void Back_to_Home_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/Page_home.xaml", UriKind.Relative));
        }
    }
}

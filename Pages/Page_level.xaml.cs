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
using Project.Data;
using Project.Database;

namespace Project.Pages
{
    /// <summary>
    /// Логика взаимодействия для Page_level.xaml
    /// </summary>
    public partial class Page_level : Page
    {
        public Page_level()
        {
            InitializeComponent();
           
        }

        string tmpU = Page_register.tmpUsername;
        string tmpL = Page_register.tmpLogin;
        string tmpP = Page_register.tmpPassword;

        private void Lang_level_MouseEnter(object sender, MouseEventArgs e)
        {
            Lang_level.Text = "ВЫБЕРИТЕ ВАШ УРОВЕНЬ ЯЗЫКА";
        }

        private void Lang_level_MouseLeave(object sender, MouseEventArgs e)
        {
            Lang_level.Text = "CHOOSE YOUR LANGUAGE LEVEL";
        }

        private void Beginner_Click(object sender, RoutedEventArgs e)
        {
            string Langlevel = "Beginner";
            Register(Langlevel);
        }

        private void Elementary_Click(object sender, RoutedEventArgs e)
        {
            string Langlevel = "Elementary";
            Register(Langlevel);
        }

        private void Intermediate_Click(object sender, RoutedEventArgs e)
        {
            string Langlevel = "Intermediate";
            Register(Langlevel);
        }
        public void Register(string langlevel)
        {

            using (SpriengEntities context = new SpriengEntities())
            {
                //создание юзера
                User user = new User(tmpU, tmpL, App.GetHash(tmpP));
                context.User.Add(user);
                context.SaveChanges();
                CurrentUser.CurUser = user;
                //заполнение таблицы инфо по умолчанию
                int textcount = 0;
                int rulecount = 0;
                int wordcount = 0;
                Info info = new Info(CurrentUser.CurUser.UserId, langlevel, textcount, rulecount, wordcount);
                context.Info.Add(info);
                context.SaveChanges();
                CurrentUser.InfoCurUser = info;
                //создание словаря юзера по умолчанию
                string en = "Word";
                string ru = "Слово";
                Dictionary dictionary = new Dictionary(CurrentUser.CurUser.UserId, en, ru);
                context.Dictionary.Add(dictionary);
                context.SaveChanges();

                Windows.MainWindow2 mw = new Windows.MainWindow2();
                mw.Show();
                Application.Current.MainWindow.Close();
            }
        }
    }
}

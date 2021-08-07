using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Логика взаимодействия для Page_profile.xaml
    /// </summary>
    public partial class Page_profile : Page
    {
        public Page_profile()
        {
            InitializeComponent();
            this.DataContext = new Profile();
        }

        private void SectionsText_MouseEnter(object sender, MouseEventArgs e)
        {
            SectionsText.Text = "Это ваш профиль..";
        }

        private void SectionsText_MouseLeave(object sender, MouseEventArgs e)
        {
            SectionsText.Text = "This is Your Profile..";
        }

        //проверка буквы или цифры
        public static bool OnlyLettersAndNumbers(string s)
        {
            foreach (char c in s)
            {
                if (!Char.IsLetter(c) && !Char.IsDigit(c))
                    return false;
            }
            return true;
        }

        private void Save_changes_Click(object sender, RoutedEventArgs e)
        {
            if (Login.Text == CurrentUser.CurUser.Login && App.GetHash(Old_password.Password) == CurrentUser.CurUser.Password)
            {
                using (SpriengEntities context = new SpriengEntities())
                {
                    if (New_password.Password.Length >= 5 && New_password.Password.Length <= 30 && OnlyLettersAndNumbers(New_password.Password)
                        && (Langlevel.Text == "Beginner" || Langlevel.Text == "Elementary" || Langlevel.Text == "Intermediate"))
                    {
                        var pas = context.User
                            .Where(c => c.Password == CurrentUser.CurUser.Password)
                            .FirstOrDefault();

                        var lnglvl = context.Info.Where(c => c.Langlevel == CurrentUser.InfoCurUser.Langlevel)
                            .FirstOrDefault();

                        lnglvl.Langlevel = Langlevel.Text;
                        CurrentUser.InfoCurUser.Langlevel = Langlevel.Text;
                        pas.Password = App.GetHash(New_password.Password);
                        CurrentUser.CurUser.Password = pas.Password;
                        context.SaveChanges();
                        Windows.Window_done mwd = new Windows.Window_done();
                        mwd.Show();
                    }
                    else if (New_password.Password.Length == 0 && (Langlevel.Text == "Beginner" || Langlevel.Text == "Elementary" || Langlevel.Text == "Intermediate")) 
                    {
                        var lnglvl = context.Info.Where(c => c.Langlevel == CurrentUser.InfoCurUser.Langlevel)
                             .FirstOrDefault();
                        lnglvl.Langlevel = Langlevel.Text;
                        CurrentUser.InfoCurUser.Langlevel = Langlevel.Text;
                        context.SaveChanges();
                        Windows.Window_done mwd = new Windows.Window_done();
                        mwd.Show();
                    }
                    else
                    {
                        Windows.Window_error mwe = new Windows.Window_error();
                        mwe.ErrorText.Text = "При смене информации все поля должны быть заполнены, также необходимо вводить правильный старый пароль для подтверждения..";
                        mwe.Show();
                    }
                }
            }
            else
            {
                Windows.Window_error mwe = new Windows.Window_error();
                mwe.ErrorText.Text = "Старый пароль не был введен или введен неверно..";
                mwe.Show();
            }
            Langlevel.Text = CurrentUser.InfoCurUser.Langlevel;
            Old_password.Password = "";
            New_password.Password = "";
        }

        private void PageProfile_Loaded(object sender, RoutedEventArgs e)
        {
            Login.Text = CurrentUser.CurUser.Login;
            Username.Text = CurrentUser.CurUser.UserName;
            Langlevel.Text = CurrentUser.InfoCurUser.Langlevel;
        }
    }
}

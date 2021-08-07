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
    /// Логика взаимодействия для Page_login.xaml
    /// </summary>
    public partial class Page_login : Page
    {
        public Page_login()
        {
            InitializeComponent();
        }

        private bool CorrectData(string login, string password)
        {
            bool check = false;
            using (SpriengEntities context = new SpriengEntities())
            {
                try
                {
                    var users = context.User.ToList();
                    foreach (User u in users)
                    {
                        if (login == u.Login && App.GetHash(password) == u.Password)
                        {
                            check = true;
                            CurrentUser.CurUser = u;
                            var infos = context.Info.ToList();
                            foreach (Info i in infos)
                            {
                                if (u.UserId == i.UserId)
                                {
                                    CurrentUser.InfoCurUser = i;
                                }
                            }
                        }
                    }
                }
                catch
                {
                    Windows.Window_error mwe = new Windows.Window_error();
                    mwe.ErrorText.Text = "Пользователи еще не были созданы, станьте первым..";
                    mwe.Show();
                }
                //var users = context.User.ToList();
                //foreach (User u in users)
                //{
                //    if (login == u.Login && App.GetHash(password) == u.Password)
                //    {
                //        check = true;
                //        CurrentUser.CurUser = u;
                //        var infos = context.Info.ToList();
                //        foreach(Info i in infos)
                //        {
                //            if (u.UserId == i.UserId) 
                //            {
                //                CurrentUser.InfoCurUser = i;
                //            }
                //        }
                //    }
                //}
            }
            return check;
        }

        private void Button_login_to_account_Click(object sender, RoutedEventArgs e)
        {
            if (CorrectData(Login_login.Text, Login_password.Password))
            {
                Windows.MainWindow2 mw = new Windows.MainWindow2();
                mw.Show();
                Application.Current.MainWindow.Close();
            }
            else
            {
                Windows.Window_error mwe = new Windows.Window_error();
                mwe.ErrorText.Text = "Логин или пароль введен неверно";
                mwe.Show();
            }
     
        }
    }
}

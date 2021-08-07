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
    /// Логика взаимодействия для Page_register.xaml
    /// </summary>
    public partial class Page_register : Page
    {
        public Page_register()
        {
            InitializeComponent();
        }
        public static string tmpUsername = "#";
        public static string tmpLogin = "#";
        public static string tmpPassword = "#";

        public static bool OnlyLettersAndNumbers(string s)
        {
            foreach (char c in s)
            {
                if (!Char.IsLetter(c) && !Char.IsDigit(c))
                    return false;
            }
            return true;
        }

        private void Button_create_account_Click(object sender, RoutedEventArgs e)
        {
            using (SpriengEntities context = new SpriengEntities())
            {
                try
                {
                    var users = context.User.ToList();
                    foreach (User u in users)
                    {
                        if (Register_login.Text == u.Login)
                        {
                            Windows.Window_error mwe = new Windows.Window_error();
                            mwe.ErrorText.Text = "Пользователь с этим логином уже есть, придумайте новый";
                            mwe.Show();
                            break;
                        }
                        else
                        {
                            if (Register_username.Text.Length >= 5 && Register_username.Text.Length <= 30 &&
                                !Register_username.Text.Contains(" ") && OnlyLettersAndNumbers(Register_username.Text) &&
                                Register_login.Text.Length >= 5 && Register_login.Text.Length <= 30 &&
                                !Register_login.Text.Contains(" ") && OnlyLettersAndNumbers(Register_login.Text) &&
                                Register_password.Password.Length >= 5 && Register_password.Password.Length <= 30 &&
                                !Register_password.Password.Contains(" ") && OnlyLettersAndNumbers(Register_password.Password))
                            {
                                tmpUsername = Register_username.Text;
                                tmpLogin = Register_login.Text;
                                tmpPassword = Register_password.Password;
                                this.NavigationService.Navigate(new Uri("Pages/Page_level.xaml", UriKind.Relative));
                            }
                            else
                            {
                                Windows.Window_error mwe = new Windows.Window_error();
                                mwe.ErrorText.Text = "Все поля должны содержать буквы и(или) цифры и не должны содержать пробелы..";
                                mwe.Show();
                            }
                            break;
                        }
                    }
                }
                catch
                {
                    if (Register_username.Text.Length >= 5 && Register_username.Text.Length <= 30 &&
                                 !Register_username.Text.Contains(" ") && OnlyLettersAndNumbers(Register_username.Text) &&
                                 Register_login.Text.Length >= 5 && Register_login.Text.Length <= 30 &&
                                 !Register_login.Text.Contains(" ") && OnlyLettersAndNumbers(Register_login.Text) &&
                                 Register_password.Password.Length >= 5 && Register_password.Password.Length <= 30 &&
                                 !Register_password.Password.Contains(" ") && OnlyLettersAndNumbers(Register_password.Password))
                    {
                        tmpUsername = Register_username.Text;
                        tmpLogin = Register_login.Text;
                        tmpPassword = Register_password.Password;
                        this.NavigationService.Navigate(new Uri("Pages/Page_level.xaml", UriKind.Relative));
                    }
                    else
                    {
                        Windows.Window_error mwe = new Windows.Window_error();
                        mwe.ErrorText.Text = "Все поля должны содержать буквы и(или) цифры и не должны содержать пробелы..";
                        mwe.Show();
                    }
                }
                //var users = context.User.ToList();
                //foreach (User u in users)
                //{
                //    if (Register_login.Text == u.Login)
                //    {
                //        Windows.Window_error mwe = new Windows.Window_error();
                //        mwe.ErrorText.Text = "Пользователь с этим логином уже есть, придумайте новый";
                //        mwe.Show();
                //        break;
                //    }
                //    else
                //    {
                //        if (Register_username.Text.Length >= 5 && Register_username.Text.Length <= 30 && 
                //            !Register_username.Text.Contains(" ") && OnlyLettersAndNumbers(Register_username.Text) &&
                //            Register_login.Text.Length >= 5 && Register_login.Text.Length <= 30 && 
                //            !Register_login.Text.Contains(" ") && OnlyLettersAndNumbers(Register_login.Text) &&
                //            Register_password.Password.Length >= 5 && Register_password.Password.Length <= 30 && 
                //            !Register_password.Password.Contains(" ") && OnlyLettersAndNumbers(Register_password.Password))
                //        {
                //            tmpUsername = Register_username.Text;
                //            tmpLogin = Register_login.Text;
                //            tmpPassword = Register_password.Password;
                //            this.NavigationService.Navigate(new Uri("Pages/Page_level.xaml", UriKind.Relative));
                //        }
                //        else
                //        {
                //            Windows.Window_error mwe = new Windows.Window_error();
                //            mwe.ErrorText.Text = "Все поля должны содержать буквы и(или) цифры и не должны содержать пробелы..";
                //            mwe.Show();
                //        }
                //     break;
                //    }
                //}
            }

        }
    }
}

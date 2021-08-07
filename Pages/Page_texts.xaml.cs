using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Project.Database;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Path = System.IO.Path;
using Project.Data;

namespace Project.Pages
{
    /// <summary>
    /// Логика взаимодействия для Page_texts.xaml
    /// </summary>
    public partial class Page_texts : Page
    {
        public Page_texts()
        {
            InitializeComponent();
            this.DataContext = new Profile();
        }

        private void SectionsText_MouseEnter(object sender, MouseEventArgs e)
        {
            SectionsText.Text = "Выберите текст в зависимости от уровня..";
        }

        private void SectionsText_MouseLeave(object sender, MouseEventArgs e)
        {
            SectionsText.Text = " Choose the Text depending on the Level..";
        }

        private void SetContent(object buttonContent)
        {
            string str = Convert.ToString(buttonContent);
            using (SpriengEntities context = new SpriengEntities())
            {
                var texts = context.Text.ToList();
                foreach (Text t in texts)
                {
                    if (str == t.TextTitle) 
                    {
                        if(t.LangLevel == CurrentUser.InfoCurUser.Langlevel)
                        {
                            EnText.Text = t.EnText;
                            RuText.Text = t.RuText;
                            ButtonContent = str;
                        }
                        else
                        {
                            Windows.Window_error mwe = new Windows.Window_error();
                            mwe.ErrorText.Text = "Этот текст не соответствует вашему уровню языка. Измените свой уровень в настройках профиля..";
                            mwe.Show();
                        }

                    }
                  
                }
            }
           
        }

        private void ButtonText1_Click(object sender, RoutedEventArgs e)
        {
            SetContent(ButtonText1.Content);
        }

        private void ButtonText2_Click(object sender, RoutedEventArgs e)
        {
            SetContent(ButtonText2.Content);
        }

        private void ButtonText3_Click(object sender, RoutedEventArgs e)
        {
            SetContent(ButtonText3.Content);
        }

        private void ButtonText4_Click(object sender, RoutedEventArgs e)
        {
            SetContent(ButtonText4.Content);
        }

        private void ButtonText5_Click(object sender, RoutedEventArgs e)
        {
            SetContent(ButtonText5.Content);
        }

        private void ButtonText6_Click(object sender, RoutedEventArgs e)
        {
            SetContent(ButtonText6.Content);
        }

        private void ButtonText7_Click(object sender, RoutedEventArgs e)
        {
            SetContent(ButtonText7.Content);
        }

        private void ButtonText8_Click(object sender, RoutedEventArgs e)
        {
            SetContent(ButtonText8.Content);
        }

        private void ButtonText9_Click(object sender, RoutedEventArgs e)
        {
            SetContent(ButtonText9.Content);
        }


        string ButtonContent = "";
        private void ButtonComplited_Click(object sender, RoutedEventArgs e)
        {
            if (ButtonContent != "")
            {
                using (SpriengEntities context = new SpriengEntities())
                {
                    var texts = context.Text.ToList();
                    int textId = 0;
                    foreach (Text t in texts)
                    {
                        if (ButtonContent == t.TextTitle)
                        {
                            bool check = false;
                            textId = t.TextId;
                            try
                            {
                                var prog = context.Progress.ToList();
                                foreach (Progress pr in prog)
                                {
                                    if (pr.ProgressId == CurrentUser.InfoCurUser.ProgressId && pr.TextId == textId)
                                    {
                                        check = true;
                                        break;
                                    }
                                }
                                if (check == true)
                                {
                                    Windows.Window_error mwe = new Windows.Window_error();
                                    mwe.ErrorText.Text = "Это текст был прочитан вами ранее";
                                    mwe.Show();
                                }
                                else
                                {
                                    Progress progress = new Progress(CurrentUser.InfoCurUser.ProgressId, Progress.ParametrType.Text, textId, true);
                                    context.Progress.Add(progress);
                                    context.SaveChanges();
                                    Windows.Window_done mwd = new Windows.Window_done();
                                    mwd.DoneText.Text = "Текст был успешно прочитан..";
                                    mwd.Show();
                                }
                            }
                            catch
                            {
                                Progress progress = new Progress(CurrentUser.InfoCurUser.ProgressId, Progress.ParametrType.Text, textId, true);
                                context.Progress.Add(progress);
                                context.SaveChanges();
                                Windows.Window_done mwd = new Windows.Window_done();
                                mwd.DoneText.Text = "Текст был успешно прочитан..";
                                mwd.Show();
                            }
                            
                        }
                    }
                    EnText.Text = "";
                    RuText.Text = "";
                    ButtonContent = "";
                }
            }
            else
            {
                Windows.Window_error mwe = new Windows.Window_error();
                mwe.ErrorText.Text = "Вы не выбрали текст, который хотите прочитать..";
                mwe.Show();
            }
        }

        private void Back_to_Home_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/Page_home.xaml", UriKind.Relative));
        }
    }
}

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
    /// Логика взаимодействия для Page_grammar.xaml
    /// </summary>
    public partial class Page_grammar : Page
    {
        public Page_grammar()
    
        {
            InitializeComponent();
            this.DataContext = new Profile();
        }

        private void SectionsText_MouseEnter(object sender, MouseEventArgs e)
        {
            SectionsText.Text = "Выберите правило..";
        }

        private void SectionsText_MouseLeave(object sender, MouseEventArgs e)
        {
            SectionsText.Text = "Choose a Rule..";
        }

        private void SetContent(object buttonContent)
        {
            string str = Convert.ToString(buttonContent);
            using (SpriengEntities context = new SpriengEntities())
            {
                var rules = context.Rule.ToList();
                foreach (Rule r in rules)
                {
                    if (str == r.RuleTitle)
                    {
                        if(r.LangLevel == CurrentUser.InfoCurUser.Langlevel)
                        {
                            RuleText.Text = r.Rule1;
                            ButtonContent = str;
                        }
                        else
                        {
                            Windows.Window_error mwe = new Windows.Window_error();
                            mwe.ErrorText.Text = "Это правило не соответствует вашему уровню языка. Измените свой уровень в настройках профиля..";
                            mwe.Show();
                        }
                    }
                }
            }
        }

        private void ButtonRule1_Click(object sender, RoutedEventArgs e)
        {
            SetContent(ButtonRule1.Content);
        }

        private void ButtonRule2_Click(object sender, RoutedEventArgs e)
        {
            SetContent(ButtonRule2.Content);
        }

        private void ButtonRule3_Click(object sender, RoutedEventArgs e)
        {
            SetContent(ButtonRule3.Content);
        }

        private void ButtonRule4_Click(object sender, RoutedEventArgs e)
        {
            SetContent(ButtonRule4.Content);
        }

        private void ButtonRule5_Click(object sender, RoutedEventArgs e)
        {
            SetContent(ButtonRule5.Content);
        }

        private void ButtonRule6_Click(object sender, RoutedEventArgs e)
        {
            SetContent(ButtonRule6.Content);
        }

        private void ButtonRule7_Click(object sender, RoutedEventArgs e)
        {
            SetContent(ButtonRule7.Content);
        }

        private void ButtonRule8_Click(object sender, RoutedEventArgs e)
        {
            SetContent(ButtonRule8.Content);
        }

        private void ButtonRule9_Click(object sender, RoutedEventArgs e)
        {
            SetContent(ButtonRule9.Content);
        }

        string ButtonContent = "";

        private void ButtonComplited_Click(object sender, RoutedEventArgs e)
        {
            if (ButtonContent != "") 
            {
                using (SpriengEntities context = new SpriengEntities())
                {
                    var rules = context.Rule.ToList();
                    int ruleId = 0;
                    foreach (Rule r in rules)
                    {
                        if (ButtonContent == r.RuleTitle)
                        {
                            bool check = false;
                            ruleId = r.RuleId;
                            try
                            {
                                var prog = context.Progress.ToList();
                                foreach (Progress pr in prog)
                                {
                                    if (pr.ProgressId == CurrentUser.InfoCurUser.ProgressId && pr.RuleId == ruleId)
                                    {
                                        check = true;
                                        break;
                                    }
                                }
                                if (check == true)
                                {
                                    Windows.Window_error mwe = new Windows.Window_error();
                                    mwe.ErrorText.Text = "Это правило было изучено вами ранее..";
                                    mwe.Show();
                                }
                                else
                                {
                                    Progress progress = new Progress(CurrentUser.InfoCurUser.ProgressId, Progress.ParametrType.Rule, ruleId, true);
                                    context.Progress.Add(progress);
                                    context.SaveChanges();
                                    Windows.Window_done mwd = new Windows.Window_done();
                                    mwd.DoneText.Text = "Правило было успешно выучено..";
                                    mwd.Show();
                                }
                            }
                            catch
                            {
                                Progress progress = new Progress(CurrentUser.InfoCurUser.ProgressId, Progress.ParametrType.Rule, ruleId, true);
                                context.Progress.Add(progress);
                                context.SaveChanges();
                                Windows.Window_done mwd = new Windows.Window_done();
                                mwd.DoneText.Text = "Правило было успешно выучено..";
                                mwd.Show();
                            }         
                        }
                    }
                    RuleText.Text = "";
                    ButtonContent = "";
                }
            }
            else
            {
                Windows.Window_error mwe = new Windows.Window_error();
                mwe.ErrorText.Text = "Вы не выбрали правило, которое хотите изучить..";
                mwe.Show();
            }
        }

        private void Back_to_Home_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/Page_home.xaml", UriKind.Relative));
        }
    }
}

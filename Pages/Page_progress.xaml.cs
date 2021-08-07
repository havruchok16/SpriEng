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
using LiveCharts;
using LiveCharts.Wpf;

namespace Project.Pages
{
    /// <summary>
    /// Логика взаимодействия для Page_progress.xaml
    /// </summary>
    public partial class Page_progress : Page
    {
        public Page_progress()
        {
            InitializeComponent();

            using (SpriengEntities context = new SpriengEntities())
            {
                try
                {
                    int textCount = 0;
                    int ruleCount = 0;
                    int wordCount = 0;
                    var progress = context.Progress.ToList();
                    foreach (Progress pr in progress)
                    {
                        if (CurrentUser.InfoCurUser.ProgressId == pr.ProgressId)
                        {
                            if (pr.TextId != null)
                            {
                                textCount++;
                            }
                            else if (pr.RuleId != null)
                            {
                                ruleCount++;
                            }
                        }
                    }
                    var dictionary = context.Dictionary.ToList();
                    foreach (Dictionary d in dictionary)
                    {
                        if (CurrentUser.CurUser.UserId == d.UserId)
                        {
                            wordCount++;
                        }
                    }
                    var info = context.Info.ToList();
                    foreach (Info i in info)
                    {
                        if (CurrentUser.InfoCurUser.ProgressId == i.ProgressId)
                        {
                            var textcount = context.Info.Where(c => c.TextCount == CurrentUser.InfoCurUser.TextCount)
                                .FirstOrDefault();
                            textcount.TextCount = textCount;

                            CurrentUser.InfoCurUser.TextCount = textCount;

                            var rulecount = context.Info.Where(c => c.RuleCount == CurrentUser.InfoCurUser.RuleCount)
                                .FirstOrDefault();
                            rulecount.RuleCount = ruleCount;

                            CurrentUser.InfoCurUser.RuleCount = ruleCount;

                            var wordcount = context.Info.Where(c => c.WordCount == CurrentUser.InfoCurUser.WordCount)
                                .FirstOrDefault();
                            wordcount.WordCount = wordCount;

                            CurrentUser.InfoCurUser.WordCount = wordCount;
                            context.SaveChanges();
                        }
                    }
                    Texts.Value = Convert.ToDouble(CurrentUser.InfoCurUser.TextCount);
                    Rules.Value = Convert.ToDouble(CurrentUser.InfoCurUser.RuleCount);
                    Words.Value = Convert.ToDouble(CurrentUser.InfoCurUser.WordCount);
                }
                catch
                {
                    Windows.Window_error mwe = new Windows.Window_error();
                    mwe.ErrorText.Text = "Прочитайте тексты и изучите правила, чтобы увидеть свой прогресс..";
                    mwe.Show();
                }

            }
            DataContext = this;
        }
        private void SectionsText_MouseEnter(object sender, MouseEventArgs e)
        {
            SectionsText.Text = "Это ваш прогресс..";
        }

        private void SectionsText_MouseLeave(object sender, MouseEventArgs e)
        {
            SectionsText.Text = "This is Your Progress..";
        }

    }
}

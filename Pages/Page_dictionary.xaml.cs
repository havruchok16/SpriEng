using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Project.Database;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Project.Data;

namespace Project.Pages
{
    /// <summary>
    /// Логика взаимодействия для Page_dictionary.xaml
    /// </summary>
    public partial class Page_dictionary : Page
    {
        public Page_dictionary()
        {
            InitializeComponent();
        }

        private void SectionsText_MouseEnter(object sender, MouseEventArgs e)
        {
            SectionsText.Text = "Это ваш словарь..";
        }

        private void SectionsText_MouseLeave(object sender, MouseEventArgs e)
        {
            SectionsText.Text = "This is Your Dictionary..";
        }

        private void PageDictionary_Loaded(object sender, RoutedEventArgs e)
        {
            using (SpriengEntities context = new SpriengEntities())
            {
                var dictionary = context.Dictionary.ToList();
                foreach (Dictionary d in dictionary)
                {
                    if (CurrentUser.CurUser.UserId == d.UserId)
                    {
                        EngWord.Text += d.Word + "\n";
                        RuWord.Text += d.Translate + "\n";
                    }
                }          
            }
        }

        private void Find_word_Click(object sender, RoutedEventArgs e)
        {
            using (SpriengEntities context = new SpriengEntities())
            {
                bool check = false;
                string firstEng = "";
                string firstRu = "";
                var dictionary = context.Dictionary.ToList();
                if (Find_word_textbox.Text.Length != 0)
                {
                    foreach (Dictionary d in dictionary)
                    {
                        if (d.Word.ToLower().Contains(Find_word_textbox.Text.ToLower()) || d.Translate.ToLower().Contains(Find_word_textbox.Text.ToLower())
                            && CurrentUser.CurUser.UserId == d.UserId)
                        {
                            check = true;
                            firstEng = d.Word;
                            firstRu = d.Translate;
                            break;
                        }
                    }
                    if (check == true)
                    {
                        EngWord.Text = "";
                        RuWord.Text = "";
                        EngFirstWord.Text = "";
                        RuFirstWord.Text = "";
                        EngFirstWord.Text = firstEng;
                        RuFirstWord.Text = firstRu;
                        EngFirstWord.Style = this.Resources["EngRuFisrtWord"] as Style;
                        RuFirstWord.Style = this.Resources["EngRuFisrtWord"] as Style;
                        foreach (Dictionary d in dictionary)
                        {
                            if (CurrentUser.CurUser.UserId == d.UserId) 
                            {
                                if (firstEng != d.Word || firstRu != d.Translate)
                                {
                                    EngWord.Text += d.Word + "\n";
                                    RuWord.Text += d.Translate + "\n";
                                }
                            }  
                        }
                    }
                    else
                    {
                        EngWord.Text = "";
                        RuWord.Text = "";
                        EngFirstWord.Text = "";
                        RuFirstWord.Text = "";
                        EngFirstWord.Style = this.Resources["EngRuOtherWord"] as Style;
                        RuFirstWord.Style = this.Resources["EngRuOtherWord"] as Style;
                        foreach (Dictionary d in dictionary)
                        {
                            if (CurrentUser.CurUser.UserId == d.UserId)
                            {
                                EngWord.Text += d.Word + "\n";
                                RuWord.Text += d.Translate + "\n";
                            }
                        }
                        Windows.Window_error mwe = new Windows.Window_error();
                        mwe.ErrorText.Text = "Такого слова в вашем словаре нет, либо вы ввели слово с пробелом..";
                        mwe.Show();
                    }
                }
                else
                {
                    Windows.Window_error mwe = new Windows.Window_error();
                    mwe.ErrorText.Text = "Необходимо ввести слово..";
                    mwe.Show();
                }
                Find_word_textbox.Text = "";
            }
        }
        

        //проверка на ввод символов из клавиатуры
        private void LettersOnly(object sender, TextCompositionEventArgs e)
        {
            e.Handled = IsTextLettered(e.Text);
        }
        private static bool IsTextLettered(string str)
        {
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(@"[^\p{L}+$]");
            return reg.IsMatch(str);
        }
        //проверка на содержание только символов
        public static bool OnlyLetters(string s)
        {
            foreach (char c in s)
            {
                if (!Char.IsLetter(c))
                    return false;
            }
            return true;
        }
        //проверка на латиницу
        public static bool LatsChar(string ss)
        {
            bool check = false;
            for (int i = 0; i < ss.Length; i++)
            {
                if (((ss[i] >= 'a') && (ss[i] <= 'z')) || ((ss[i] >= 'A') && (ss[i] <= 'Z')))
                    check = true;
            }
            return check;
        }
        
        //добавить обновление страницы
        private void Add_word_Click(object sender, RoutedEventArgs e)
        {
            bool check = false;
            using (SpriengEntities context = new SpriengEntities())
            {
                var dictionary = context.Dictionary.ToList();
                if (OnlyLetters(Ru_word_textbox.Text) && !LatsChar(Ru_word_textbox.Text) && !Ru_word_textbox.Text.Contains(" ") &&
                    OnlyLetters(Eng_word_textbox.Text) && LatsChar(Eng_word_textbox.Text) && !Eng_word_textbox.Text.Contains(" ") &&
                    Ru_word_textbox.Text.Length < 30 && Eng_word_textbox.Text.Length < 30) 
                {

                    Dictionary dictio = new Dictionary(CurrentUser.CurUser.UserId, Eng_word_textbox.Text, Ru_word_textbox.Text);
                    foreach(Dictionary d in dictionary)
                    {
                        if (d.UserId == CurrentUser.CurUser.UserId && d.Word == Eng_word_textbox.Text && d.Translate == Ru_word_textbox.Text)
                        {
                            check = true;
                            break;
                        }
                    }
                    if (check == false) 
                    {
                        context.Dictionary.Add(dictio);
                        context.SaveChanges();
                        var dictionaryy = context.Dictionary.ToList();
                        EngWord.Text = "";
                        RuWord.Text = "";
                        EngFirstWord.Text = "";
                        RuFirstWord.Text = "";
                        foreach (Dictionary d in dictionaryy)
                        {
                            if (CurrentUser.CurUser.UserId == d.UserId)
                            {        
                                EngWord.Text += d.Word + "\n";
                                RuWord.Text += d.Translate + "\n";
                                EngFirstWord.Style = this.Resources["EngRuOtherWord"] as Style;
                                RuFirstWord.Style = this.Resources["EngRuOtherWord"] as Style;
                            }
                        }
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
                else
                {
                    Windows.Window_error mwe = new Windows.Window_error();
                    mwe.ErrorText.Text = "Поля должны быть заполнены, а слова в них должны быть только на кириллице (латинице), не содержать цифр и других символов..";
                    mwe.Show();
                }
            }
            Ru_word_textbox.Text = "";
            Eng_word_textbox.Text = "";
            
        }
    }
}

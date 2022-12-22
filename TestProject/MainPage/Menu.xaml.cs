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
using TestProject.DataFilleHelper;

namespace TestProject.MainPage
{
    /// <summary>
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class Menu : Page
    {
        public Menu()
        {
            InitializeComponent();

        }

        public void Word()
        {
            var helper = new WordHelper("Word/1.doc");

            var items = new Dictionary<string, string>
            {
                {"<Откого>", Name.Text },
                {"<Жалоба>", Report.Text },
                {"<Текст>", Text.Text },
                {"<Дата>", Date.Text },
                {"<Подпись>", FullName.Text }
            };

            helper.Process(items);
        }

        private void test_Click(object sender, RoutedEventArgs e)
        {
            Word();
        }
    }
}

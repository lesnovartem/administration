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

namespace TestProject.MainPage.PageWord
{
    /// <summary>
    /// Логика взаимодействия для PageWordEarth.xaml
    /// </summary>
    public partial class PageWordEarth : Page
    {
        int idClient;
        int idMessage;

        public PageWordEarth(int id, int idmes)
        {
            InitializeComponent();
            idClient = id;
            FullName.Text = DataFileHelper.odbObj.User.Where(x => x.Id == idClient).FirstOrDefault().Name;
            idMessage = idmes;
        }
        public void Word()
        {
            var helper = new WordHelper("Word/Выписка(Земля).doc");

            var items = new Dictionary<string, string>
            {
                {"<Test>", testd.Text },
                {"<Полное имя>", FullName.Text },
                {"<Дата>", Date.Text },
                {"<Номер>", Num.Text },
                {"<Ответ на номер>", AnswerOnNum.Text },
                {"<От числа>", FromNumber.Text },
                {"<Название документа>", NameDocument.Text },
                {"<Лицевой счет>", PersonalAccount.Text },
                {"<Информация по объекту>", InformationAboutTheObject.Text },
                {"<Год возведения жилого дома>", YearConstructionResidentialBuilding.Text },
                {"<Год возведения дома>", YearConstruction.Text },
                {"<Общая площадь>", TotalArea.Text },
                {"<Площадь>", Area.Text },
                {"<Материал стен>", WallMaterial.Text },
                {"<Материал>", Material.Text },
                {"<Материал кровли>", RoofMaterial.Text },
                {"<МатериалК>", MaterialK.Text },
                {"<Земля, находящаяся в личном пользовании хозяйства>", EarthUse.Text },
                {"<Не указана>", Owner.Text },
                {"<Основание>", Footing.Text }
            };

            helper.Process(items);
        }

        private void test_Click(object sender, RoutedEventArgs e)
        {
            Word();
            FrameApp.frmObj.Navigate(new PageSend(idClient, idMessage));
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }
    }
}

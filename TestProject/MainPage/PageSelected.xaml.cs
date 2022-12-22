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
using TestProject.MainPage.PageWord;

namespace TestProject.MainPage
{
    /// <summary>
    /// Логика взаимодействия для PageSelected.xaml
    /// </summary>
    public partial class PageSelected : Page
    {
        int idClient;
        int idMessage;
        public PageSelected(int id, int idMessage)
        {
            InitializeComponent();
            idClient = id;
            this.idMessage = idMessage;
        }

        private void Earth_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageWordEarth(idClient, idMessage));
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }

        private void PersonalAccount_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageWordEarth(idClient, idMessage));
        }

        private void Order_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageWordEarth(idClient, idMessage));
        }
    }
}

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
    /// Логика взаимодействия для PageMenuGuest.xaml
    /// </summary>
    public partial class PageMenuGuest : Page
    {
        int idUser;
        public PageMenuGuest(int id)
        {
            InitializeComponent();
            idUser = id;
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            Message message = new Message()
            {
                IdUser = idUser,
                Message1 = Text.Text,
                Date= DateTime.Now
            };
            DataFileHelper.odbObj.Message.Add(message);
            DataFileHelper.odbObj.SaveChanges();
            Text.Text = "";
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }
    }
}

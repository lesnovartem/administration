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
    /// Логика взаимодействия для PageMenuAdministr.xaml
    /// </summary>
    public partial class PageMenuAdministr : Page
    {
        public PageMenuAdministr()
        {
            InitializeComponent();
            List.ItemsSource = DataFileHelper.odbObj.Message.ToList();
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageSend((List.SelectedItem as Message).IdUser, (List.SelectedItem as Message).Id));
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            var listWork = List.SelectedItems.Cast<Message>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {listWork.Count()} запросы", "Внимание", 
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {

                    DataFileHelper.odbObj.Message.RemoveRange(listWork);
                    DataFileHelper.odbObj.SaveChanges();
                    MessageBox.Show("Удалено!");

                    List.ItemsSource = DataFileHelper.odbObj.Message.ToList();

            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }
    }
}

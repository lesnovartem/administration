using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Логика взаимодействия для PageLogin.xaml
    /// </summary>
    public partial class PageLogin : Page
    {
        public PageLogin()
        {
            InitializeComponent();
        }

        private void Reg_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageRegister());
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            var userObj = DataFileHelper.odbObj.User.FirstOrDefault(x => x.Email == Email.Text && x.Password == Password.Text);

            if (userObj != null) 
            {
                switch(userObj.Role) 
                {
                    case 1:
                        {
                           FrameApp.frmObj.Navigate(new PageMenuGuest(userObj.Id));
                            break;
                        }
                    case 2:
                        {
                            FrameApp.frmObj.Navigate(new PageMenuAdministr());
                            break;
                        }
                }
            }
            else
            {
                MessageBox.Show("Пользователь не найден");
            }
        }
    }
}

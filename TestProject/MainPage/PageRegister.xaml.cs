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
using TestProject.MainPage;

namespace TestProject.MainPage
{
    /// <summary>
    /// Логика взаимодействия для PageRegister.xaml
    /// </summary>
    public partial class PageRegister : Page
    {
        public PageRegister()
        {
            InitializeComponent();
        }

        private void Reg_Click(object sender, RoutedEventArgs e)
        {
            var userObj = DataFileHelper.odbObj.User.FirstOrDefault(x => x.Email == Email.Text);
            if (userObj == null)
            {
                if (Email.Text.Length > 6 && Password.Text.Length > 6 && Password.Text == RepeatPassword.Text && Name.Text.Length > 6)
                {
                    User user = new User()
                    {
                        Email = Email.Text,
                        Password = Password.Text,
                        Name = Name.Text,
                        Role = 1
                    };
                    DataFileHelper.odbObj.User.Add(user);
                    DataFileHelper.odbObj.SaveChanges();
                    FrameApp.frmObj.GoBack();
                }
                if (Password.Text.Length > 6)
                {
                    MessageBox.Show("Пароль должен быть больше 6 символов");
                }
            }
            else
                MessageBox.Show("Такой пользователь уже существует!");
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }
    }
}

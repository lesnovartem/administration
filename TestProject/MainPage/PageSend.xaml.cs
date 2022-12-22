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
using System.Net;
using System.Net.Mail;
using System.Net.Configuration;
using System.Windows.Forms;
using TestProject.DataFilleHelper;
using Microsoft.Office.Core;
using System.Data.Entity;

namespace TestProject.MainPage
{
    /// <summary>
    /// Логика взаимодействия для PageSend.xaml
    /// </summary>
    public partial class PageSend : Page
    {
        int idClient;
        int idMessage;
        public PageSend(int id, int idMessage)
        {
            InitializeComponent();
            idClient = id;
            Name.Text = DataFileHelper.odbObj.User.Where(x => x.Id == idClient).FirstOrDefault().Name;
            Email.Text = DataFileHelper.odbObj.User.Where(x => x.Id == idClient).FirstOrDefault().Email;
            Message.Text = DataFileHelper.odbObj.Message.Where(x => x.IdUser == idClient).FirstOrDefault().Message1;
            Pyt.Text = Properties.Settings.Default.Pyt;
        }

        private void Sand_Click(object sender, RoutedEventArgs e)
        {
            string fromMail = "practicalworktest@gmail.com";
            string fromPassword = "fiobpyndgajvjizn";

            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromMail);
            message.Subject = "Test Subject";
            message.To.Add(new MailAddress("lesnovartem6@gmail.com"));
            message.Body = "<html><body> Администрация бутурлинского муниципального округа </body></html>";
            message.IsBodyHtml = true;
            Attachment attachment = new Attachment(Pyt.Text);
            message.Attachments.Add(attachment);
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromMail, fromPassword),
                EnableSsl = true,
            };
            smtpClient.Send(message);      
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageSelected(idClient, idMessage));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var ofd = new Microsoft.Win32.OpenFileDialog();
            var result = ofd.ShowDialog();
            if (result == false) return;
            Pyt.Text = ofd.FileName;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }
    }
}

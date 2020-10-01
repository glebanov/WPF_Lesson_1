using System;
using System.Windows;
using System.Net;
using System.Net.Mail;


namespace WPFTests
{
    
    public partial class MainWindow 
    {
        public MainWindow()=> InitializeComponent();

        private void OnSendButtonClick(object sender, RoutedEventArgs e)
        {
            var to = new MailAddress("glebanovwebsite@gmail.com", "Николай"); //кому отправляем почту
            var from = new MailAddress("mikolya1212@yandex.ru", "Николай"); //от кого отправляем почту

            var message = new MailMessage(from, to); //создаем почтовое отправление 

            message.Subject = "Заголовок письма от " + DateTime.Now; //Создаем заголовок письма
            message.Body = "Текст тестового письма +" + DateTime.Now; //Создаем текст письма

            //Создаем клиента smtp сервера
            var client = new SmtpClient("smtp.yandex.ru", 25);
            client.EnableSsl = true;

            //Указываем учетные данные пользователя
            client.Credentials = new NetworkCredential
            {
                UserName = LoginEdit.Text,
                SecurePassword = PasswordEdit.SecurePassword
            };

            client.Send(message);
        }
    }
}

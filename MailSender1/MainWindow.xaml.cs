﻿using MailSender1.lib;
using MailSender1.Models;
using System.Net.Mail;
using System.Windows;


namespace MailSender1
{

    public partial class MainWindow 
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void OnSendButtonClick(object Sender, RoutedEventArgs E)
        {
            var sender = SendersList.SelectedItem as Sender;
            if (sender is null) return;

            if (!(RecipientsList.SelectedItem is Recipient recipient)) return;
            if (!(ServersList.SelectedItem is Server server)) return;
            if (!(MessagesList.SelectedItem is Message message)) return;

            var send_service = new MailSenderService
            {
                ServerAddress = server.Address,
                ServerPort = server.Port,
                UseSSL = server.UseSSL,
                Login = server.Login,
                Password = server.Password,
            };

            try
            {
                send_service.SendMessage(sender.Address, recipient.Address, message.Subject, message.Body);
            }

            catch (SmtpException error)
            {
                MessageBox.Show(
                    "Ошибка при отправке почты" + error.Message, "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }      
    }
}

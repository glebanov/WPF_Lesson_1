using System;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;

namespace MailSender1.lib
{
    public class MailSenderService
    {
        public string ServerAddress { get; set; }

        public int ServerPort { get; set; }

        public bool UseSSL { get; set; }

        public string Login { get; set; }

        public string Password { get; set; } 
        public void SendMessage(string SenderAddress, string RecipientAddress, string Subject, string Body)
        {
            var from = new MailAddress(SenderAddress); //от кого отправляем почту
            var to = new MailAddress(RecipientAddress); //кому отправляем почту




            using (var message = new MailMessage(from, to))
            {
                message.Subject = Subject; //Создаем заголовок письма
                message.Body = Body; //Создаем текст письма

                //Создаем клиента smtp сервера
                using (var client = new SmtpClient(ServerAddress, ServerPort))
                {
                    client.EnableSsl = UseSSL;

                    //Указываем учетные данные пользователя
                    client.Credentials = new NetworkCredential
                    {
                        UserName = Login,
                        Password = Password
                    };

                    try
                    {
                        client.Send(message);
                    }
                    catch (SmtpException e)
                    {
                        Trace.TraceError(e.ToString());
                        throw;
                    }
                }
               
            } 


           
        }
    }
}

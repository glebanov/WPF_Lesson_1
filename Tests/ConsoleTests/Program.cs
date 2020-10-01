using System;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text.Json;

namespace ConsoleTests
{
    class Program
    {
        static void Main(string[] args)
        {
            var to = new MailAddress("glebanovwebsite@gmail.com", "Николай"); //кому отправляем почту
            var from = new MailAddress("mikolya1212@yandex.ru", "Николай"); //от кого отправляем почту

            var message = new MailMessage(from, to); //создаем почтовое отправление 

            message.Subject = "Заголовок письма от " + DateTime.Now; //Создаем заголовок письма
            message.Body = "Текст тестового письма +" + DateTime.Now; //Создаем текст письма

            //Создаем клиента smtp сервера
            var client = new SmtpClient("smtp.yandex.ru", 25);

            //Указываем учетные данные пользователя
            client.Credentials = new NetworkCredential
            {
                UserName = "user_name",
                Password = "PassWord!"
            };

            client.Send(message);

            Console.WriteLine("Hello World!");
        }
    }
}

using MailSender1.Data;
using MailSender1.Infrastructure.Commands;
using MailSender1.Models;
using MailSender1.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace MailSender1.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        private string _Title = "Тестовое окно";

        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }

        private ObservableCollection<Server> _Servers;
        private ObservableCollection<Sender> _Senders;
        private ObservableCollection<Recipient> _Recipients;
        private ObservableCollection<Message> _Messages;

        public ObservableCollection<Server> Servers
        {
            get => _Servers;
            set => Set(ref _Servers, value);
        }

        public ObservableCollection<Sender> Senders
        {
            get => _Senders;
            set => Set(ref _Senders, value);
        }

        public ObservableCollection<Recipient> Recipients
        {
            get => _Recipients;
            set => Set(ref _Recipients, value);
        }

           public ObservableCollection<Message> Messages
        {
            get => _Messages;
            set => Set(ref _Messages, value);
        }

        private Server _SelectedServer;
        public Server SelectedServer
        {
            get => _SelectedServer;
            set => Set(ref _SelectedServer, value);
        }

        private Sender _SelectedSender;
        public Sender SelectedSender
        {
            get => _SelectedSender;
            set => Set(ref _SelectedSender, value);
        }

        private Recipient _SelectedRecipient;
        public Recipient SelectedRecipient
        {
            get => _SelectedRecipient;
            set => Set(ref _SelectedRecipient, value);
        }

        private Message _SelectedMessage;
        public Message SelectedMessage
        {
            get => _SelectedMessage;
            set => Set(ref _SelectedMessage, value);
        }

        #region Команды

        #region CreateNewServerCommand

        private ICommand _CreateNewServerCommand;

        public ICommand CreateNewServerCommand => _CreateNewServerCommand
            ??= new LambdaCommand(OnCreateNewServerCommandExecuted, CanCreateNewServerCommandExecuted);

        private bool CanCreateNewServerCommandExecuted(object p) => true;

        private void OnCreateNewServerCommandExecuted(object p)
        {
            MessageBox.Show("Создание нового сервера", "Управление серверами");
        }
        #endregion

        #region EditServerCommand

        private ICommand _EditServerCommand;

        public ICommand EditServerCommand => _EditServerCommand
            ??= new LambdaCommand(OnEditServerCommandExecuted, CanEditServerCommandExecuted);

        private bool CanEditServerCommandExecuted(object p) => p is Server || SelectedServer != null;

        private void OnEditServerCommandExecuted(object p)
        {
            var server = p as Server ?? SelectedServer;
            if (server is null) return;

            MessageBox.Show($"Редактирование сервера{server.Address}!", "Управление серверами");
        }
        #endregion

        #region DeleteServerCommand

        private ICommand _DeleteServerCommand;

        public ICommand DeleteServerCommand => _DeleteServerCommand
            ??= new LambdaCommand(OnDeleteServerCommandExecuted, CanDeleteServerCommandExecuted);

        private bool CanDeleteServerCommandExecuted(object p) => p is Server || SelectedServer != null;

        private void OnDeleteServerCommandExecuted(object p)
        {
            var server = p as Server ?? SelectedServer;
            if (server is null) return;

            Servers.Remove(server);
            SelectedServer = Servers.FirstOrDefault();

            //MessageBox.Show($"Удаление сервера{server.Address}!", "Управление серверами");
        }
        #endregion

        #endregion


        public MainWindowViewModel()
        {
            Servers = new ObservableCollection<Server>(TestData.Servers);
            Senders = new ObservableCollection<Sender>(TestData.Senders);
            Recipients = new ObservableCollection<Recipient>(TestData.Recipients);
            Messages = new ObservableCollection<Message>(TestData.Messages);
        }
    }
}

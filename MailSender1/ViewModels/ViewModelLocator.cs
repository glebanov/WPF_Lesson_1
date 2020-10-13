using Microsoft.Extensions.DependencyInjection;

namespace MailSender1.ViewModels
{
    class ViewModelLocator
    {
        public MainWindowViewModel MainWindowModel => App.Service.GetRequiredService<MainWindowViewModel>();
    }
}

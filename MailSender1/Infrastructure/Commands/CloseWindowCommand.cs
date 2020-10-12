using System.Linq;
using System.Windows;
using MailSender1.Infrastructure.Commands.Base;

namespace MailSender1.Infrastructure.Commands
{
    class CloseWindowCommand : Command 
    {
        protected override void Execute (object p)
        {
            var window = p as Window;

            if (window is null)
                window = Application.Current.Windows.Cast<Window>().FirstOrDefault(w => w.IsFocused);

            if (window is null)
                window = Application.Current.Windows.Cast<Window>().FirstOrDefault(w => w.IsActive);

            window?.Close();

        }
    }
}

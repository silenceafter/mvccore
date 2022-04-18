using lesson1.Infrastructure.Commands.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace lesson1.Infrastructure.Commands;

public class ShowMessageCommand : CreateCommand
{
    public override void Execute(object? parameter)
    {
        if (parameter is null) return;
        var message = parameter as string ?? parameter.ToString();
        MessageBox.Show(message, "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
    }

    public override bool CanExecute(object? parameter)
    {
        if (parameter is null) return false;
        var message = parameter as string ?? parameter.ToString();
        if (message?.Length > 0) return true;
        return false;
    }
}

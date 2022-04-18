using lesson1.Infrastructure.Commands.Base;
using lesson1.Views.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson1.Infrastructure.Commands;

public class CustomCommand : CreateCommand
{
    public override void Execute(object? parameter)
    {
        if (parameter is null) return;
        var message = parameter as string ?? parameter.ToString();
        //
        ChildWindow childWindow = new();
        childWindow.Show();
    }

    public override bool CanExecute(object? parameter)
    {
        if (parameter is null) return false;
        var message = parameter as string ?? parameter.ToString();
        if (message?.Length > 0) return true;
        return false;
    }
}

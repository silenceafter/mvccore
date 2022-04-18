using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace lesson1.Infrastructure.Commands.Base;

public abstract class CreateCommand : ICommand
{
    public event EventHandler? CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }

    public virtual bool CanExecute(object? parameter) => true;

    public abstract void Execute(object? parameter);
}

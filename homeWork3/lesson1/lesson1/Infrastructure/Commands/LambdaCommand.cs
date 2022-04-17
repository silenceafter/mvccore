using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson1.Infrastructure.Commands.Base;

public class LambdaCommand : Command
{
    public LambdaCommand(Action<object?> OnExecute, Func<object?, bool>? OnCanExecute = null)
    {
        _onExecute = OnExecute;
        _onCanExecute = OnCanExecute;
    }

    private readonly Action<object?> _onExecute;
    private readonly Func<object?, bool>? _onCanExecute;

    public override void Execute(object? parameter)
    {
        _onExecute(parameter);
    }

    public override bool CanExecute(object? parameter)
    {
        return base.CanExecute(parameter) && (_onCanExecute?.Invoke(parameter) ?? true);
    }
}

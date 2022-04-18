using lesson1.Infrastructure.Commands;
using lesson1.Infrastructure.Commands.Base;
using lesson1.ViewModels.Base;
using lesson1.Views.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace lesson1.ViewModels;

public class MainWindowViewModel : ViewModel
{
    private string? _title = "Главное окно";
    private string _value = null!;
    private ICommand? _showMessageCommand;
    private ICommand? _customCommand;
    private ICommand? _factoryCommand;

    public string? Title
    {
        get => _title;
        set => Set(ref _title, value);
    }

    public string Value { get => _value; set => Set(ref _value, value); }
    public ICommand ShowMessageCommand => _showMessageCommand
        ??= new LambdaCommand(OnShowMessageCommandExecuted, CanShowMessageCommandExecute);

    public ICommand CustomCommand => _customCommand
        ??= new LambdaCommand(OnCustomCommandExecuted, CanCustomCommandExecute);

    public ICommand FactoryCommand => _factoryCommand
        ??= new LambdaCommand(OnFactoryCommandExecuted, CanFactoryCommandExecute);

    private bool CanShowMessageCommandExecute(object? parameter)
    {
        if (parameter is null) return false;
        var message = parameter as string ?? parameter.ToString();
        if (message?.Length > 0) return true;
        return false;
    }

    private void OnShowMessageCommandExecuted(object? parameter)
    {
        if (parameter is null) return;
        var message = parameter as string ?? parameter.ToString();
        MessageBox.Show(message, "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
    }

    private bool CanCustomCommandExecute(object? parameter)
    {
        if (parameter is null) return false;
        var message = parameter as string ?? parameter.ToString();
        if (message?.Length > 0) return true;
        return false;
    }

    private void OnCustomCommandExecuted(object? parameter)
    {
        if (parameter is null) return;
        var message = parameter as string ?? parameter.ToString();
        //
        ChildWindow child = new ChildWindow();
        child.Show();
    }
    
    private bool CanFactoryCommandExecute(object? parameter)
    {
        if (parameter is null) return false;
        var message = parameter as string ?? parameter.ToString();
        if (message?.Length > 0) return true;
        return false;
    }

    private void OnFactoryCommandExecuted(object? parameter)
    {
        if (parameter is null) return;
        var message = parameter as string ?? parameter.ToString();
        //
        CreateCommand? command = null;        
        if (message?.Trim().ToUpper() == "SHOW_M")
        {
            //showMessage
            var creator = new ShowMessageCreator();
            if (creator is not null) command = creator.FactoryMethod();
        }

        if (message?.Trim().ToUpper() == "CHILD_W")
        {
            //childWindow
            var creator = new CustomCreator();
            if (creator is not null) command = creator.FactoryMethod();
        }

        if (command is not null)
        {
            if (command.CanExecute(message))
            {
                command.Execute(message);
            }
        }                
    }
}

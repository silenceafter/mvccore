using lesson1.Infrastructure.Commands.Base;
using lesson1.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace lesson1.ViewModels;

public class MainWindowViewModel : ViewModel//INotifyPropertyChanged
{
    //public event PropertyChangedEventHandler? PropertyChanged;
    //public event EventHandler? TitleChanged;

    private string? _title = "Главное окно";
    private string _value = null!;
    private ICommand? _showMessageCommand;

    public string? Title
    {
        get => _title;
        set => Set(ref _title, value);
        /*set
        {
            if (_title == value) return;
            _title = value;
            //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Title)));
            OnPropertyChanged();//nameof(Title)
        }*/
    }

    public string Value { get => _value; set => Set(ref _value, value); }
    public ICommand ShowMessageCommand => _showMessageCommand
        ??= new LambdaCommand(OnShowMessageCommandExecuted, CanShowMessageCommandExecute);

    private bool CanShowMessageCommandExecute(object? parameter)
    {
        if (parameter is null) return false;
        var message = parameter as string ?? parameter.ToString();
        if (message?.Length > 0) return true;
        return false; ;
    }

    private void OnShowMessageCommandExecuted(object? parameter)
    {
        if (parameter is null) return;
        var message = parameter as string ?? parameter.ToString();
        MessageBox.Show(message, "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lesson1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }

    /*public class CustomCommand<T> : ICommand
    {
        internal CustomCommand(Func<T, bool> canExecuteAction, Action<T> executeAction)
        {
            _canExecuteAction = canExecuteAction;
            _executeAction = executeAction;
        }

        private Action<T> _executeAction;
        private Func<T, bool> _canExecuteAction;        

        public bool CanExecute(object? parameter)
        {
            return _canExecuteAction((T)parameter);
        }

        public void Execute(object? parameter)
        {
            _executeAction((T)parameter);
        }
        
        public event EventHandler? CanExecuteChanged;

        internal void OnCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, EventArgs.Empty);
            }
        }

        public static ICommand CreateCommand(Func<bool> canExecuteAction, Action executeAction, out Action canExecuteChangedAction)
        {
            CustomCommand command = new lesson1.CustomCommand(canExecuteAction, executeAction);
            canExecuteChangedAction = command.OnCanExecuteChanged;
            return command;
        }
    }*/
}
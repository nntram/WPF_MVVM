using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF_LoginForm.ViewModels
{
    public class ViewModelCommand : ICommand
    {
        // Fields
        private readonly Action<object> _excuteAction;
        private readonly Predicate<object>? _canExcuteAction;

        // Constructors
        public ViewModelCommand(Action<object> excuteAction)
        {
            _excuteAction = excuteAction;
            _canExcuteAction = null;
        }

        public ViewModelCommand(Action<object> excuteAction, Predicate<object>? canExcuteAction)
        {
            _excuteAction = excuteAction;
            _canExcuteAction = canExcuteAction;
        }

        // Events
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove {  CommandManager.RequerySuggested -= value;}
        }

        // Methods
        public bool CanExecute(object? parameter)
        {
            return _canExcuteAction == null || _canExcuteAction(parameter!);
        }

        public void Execute(object? parameter)
        {
            _excuteAction(parameter!);
        }
    }
}

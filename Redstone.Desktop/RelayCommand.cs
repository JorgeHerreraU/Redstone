using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Redstone.Desktop
{
    public class RelayCommand : ICommand
    {
        private Func<bool> _canExecute;
        private Action _execute;

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged = delegate { };

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }

        public bool CanExecute(object parameter) => _canExecute?.Invoke() ?? true;

        public void Execute(object parameter) => _execute.Invoke();
    }

    public class RelayCommand<T> : ICommand
    {
        private Func<T, bool> _canExecute;
        private Action<T> _execute;

        public RelayCommand(Action<T> execute, Func<T, bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged = delegate { };

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }

        public bool CanExecute(object parameter) => _canExecute?.Invoke((T)parameter) ?? true;

        public void Execute(object parameter) => _execute.Invoke((T)parameter);
    }
}

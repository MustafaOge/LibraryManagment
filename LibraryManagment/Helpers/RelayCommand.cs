using System.Windows.Input;
namespace LibraryManagment.Commands

{
    /// <summary>
    /// RelayCommand supporting both synchronous and asynchronous methods

    /// </summary>
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Func<object, Task> _executeAsync;
        private readonly Func<object, bool> _canExecute;
        private bool _isExecuting;

        // sync constructor
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        // async constructor
        public RelayCommand(Func<object, Task> executeAsync, Func<object, bool> canExecute = null)
        {
            _executeAsync = executeAsync ?? throw new ArgumentNullException(nameof(executeAsync));
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            if (_isExecuting) return false;

            return _canExecute == null || _canExecute(parameter);
        }

        public async void Execute(object parameter)
        {
            if (!CanExecute(parameter)) return;

            try
            {
                _isExecuting = true;
                RaiseCanExecuteChanged();

                if (_executeAsync != null)
                {
                    await _executeAsync(parameter);
                }
                else
                {
                    _execute(parameter);
                }
            }
            finally
            {
                _isExecuting = false;
                RaiseCanExecuteChanged();
            }
        }

        public void RaiseCanExecuteChanged()
        {
            CommandManager.InvalidateRequerySuggested();
        }
    }
}
using System;
using System.Windows.Input;

namespace CheshireBookstore.Infrastructure.Commands
{
    class DialogResultCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool? DialogResult { get; set; }

        public bool CanExecute(object parameter) => App.ActiveWindow != null;

        public void Execute(object parameter)
        {
            if (!CanExecute(parameter)) return;

            var window = App.CurrentWindow;
            var dialog_result = DialogResult;

            // Позволяем dialog_result передавать команде в виде параметра
            if (parameter != null)
                dialog_result = (bool?)Convert.ChangeType(parameter, typeof(bool?));

            window.DialogResult = dialog_result;
            window.Close();
        }
    }
}

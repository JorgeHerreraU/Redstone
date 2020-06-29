using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Redstone.Desktop.Controls
{
    public class DialogService : IDialogService
    {
        public void ShowMessageBox(string message)
        {
            MessageBox.Show(message);
        }

        public bool ShowConfirmationDialog(string message)
        {
            var messageBox = MessageBox.Show(message, "Confirmation", MessageBoxButton.YesNo);
            return messageBox == MessageBoxResult.Yes;
        }
    }
}

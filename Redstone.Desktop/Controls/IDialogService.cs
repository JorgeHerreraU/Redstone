using System;
using System.Collections.Generic;
using System.Text;

namespace Redstone.Desktop.Controls
{
    public interface IDialogService
    {
        void ShowMessageBox(string message);
        bool ShowConfirmationDialog(string message);
    }
}

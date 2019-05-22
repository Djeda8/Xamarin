using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DialogService.Services.Dialog
{
    public interface IDialogService
    {
        Task ShowMessage(string title, string message);

        Task<bool> Question(string title, string question, string res1, string res2);
    }
}

using System.Threading.Tasks;

namespace Login.Services.Dialog
{
    interface IDialogService
    {
        Task<bool> Question(string title, string question, string res1, string res2);
        Task ShowMessage(string title, string message);
    }
}
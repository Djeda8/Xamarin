using System.Threading.Tasks;

namespace BarcodeScanning.Sevices
{
    public interface IDialogService
    {
        Task<bool> Question(string title, string question, string res1, string res2);
        Task ShowMessage(string title, string message);
    }
}
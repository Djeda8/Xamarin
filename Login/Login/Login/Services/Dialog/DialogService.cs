using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Login.Services.Dialog
{
    class DialogService : IDialogService
    {

        public async Task ShowMessage(string title, string message)
        {
            await App.Current.MainPage.DisplayAlert(title, message, "Aceptar");
        }

        public async Task<bool> Question(string title, string question, string res1, string res2)
        {
            bool R = await App.Current.MainPage.DisplayAlert(title, question, res1, res2);

            return R;
        }
    }
}

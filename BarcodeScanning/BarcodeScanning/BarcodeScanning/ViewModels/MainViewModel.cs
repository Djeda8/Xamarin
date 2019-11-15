using BarcodeScanning.Sevices;
using BarcodeScanning.ViewModels.Base;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using ZXing;
using ZXing.Mobile;
using ZXing.Net.Mobile.Forms;

namespace BarcodeScanning.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        protected readonly IDialogService DialogService;

        private string _number1, _number2;

        public string Number1
        {
            get { return _number1; }
            set
            {
                _number1 = value;
                RaisePropertyChanged();
            }
        }

        public string Number2
        {
            get { return _number2; }
            set
            {
                _number2 = value;
                RaisePropertyChanged();
            }
        }

        public MainViewModel()
        {
            DialogService = new DialogService();
            Number1 = "0";
            Number2 = "0";
        }

        public DelegateCommand<string> ScannerCommand => new DelegateCommand<string>(ScannerAsync);

        private void ScannerAsync(string type)
        {
            try
            {
                var options = new MobileBarcodeScanningOptions();
                options.PossibleFormats = new List<BarcodeFormat>
                {
                    BarcodeFormat.QR_CODE,
                    BarcodeFormat.CODE_128,
                    BarcodeFormat.EAN_13
                };

                var page = new ZXingScannerPage(options) { Title = "Scanner" };
                var closeItem = new ToolbarItem { Text = "Close" };
                closeItem.Clicked += (object sender, EventArgs e) =>
                {
                    page.IsScanning = false;
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        Application.Current.MainPage.Navigation.PopModalAsync();
                    });
                };
                page.ToolbarItems.Add(closeItem);
                page.OnScanResult += (result) =>
                {
                    page.IsScanning = false;

                    Device.BeginInvokeOnMainThread(() =>
                    {
                        Application.Current.MainPage.Navigation.PopModalAsync();
                        if (string.IsNullOrEmpty(result.Text))
                        {
                            DialogService.ShowMessage("Warning", $"No valid code has been scanned");
                        }
                        else
                        {
                            if (type == "1")
                                Number1 = result.Text;
                            else
                                Number2 = result.Text;
                        }
                    });
                };

                Application.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(page) { BarTextColor = Color.White, BarBackgroundColor = Color.CadetBlue }, true);
            }
            catch (Exception) { }
        }
    }
}

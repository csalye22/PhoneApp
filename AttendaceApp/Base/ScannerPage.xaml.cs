using ZXing.Net.Maui;

namespace Base;

public partial class ScannerPage : ContentPage
{
	public ScannerPage()
	{
		InitializeComponent();
	}
    private void btnBack_Clicked(object sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }

    private void CameraBarcodeReaderView_BarcodesDetected(object sender, BarcodeDetectionEventArgs e)
    {
        foreach (var barcode in e.Results)
        {
            string code = e.Results[0].Value;
            Device.BeginInvokeOnMainThread(() =>
            {
                barcodeContents.Text = code;

            });
        }
    }
}
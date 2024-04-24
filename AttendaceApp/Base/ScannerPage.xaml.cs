using Base.Models;
using Base.Services;
using ZXing.Net.Maui;

namespace Base;

public partial class ScannerPage : ContentPage
{
    public string uuid = "uuid7";
    public string response;
    AttendRecord? contents = null; // prevents qr code from being scanned repeatedly

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
                // take this out of final release
                barcodeContents.Text = code;
            });

            //sends request to database, if prevents multiple scans
            if (contents == null)
            {
                contents = GetPostData(code);
                PostRequest(contents);
            }
        }
    }

    private AttendRecord GetPostData(string contents)
    {
        AttendRecord data = new AttendRecord(uuid, Convert.ToInt32(contents));
        return data;
    }

    private async void PostRequest(AttendRecord record)
    {
        await AttendanceAPI.PostAttendance(record);
    }
}
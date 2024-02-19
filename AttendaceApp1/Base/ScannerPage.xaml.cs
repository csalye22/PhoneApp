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
}
namespace Base;

public partial class InboxPage : ContentPage
{
	public InboxPage()
	{
		InitializeComponent();
	}

    private void btnBack_Clicked(object sender, EventArgs e)
    {
		Navigation.PopModalAsync();
    }
}
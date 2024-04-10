namespace Base;

public partial class NavigationPage : ContentPage
{
    public NavigationPage()
    {
        InitializeComponent();
    }
    private void btnScanner_Clicked(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new ScannerPage());
    }
    private void btnSemester_Clicked(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new SemesterPage());
    }
    private void btnInbox_Clicked(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new InboxPage());
    }
    private void btnBack_Clicked(object sender, EventArgs e) /*Returns you back a page*/
    {
        Navigation.PopModalAsync();
    }

}
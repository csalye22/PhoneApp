namespace Base;

public partial class AttendancePage : ContentPage
{
    public AttendancePage()
    {
        InitializeComponent();
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
    }

    // SQL server pass: 110494
    private void GetAttendance()
    {

    }

    private void btnBack_Clicked(object sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }
}
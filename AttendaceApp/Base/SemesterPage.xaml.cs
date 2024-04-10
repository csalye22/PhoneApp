namespace Base;

public partial class SemesterPage : ContentPage
{
    public SemesterPage()
    {
        InitializeComponent();
    }
    private void btnBack_Clicked(object sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }

    private void btnAttendance_Clicked(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new AttendancePage());
    }
}
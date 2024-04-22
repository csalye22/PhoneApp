using Base.Services;
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
        GetAttendance();
    }

    // SQL server pass: 110494
    private async void GetAttendance()
    {
        AttendanceAPI api = new AttendanceAPI();
        var results = await api.GetAttendance();
        Console.Write(results.ToString());
    }

    private void btnBack_Clicked(object sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }
}
namespace Base
{
    public partial class LoginPage : ContentPage
    {

        public LoginPage()
        {
            InitializeComponent();
        }

        private void btnSubmit_Clicked(object sender, EventArgs e)
        {
            //Trims white space from input
            if (txtUsername.Text.Trim() == "")
                DisplayAlert("Empty Field", "Field must not be empty", "ok");
            if (txtPassword.Text.Trim() == "")
                DisplayAlert("Empty Field", "Field must not be empty", "ok");
            //Test to make sure text is transferred; will instead be transferred to database
            lbltempUsername.Text = txtUsername.Text.Trim();
            lbltempPassword.Text = txtPassword.Text.Trim();
        }
        //Navigation Bar
        private void navScanner_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new ScannerPage());
        }
        private void navSemester_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new SemesterPage());
        }
    }

}

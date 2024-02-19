namespace Base
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void btnSubmit_Clicked(object sender, EventArgs e)
        {
            if (txtUsername.Text.Trim() == "")
                DisplayAlert("Empty Field", "Field must not be empty", "ok");
            if (txtPassword.Text.Trim() == "")
                DisplayAlert("Empty Field", "Field must not be empty", "ok");

            lbltempUsername.Text = txtUsername.Text.Trim();
            lbltempPassword.Text = txtPassword.Text.Trim();
        }
    }

}

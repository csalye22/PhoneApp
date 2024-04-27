using System.Text.Json;
using System.Net.Http;
using System.Text;
using System;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;



namespace Base
{
    public partial class LoginPage : ContentPage
    {  
        public LoginPage()
        {
            InitializeComponent();
        }
        
    
        

        private async void btnSubmit_Clicked(object sender, EventArgs e)
        {
            // Trim white space from input
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                await DisplayAlert("Empty Field", "Fields must not be empty", "OK");
                return; // Exit the method if fields are empty
            }

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = "https://localhost:7167/api/Authentication/login";

                    var requestData = new
                    {
                        Username = username,
                        Password = password
                    };

                    string jsonData = JsonSerializer.Serialize(requestData);

                    var request = new HttpRequestMessage(HttpMethod.Post, apiUrl);
                    request.Content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.SendAsync(request);

                    if (response.IsSuccessStatusCode)
                    {
                        var successResponse = await response.Content.ReadAsStringAsync();

                        await DisplayAlert("Success", "Login successful!", "OK");

                        using (HttpClient client2 = new HttpClient())
                        {
                            string uuidRequest = $"https://localhost:7167/api/Students/get_uuid?StudentUserName={requestData.Username}";
                            var studentUuid = await client2.GetStringAsync(uuidRequest);

                            Preferences.Set("uuid", studentUuid);
                            Debug.WriteLine(studentUuid);
                        }

                        await Navigation.PushAsync(new NavigationPage());
                    }
                    else
                    {
                        await DisplayAlert("Error", $"Failed to submit data. Status code: {response.StatusCode}", "OK");
                    }
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }
        }

        private void navNavigation_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new NavigationPage());
        }
    }
}

using System.Text.Json;
using System.Net.Http;
using System.Text;


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
            string email = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                await DisplayAlert("Empty Field", "Fields must not be empty", "OK");
                return; // Exit the method if fields are empty
            }

            try
            {
                // Create an instance of HttpClient
                using (HttpClient client = new HttpClient())
                {
                    // Define the URL of your API endpoint
                    string apiUrl = "https://localhost:7167/login";

                    // Create a data object to hold your POST data
                    var requestData = new
                    {
                        Email = email,
                        Password = password
                    };

                    // Serialize data to JSON
                    string jsonData = JsonSerializer.Serialize(requestData);

                    // Create a new HttpRequestMessage with the POST method and your API endpoint
                    var request = new HttpRequestMessage(HttpMethod.Post, apiUrl);
                    request.Content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                    // Send the POST request and await the response
                    HttpResponseMessage response = await client.SendAsync(request);

                    // Check if the response is successful (status code in the range 200-299)
                    if (response.IsSuccessStatusCode)
                    {
                        // Read the response content as a string
                        string responseContent = await response.Content.ReadAsStringAsync();

                        //  here you can do something with the response data, such as displaying it or navigating to another page

                        // display message and response
                        await DisplayAlert("Success", responseContent, "OK");

                        // here you specify the redirect. 
                        await Navigation.PushAsync(new NavigationPage());
                    }
                    else
                    {
                        // If the response is not successful, display an error message
                        await DisplayAlert("Error", $"Failed to submit data. Status code: {response.StatusCode}", "OK");
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any other exceptions that occur during the HTTP request
                await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }
        }


        //Navigation Bar
        private void navNavigation_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new NavigationPage());
        }
    }

}

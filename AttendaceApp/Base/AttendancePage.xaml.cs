using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Base
{
    public partial class AttendancePage : ContentPage
    {
        private const string uuid = "uuid7";
        private const string apiUrl = $"https://localhost:7167/api/Attends/by-id2/{uuid}";

        public ObservableCollection<AttendanceRecord> AttendanceRecords { get; set; }

        public AttendancePage()
        {
            InitializeComponent();
            AttendanceRecords = new ObservableCollection<AttendanceRecord>();
            FetchAndDisplayData();
        }

        private async void FetchAndDisplayData()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        var records = JsonConvert.DeserializeObject<List<AttendanceRecord>>(json);
                        foreach (var record in records)
                        {
                            AttendanceRecords.Add(record);
                            Debug.WriteLine(record);
                        }
                        attendanceListView.ItemsSource = AttendanceRecords;
                    }
                    else
                    {
                        // Handle unsuccessful response
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exception
                Console.WriteLine("Error: " + ex.Message);
            }
        }


        private void btnBack_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}

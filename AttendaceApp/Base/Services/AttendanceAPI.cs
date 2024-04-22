using Newtonsoft.Json;
using static Base.Models.AttendanceModel;
namespace Base.Services
{
    class AttendanceAPI
    {
        public async Task<Root> GetAttendance()
        {
            var httpClient = new HttpClient();
            string url = "https://localhost:7167/api/Attends";
            var jsonResponse = await httpClient.GetStringAsync(url);
            var jsonObjects = JsonConvert.DeserializeObject<Root>(jsonResponse);
            return jsonObjects;
        }

        //public async Task<Attendance> PostAttendance(string response)
        //{
        //    var httpClient = new HttpClient();
        //    string url = "https://localhost:7167/api/Attends/studentpost";
        //    var jsonData = response;
        //}
    }
}

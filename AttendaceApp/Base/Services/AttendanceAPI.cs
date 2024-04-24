using Newtonsoft.Json;
using static Base.Models.AttendanceModel;
namespace Base.Services
{
    class AttendanceAPI
    {
        public async Task<Value> GetAttendance()
        {
            var httpClient = new HttpClient();
            var studentUuid = "uuid1";
            string url = $"https://localhost:7167/api/Attends/by-id2/{studentUuid}";
            var jsonResponse = await httpClient.GetStringAsync(url);

            var attends = JsonConvert.DeserializeObject<Value>(jsonResponse);
            Console.WriteLine(attends);
            return attends;
        }

        //public async Task<Attendance> PostAttendance(string response)
        //{
        //    var httpClient = new HttpClient();
        //    string url = "https://localhost:7167/api/Attends/studentpost";
        //    var jsonData = response;
        //}
    }
}

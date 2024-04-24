using Base.Models;
using Newtonsoft.Json;
using System.Text;
using static Base.Models.AttendanceModel;
namespace Base.Services
{
    class AttendanceAPI
    {
        public async Task<Value> GetAttendance()
        {
            var httpClient = new HttpClient();
            var studentUuid = "uuid7";
            string url = $"https://localhost:7167/api/Attends/by-id2/{studentUuid}";
            var jsonResponse = await httpClient.GetStringAsync(url);

            var attends = JsonConvert.DeserializeObject<Value>(jsonResponse);
            Console.WriteLine(attends);
            return attends;
        }

        public static async Task<HttpResponseMessage> PostAttendance(AttendRecord data)
        {
            var httpClient = new HttpClient();
            string url = "https://localhost:7167/api/Attends/studentpost";
            string jsonData = JsonConvert.SerializeObject(data);
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.SendAsync(request);
            return response;
        }
    }
}

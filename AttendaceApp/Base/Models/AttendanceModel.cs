using System.Text.Json.Serialization;

namespace Base.Models
{
    public class AttendanceModel
    {
        // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
        public class Root : AttendanceModel
        {
            [JsonPropertyName("$id")]
            public string id { get; set; }

            [JsonPropertyName("$values")]
            public List<Value> values { get; set; }
        }

        public class Value : AttendanceModel
        {
            [JsonPropertyName("$id")]
            public string id { get; set; }

            [JsonPropertyName("studentUuid")]
            public string studentUuid { get; set; }

            [JsonPropertyName("classId")]
            public int classId { get; set; }

            [JsonPropertyName("attendanceDate")]
            public DateTime attendanceDate { get; set; }

            [JsonPropertyName("class")]
            public object @class { get; set; }

            [JsonPropertyName("studentUu")]
            public object studentUu { get; set; }
        }
    }
}
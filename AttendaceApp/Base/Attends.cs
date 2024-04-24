
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base
{
    public class AttendanceRecord
    {
        public string StudentUuid { get; set; }
        public int ClassId { get; set; }
        public DateTime AttendanceDate { get; set; }


        public override string ToString()
        {
            return $"Student UUID: {StudentUuid}, Class ID: {ClassId}, Attendance Date: {AttendanceDate}";
        }
    }

    public class AttendanceResponse
    {
        public List<AttendanceRecord> Values { get; set; }
    }
}

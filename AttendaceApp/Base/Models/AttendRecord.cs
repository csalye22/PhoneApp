namespace Base.Models
{
    class AttendRecord
    {
        public string StudentUuid { get; set; }
        public int ClassId { get; set; }

        public AttendRecord(string uuid, int cid)
        {
            StudentUuid = uuid;
            ClassId = cid;
        }
    }
}

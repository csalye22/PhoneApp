namespace Base.Models
{
    class PostResponse
    {
        public byte ResponseId { get; set; }
        public PostResponse(byte response)
        {
            ResponseId = response;
        }
    }
}

namespace myvapp.Models
{
    public class ValentineResponse
    {
        public int Id { get; set; }
        public string Response { get; set; }
        public DateTime RespondedAt { get; set; }
        public string? Device { get; set; }
    }

}

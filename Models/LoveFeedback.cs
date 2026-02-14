namespace myvapp.Models
{
    public class LoveFeedback
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string? Message { get; set; }
        public DateTime SubmittedAt { get; set; }
    }

}

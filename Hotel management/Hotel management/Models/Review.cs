namespace Hotel_management.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Text { get; set; }
        public string Email { get; set; }
        public DateTime Date { get; set; }
        public Hotel Hotel { get; set; }
        public int HotelId { get; set; }
        public AppUser AppUser { get; set; }
        public string AppUserId { get; set; }
    }
}

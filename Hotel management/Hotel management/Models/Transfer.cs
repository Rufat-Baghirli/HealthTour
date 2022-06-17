namespace Hotel_management.Models
{
    public class Transfer
    {
        public int Id { get; set; }
        public string Car { get; set; }
        public string Route { get; set; }
        public double Price { get; set; }
        public bool IsVip { get; set; }
    }
}

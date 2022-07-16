using System.ComponentModel.DataAnnotations;

namespace Hotel_management.Models
{
    public class ExtraPrice
    {
        public int Id { get; set; }
        public float BabyPrice { get; set; }
        public float BabyPricewithtreatment { get; set; }
        public float ChildPrice { get; set; }
        public float ChildPricewithtreatment { get; set; }
        public float YoungPrice { get; set; }
        public float YoungPricewithtreatment { get; set; }

        public Hotel? Hotel { get; set; }
        public int? HotelId { get; set; }
        public bool IsDeleted { get; set; }



    }
}

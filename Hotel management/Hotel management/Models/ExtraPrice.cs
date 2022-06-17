using System.ComponentModel.DataAnnotations;

namespace Hotel_management.Models
{
    public class ExtraPrice
    {
        public int Id { get; set; }
        public float BabyPrice { get; set; }
        public float ChildPrice { get; set; }
        public float YoungPrice { get; set; }
        [Required(ErrorMessage ="Otaq tipi mutleq secilmelidir.")]
        public Hotel? Hotel { get; set; }
        public int? HotelId { get; set; }
        public bool IsDeleted { get; set; }


    }
}

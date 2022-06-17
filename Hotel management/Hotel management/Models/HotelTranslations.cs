using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;

namespace Hotel_management.Models;


    public class HotelTranslations
    {
        public int Id { get; set; }
        public string Description_en { get; set; }
        public string Description_ru { get; set; }
        public int HotelId { get; set; }
        public Hotel hotel { get; set; }
        



    }


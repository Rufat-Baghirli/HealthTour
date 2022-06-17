namespace Hotel_management.Models
{
    public class ForeignDomesticTourTranslations
    {

        public int Id { get; set; }
        public string ForeignTourDescription_en { get; set; }
        public string ForeignTourDescription_ru { get; set; }
        public string DomesticTourDescription_en { get; set; }
        public string DomesticTourDescription_ru { get; set; }
        public ForeignDomesticTour ForeignDomesticTour { get; set; }
        public int ForeignDomesticTourId { get; set; }
    }
}

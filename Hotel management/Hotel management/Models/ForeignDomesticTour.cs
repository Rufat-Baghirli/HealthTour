namespace Hotel_management.Models
{
    public class ForeignDomesticTour
    {
        public int Id { get; set; }
        public string ForeignTourDescription { get; set; }
        public string DomesticTourDescription { get; set; }
        public ForeignDomesticTourTranslations? ForeignDomesticTourTanslations { get; set; }


    }
}

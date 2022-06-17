using Hotel_management.Models;

namespace Hotel_management.ViewModels.TourViewModel
{
    public class TourVM
    {
        public IEnumerable<Tour>Tours { get; set; }
        public ForeignDomesticTour foreignDomesticTour { get; set; }
        public TurContact TurContact { get; set; }
        public IEnumerable<XariciTur>xariciTurlar { get; set; }
        public IEnumerable<DaxiliTur> daxiliTurlar{ get; set; }


    }
}

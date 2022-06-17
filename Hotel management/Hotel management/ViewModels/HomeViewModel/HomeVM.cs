using Hotel_management.Models;
using Hotel_management.ViewModels.SearchRoomViewModel;

namespace Hotel_management.ViewModels.HomeViewModel
{
    public class HomeVM
    {
        public IEnumerable<Hotel>?Hotels { get; set; }
        public SearchRoomVM SearchRoomViewModel { get; set; }

    }
}

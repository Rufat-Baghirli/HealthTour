using Hotel_management.Models;
using Hotel_management.ViewModels.SearchRoomViewModel;
using System.ComponentModel.DataAnnotations;

namespace Hotel_management.ViewModels.HotelViewModel
{
    public class HotelVM
    {   
        public virtual IEnumerable<Hotel>Hotels{ get; set; }
        public virtual Hotel Hotel { get; set; }
        public virtual Review Reviews { get; set; }
        public SearchRoomVM SearchRoomViewModel { get; set; }

    }
}

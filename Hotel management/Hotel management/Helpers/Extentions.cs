

namespace Hotel_management.Helpers
{
    public  class Extentions
    {
      
        public static int Compare( DateTime checkout, DateTime checkin)
        {


             if(DateTime.Compare(checkout, checkin) <= 0)
            {
                return 1;
            }
            else
            {
                return (checkout.Subtract(checkin).Days);
            }
                
        }
    
       

        



    }
}

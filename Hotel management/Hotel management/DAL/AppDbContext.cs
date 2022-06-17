using Hotel_management.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hotel_management.DAL
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<HotelFeature> HotelFeatures { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomFeatures> RoomFeatures { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<HotelImages> HotelImages { get; set; }
        public DbSet<RoomImages> RoomImages { get; set; }
        public DbSet<HotelStars> HotelStars { get; set; }
        public DbSet<HotelFeatureDetails> HotelFeatureDetails { get; set; }
        public DbSet<RoomFeatureDetail> RoomFeatureDetails { get; set; }
        public DbSet<Child> Children { get; set; }
        public DbSet<Adult> Adults { get; set; }
        public DbSet<ExtraPrice> ExtraPrices { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet <Booking> Bookings { get; set; }
        public DbSet <Tour> Tours { get; set; }
        public DbSet<TurContact> TurContacts { get; set; }
        public DbSet<Review>Reviews { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<HotelTranslations> HotelTranslations { get; set; }
        public DbSet<ForeignDomesticTour>ForeignDomesticTours { get; set; }
        public DbSet<XariciTur>XariciTurlar { get; set; }
        public DbSet<DaxiliTur> DaxiliTurlar { get; set; }
        public DbSet<AboutImg> AboutImages { get; set; }
        public DbSet<HealthTourContact>HealthTourContacts { get; set; }
         public DbSet<ForeignDomesticTourTranslations> ForeignDomesticTourTranslations { get; set; }
        public DbSet<HotelFeatureTranslations> HotelFeatureTranslations { get; set; }
        public DbSet<HotelFeatureDetailsTranslations> HotelFeatureDetailsTranslations { get; set; }
        public DbSet<RoomFeaturesTranslation> RoomFeaturesTranslation { get; set; }
        public DbSet<RoomFeatureDetailTranslations> RoomFeatureDetailTranslations { get; set; }
        public DbSet<TreatmentTranslations> TreatmentTranslations { get; set; }
        public DbSet<TourTranslations> TourTranslations { get; set; }
        public DbSet<Transfer>Transfers { get; set; }
        public DbSet<Seasons>Seasons { get; set; }
        public DbSet<HighSeason> HighSeasons { get; set; }
        public DbSet<MidSeason> MidSeasons { get; set; }
        public DbSet<LowSeason> LowSeasons { get; set; }
        public DbSet<SpecialDays> SpecialDays { get; set; }





















    }

}

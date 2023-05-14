using InscaleApi.Models;

namespace InscaleApi.DataBase
{
    public class StaticDB
    {
        public static List<Resource> ResourcesDb { get; } = new List<Resource>()
        {
            new Resource { Id = 1, Name = "Electricians", Quantity = 10},
            new Resource { Id = 2, Name = "Painters", Quantity = 10},
            new Resource { Id = 3, Name = "Cleaners", Quantity = 10},
            new Resource { Id = 4, Name = "Gardeners", Quantity = 10},
            new Resource { Id = 5, Name = "Plumbers", Quantity = 10}
        };

        public static List<Booking> BookingsDb { get; set; } = new List<Booking>()
        {
            new Booking { Id = 1, ResourceId = 3, DateFrom = DateTime.Parse("5/6/2023"), DateTo = DateTime.Parse("5/8/2023"), BookedQuantity = 3 },
            new Booking { Id = 2, ResourceId = 5, DateFrom = DateTime.Parse("5/16/2023"), DateTo = DateTime.Parse("5/28/2023"), BookedQuantity = 2 }
        };
    }
}

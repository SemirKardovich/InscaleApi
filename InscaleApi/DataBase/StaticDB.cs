using InscaleApi.Models;

namespace InscaleApi.DataBase
{
    public class StaticDB
    {
        public static List<Resource> ResourcesDb { get; } = new List<Resource>()
        {
            new Resource { Id = 1, Name = "Electricians", Quantity = 10, Info = "Installation or repair, we have the know-how to repair. Trust us with your electrical care, for peace of mind beyond compare."},
            new Resource { Id = 2, Name = "Painters", Quantity = 10, Info = "From drab to fab, we'll give your walls some pizzazz. Let us bring color to your space, with a professional and flawless grace."},
            new Resource { Id = 3, Name = "Cleaners", Quantity = 10, Info = "From dust to grime, we'll make your home shine. Let us handle the cleaning chores, so you can relax and enjoy yours."},
            new Resource { Id = 4, Name = "Gardeners", Quantity = 10, Info = "From seeds to blooms, we'll transform your garden rooms. Let us create an outdoor retreat, where nature and beauty meet."},
            new Resource { Id = 5, Name = "Plumbers", Quantity = 10, Info = "From clogs to leaks, we have the skills to fix what wreaks. Trust us with your pipes and drains, we'll take away all your plumbing pains."}
        };

        public static List<Booking> BookingsDb { get; set; } = new List<Booking>()
        {
            new Booking { Id = 1, ResourceId = 3, DateFrom = DateTime.Parse("5/6/2023"), DateTo = DateTime.Parse("5/8/2023"), BookedQuantity = 3 },
            new Booking { Id = 2, ResourceId = 5, DateFrom = DateTime.Parse("5/16/2023"), DateTo = DateTime.Parse("5/28/2023"), BookedQuantity = 2 }
        };
    }
}

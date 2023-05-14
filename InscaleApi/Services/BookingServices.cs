using InscaleApi.DataBase;
using InscaleApi.Models;
using System.ComponentModel.Design;

namespace InscaleApi.Services
{
    public class BookingServices
    {
        private List<Booking> _bookings;
        public BookingServices(List<Booking> bookings)
        {
            _bookings = bookings;
        }

        public void AddBooking(Booking booking)
        {
            ValidateBooking(booking);

            if (IsBookingAvailable(booking))
            {
                StaticDB.BookingsDb.Add(booking);
            }
            else
            {
                throw new InvalidOperationException("The resource is not available for the selected timespan.");
            }
        }

        private static void ValidateBooking(Booking booking)
        {
            if (booking.DateFrom < DateTime.Now)
            {
                throw new ArgumentException("Booking start date cannot be in the past.");
            }

            if (booking.DateTo < booking.DateFrom)
            {
                throw new ArgumentException("Booking end date cannot be earlier than the start date.");
            }

            if (booking.BookedQuantity <= 0)
            {
                throw new ArgumentException("Booked quantity must be greater than zero.");
            }

            List<int> resourceIds = StaticDB.ResourcesDb.Select(r => r.Id).ToList();
            if (!resourceIds.Contains(booking.ResourceId))
            {
                throw new ArgumentException("Invalid resource ID. Resource does not exist.");
            }
        }

        private Resource FindResourceById(List<Resource> resources, Booking booking)
        {
            return resources.Find(resource => resource.Id == booking.ResourceId);
        }

        private int CalculateTotalBookedQuantity(List<Booking> allBookings, Booking booking)
        {
            return allBookings.Where(b => b.ResourceId == booking.ResourceId &&
                                b.DateFrom < booking.DateTo &&
                                b.DateTo > booking.DateFrom)
                    .Sum(b => b.BookedQuantity);
        }
        private bool IsBookingAvailable(Booking booking)
        {
            var bookingService = new BookingServices(StaticDB.BookingsDb);
            var resourseService = new ResourceServices(StaticDB.ResourcesDb);
            Resource resource = FindResourceById(resourseService.GetAllResources(), booking);
            if (resource != null)
            {
                int totalBookedQuantity = CalculateTotalBookedQuantity(bookingService.GetAllBookings(), booking);

                return totalBookedQuantity < resource.Quantity;
            }

            return false;
        }



        private List<Booking> GetAllBookings()
        {
            return _bookings;
        }
    }
}

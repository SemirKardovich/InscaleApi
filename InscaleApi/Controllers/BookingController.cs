using InscaleApi.DataBase;
using InscaleApi.Models;
using InscaleApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace InscaleApi.Controllers
{
    [ApiController]
    [Route("api/booking")]
    public class BookingController : ControllerBase
    {
        private BookingServices _bookingServices;

        public BookingController()
        {
            _bookingServices = new BookingServices(StaticDB.BookingsDb);
        }

        [HttpPost]
        public ActionResult BookingResource(Booking booking)
        {
            try
            {
                _bookingServices.AddBooking(booking);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(statusCode: 500, value: "Something went wrong with the server. Please contact support at +2 555 221155112");
            }

            return Ok(value: "Resource booked successfully!");
        }

    }
}

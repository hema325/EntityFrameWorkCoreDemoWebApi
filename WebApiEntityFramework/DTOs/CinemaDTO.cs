using WebApiEntityFramework.Common.Mapping;
using WebApiEntityFramework.Entities;

namespace WebApiEntityFramework.DTOs
{
    public class CinemaDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Latitude { get; set; } // Y
        public double Longitude { get; set; } // X

        public CinemaOfferDTO offer { get; set; }
        public IEnumerable<CinemaHallDTO> CinemaHalls { get; set; }
    }
}

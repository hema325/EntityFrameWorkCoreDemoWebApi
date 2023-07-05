using NetTopologySuite.Geometries;

namespace WebApiEntityFramework.Entities
{
    public class Cinema
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Point Location { get; set; }
        public Address Address { get; set; }   

        public CinemaOffer offer { get; set; }
        public List<CinemaHall> CinemaHalls { get; set; }
        public CinemaDetail CinemaDetail { get; set; }
    }
}

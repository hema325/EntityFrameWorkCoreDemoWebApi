using WebApiEntityFramework.Enums;

namespace WebApiEntityFramework.Entities
{
    public class CinemaHall
    {
        public int Id { get; set; }
        public decimal Cost { get; set; }
        public CinemaHallType? Type { get; set; }
        public int? CinemaId { get; set; } //configure it as set null on delete
        public Currency Currency { get; set; }
        public List<Movie> Movies { get; set; }
        public Cinema Cinema { get; set; }
    }
}

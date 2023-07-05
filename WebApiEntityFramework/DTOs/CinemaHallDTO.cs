using WebApiEntityFramework.Common.Mapping;
using WebApiEntityFramework.Entities;
using WebApiEntityFramework.Enums;

namespace WebApiEntityFramework.DTOs
{
    public class CinemaHallDTO:IMapFrom<CinemaHall>,IMapTo<CinemaHall>
    {
        public int Id { get; set; }
        public decimal Cost { get; set; }
        public CinemaHallType? Type { get; set; }
    }
}

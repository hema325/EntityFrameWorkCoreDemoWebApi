using WebApiEntityFramework.Common.Mapping;
using WebApiEntityFramework.Entities;

namespace WebApiEntityFramework.DTOs
{
    public class CinemaOfferDTO:IMapFrom<CinemaOffer>,IMapTo<CinemaOffer>
    {
        public DateTime Begin { get; set; }
        public DateTime End { get; set; }
        public decimal DiscountPercentage { get; set; }
    }
}

using AutoMapper;
using NetTopologySuite;
using WebApiEntityFramework.DTOs;
using WebApiEntityFramework.Entities;

namespace WebApiEntityFramework.Profiles
{
    public class CinemaProfile:Profile
    {
        public CinemaProfile()
        {
            CreateMap<Cinema, CinemaDTO>().ForMember(dto => dto.Latitude, options => options.MapFrom(cinema => cinema.Location.X))
                .ForMember(dto => dto.Longitude, options => options.MapFrom(cinema => cinema.Location.Y));

            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(4326);
            CreateMap<CinemaDTO, Cinema>().ForMember(cinema => cinema.Location, options => options.MapFrom(dto => geometryFactory.CreatePoint(new NetTopologySuite.Geometries.Coordinate(dto.Longitude, dto.Latitude))));
        }
    }
}

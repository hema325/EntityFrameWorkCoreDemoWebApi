using AutoMapper;
using WebApiEntityFramework.DTOs;
using WebApiEntityFramework.Entities;

namespace WebApiEntityFramework.Profiles
{
    public class MovieProfile:Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, MovieDTO>().ForMember(dto => dto.Cinemas, options => options.MapFrom(m => m.CinemaHalls.OrderByDescending(ch=>ch.Cinema.Name).Select(ch=>ch.Cinema)))
                .ForMember(dto => dto.Actors, options => options.MapFrom(m => m.MovieActors.Select(ma=>ma.Actor)))
                .ForMember(dto => dto.Genres, options => options.MapFrom(m=>m.Genres.OrderByDescending(g=>g.Name).Where(g=>!g.Name.Contains("m"))));

            CreateMap<MovieCreationDTO, Movie>().ForMember(movie => movie.Genres, options => options.MapFrom(dto => dto.GenreIds.Select(id => new Genre { Id = id })))
            .ForMember(movie => movie.CinemaHalls, options => options.MapFrom(dto => dto.CinemaHallIds.Select(id => new CinemaHall { Id = id })));
        }
    }
}

using WebApiEntityFramework.Common.Mapping;
using WebApiEntityFramework.Entities;

namespace WebApiEntityFramework.DTOs
{
    public class MovieActorCreationDTO:IMapTo<MovieActor>
    {
        public int ActorId { get; set; }
        public string Character { get; set; }
        public int Order { get; set; }
    }
}

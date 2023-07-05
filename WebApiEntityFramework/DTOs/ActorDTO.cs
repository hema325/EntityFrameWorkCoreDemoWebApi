using WebApiEntityFramework.Common.Mapping;
using WebApiEntityFramework.Entities;

namespace WebApiEntityFramework.DTOs
{
    public class ActorDTO : IMapFrom<Actor>,IMapTo<Actor>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}

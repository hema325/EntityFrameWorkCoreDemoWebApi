using WebApiEntityFramework.Common.Mapping;
using WebApiEntityFramework.Entities;

namespace WebApiEntityFramework.DTOs
{
    public class GenreDTO : IMapFrom<Genre>,IMapTo<Genre>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

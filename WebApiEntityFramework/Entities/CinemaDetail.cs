namespace WebApiEntityFramework.Entities
{
    public class CinemaDetail
    {
        public int Id { get; set; }
        public string History { get; set; }
        public string Values { get; set; }
        public string Missions { get; set; }
        public string CodeOfCoduct { get; set; }
        public Cinema Cinema { get; set; }
    }
}

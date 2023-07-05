namespace WebApiEntityFramework.KeyLessEntities
{
    public class MoviesWithCount
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AmountGenres { get; set; }
        public int AmountActors { get; set; }
        public int AmountCinemas { get; set; }

    }
}

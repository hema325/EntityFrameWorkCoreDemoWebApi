namespace WebApiEntityFramework.DTOs
{
    public class MovieFilterDTO
    {
        public string? Title { get; set; }

        public bool InCinemas { get; set; }

        public bool UpcomingReleases { get; set; }
    }
}

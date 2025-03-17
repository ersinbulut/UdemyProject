namespace RapidApiConsume.Models
{
    public class ApiMovie
    {
        public List<ApiMovieViewModel> Results { get; set; }
    }

    public class ApiMovieViewModel
    {
        public int rank { get; set; }
        public string Series_Title { get; set; }
        public string Released_Year { get; set; }
        public string Poster_Link { get; set; }
    }
}

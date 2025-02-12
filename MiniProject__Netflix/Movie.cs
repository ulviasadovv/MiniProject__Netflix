namespace MiniProject__Netflix
{
    internal class Movie : BaseModel
    {
        private string Name { get; set; }
        private Genre Genre { get; set; }
        private int ReleaseYear { get; set; }
        private int Duration { get; set; }
        private bool IsWatched { get; set; } = false;

        public Movie(string name, Genre genre, int releaseYear, int duration) : base()
        {
            Name = name;
            Genre = genre;
            ReleaseYear = releaseYear;
            Duration = duration;
        }
    }
}

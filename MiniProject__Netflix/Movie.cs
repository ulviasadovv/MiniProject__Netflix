namespace MiniProject__Netflix
{
    internal class Movie : BaseModel
    {
        public Movie() { }
        public Movie(string name, Genre genre, int releaseYear, int duration) : base()
        {
            Name = name;
            Genre = genre;
            ReleaseYear = releaseYear;
            Duration = duration;
        }

        public string Name { get; set; }
        public Genre Genre { get; set; }
        public int ReleaseYear { get; set; }
        public int Duration { get; set; }
        public int NumberOfView { get; set; }

        public override string ToString()
        {
            return $"Movie name: {Name}";
        }
    }
}

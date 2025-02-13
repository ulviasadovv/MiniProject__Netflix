namespace MiniProject__Netflix
{
    internal class Genre : BaseModel
    {
        public Genre(string name) : base()
        {
            Name = name;
        }

        public string Name { get; set;}
    }
}

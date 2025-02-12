namespace MiniProject__Netflix
{
    internal class Genre : BaseModel
    {
        public string Name { get; set;}
        public Genre(string name) : base()
        {
            Name = name;
        }
    }
}

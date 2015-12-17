using System;

namespace CastGetter.Interface
{
    public class Episode
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Duration { get; set; }
        public bool AlreadySync { get; set; }
        public bool Downloaded { get; set; }
        public Uri LinkToRessource { get; set; }
    }
}

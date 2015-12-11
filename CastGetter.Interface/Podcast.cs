using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastGetter.Interface
{
    public class Podcast
    {
        public Podcast()
        {
            Episodes = new List<Episode>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public List<Episode> Episodes { get; set; }
    }
}

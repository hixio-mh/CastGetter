using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastGetterLib
{
    public class Episode
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Duration { get; set; }
        public bool AlreadySync { get; set; }
        public bool Downloaded { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastGetter.Interface
{
    /// <summary>
    /// A Podcast Source
    /// </summary>
    public interface IPodcastSource
    {
        Podcast GetPodcast(string address);
    }
}

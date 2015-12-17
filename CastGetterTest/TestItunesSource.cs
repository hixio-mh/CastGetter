using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CastGetterLib;
using CastGetter.Interface;

namespace CastGetterTest
{
    [TestClass]
    public class TestItunesSource
    {
        [TestMethod]
        public void TestParsing()
        {
            TunesPodcastSource _source = new TunesPodcastSource();

            Podcast cast = _source.GetPodcast("http://thepointjax.com/Podcast/podcast.xml");
        }
    }
}

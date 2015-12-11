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
            ITunesPodcastSource _source = new ITunesPodcastSource();

            Podcast cast = _source.GetPodcast("http://thepointjax.com/Podcast/podcast.xml");
        }
    }
}

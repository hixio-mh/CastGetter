using System;
using CastGetter.Interface;
using System.Xml.Linq;

namespace CastGetterLib
{
    public class ITunesPodcastSource : IPodcastSource
    {
        public Podcast GetPodcast(string address)
        {
            Podcast pcast = new Podcast();

            var xml = XDocument.Load(address);

            XNamespace ns = "http://www.itunes.com/dtds/podcast-1.0.dtd";

             

            foreach (var item in xml.Descendants("item"))
            {
                var title = item.Element("title").Value;
                var summary = item.Element(ns + "summary").Value;
                var author = item.Element(ns + "author").Value;
                var duration = item.Element(ns + "duration").Value;
                var pubDate = item.Element("pubDate").Value;

                pcast.Episodes.Add(new Episode() {
                    Name = title,
                    Author = author,
                    Description = summary,
                    Duration = duration
                });
            }

            return pcast;
        }
    }
}

using System;
using CastGetter.Interface;
using System.Xml.Linq;
using System.Drawing;
using System.Net;
using System.IO;

namespace CastGetterLib
{
    public class TunesPodcastSource : IPodcastSource
    {
        public Podcast GetPodcast(string address)
        {
            Podcast pcast = new Podcast();

            var xml = XDocument.Load(address);

            XNamespace ns = "http://www.itunes.com/dtds/podcast-1.0.dtd";
            WebClient client = new WebClient();
            //Get Podcast Information
            foreach (var item in xml.Descendants("channel"))
            {
                var title = item.Element("title").Value;
                var summary = item.Element("description").Value;
                var author = item.Element(ns + "author").Value;
                var imgPath = item.Element(ns + "image").Attribute("href").Value;

                pcast.Description = summary;
                pcast.Name = title;
                byte[] imgData = client.DownloadData(imgPath);
                MemoryStream mStream = new MemoryStream(imgData);
                pcast.Image = Image.FromStream(mStream);
                //Leave foreach loop because we are ready
                break;
            }

            //Get Episodes
            foreach (var item in xml.Descendants("item"))
            {
                var title = item.Element("title").Value;
                var summary = item.Element(ns + "summary").Value;
                var author = item.Element(ns + "author").Value;
                var duration = item.Element(ns + "duration").Value;
                var pubDate = item.Element("pubDate").Value;

                var enclosure = item.Element("enclosure").Attribute("url").Value;

                var fileUri = new System.Uri(enclosure);

                pcast.Episodes.Add(new Episode() {
                    Name = title,
                    Author = author,
                    Description = summary,
                    Duration = duration,
                    LinkToRessource = fileUri,
                    AlreadySync = false
                });
            }

            return pcast;
        }
    }
}

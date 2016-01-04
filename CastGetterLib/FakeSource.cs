using CastGetter.Interface;
using System;
using System.Collections.Generic;

namespace CastGetterLib
{
    public class FakeSource : IPodcastSource
    {
        private string _name = "Fake Source";

        public string SourceName
        {
            get
            {
                return _name;
            }
        }

        public Podcast GetPodcast(string address)
        {
            Episode ep1 = new Episode()
            {
                Author = "Michael Tissen",
                Date = DateTime.Now,
                Description = "Die erste Folge",
                Duration = "kurz",
                Downloaded = false,
                AlreadySync = false,
                LinkToRessource = new Uri("http://www.contoso.com/ep1.mp3"),
                Name = "Episode 1"
            };

            Episode ep2 = new Episode()
            {
                Author = "Michael Tissen",
                Date = DateTime.Now,
                Description = "Die zweite Folge",
                Duration = "02:01:00",
                Downloaded = false,
                AlreadySync = false,
                LinkToRessource = new Uri("http://www.contoso.com/ep2.mp3"),
                Name = "Episode 2"
            };

            Podcast pcast = new Podcast()
            {
                Description = "Eine Fake Podcast den es nicht gibt",
                Name = "Der FakeCast",
                Episodes = new List<Episode>() { ep1, ep2 },
                ImagePath = new Uri(@"C:\Users\rubik\Pictures\Crocs Cave\Vogel\Ei.png")
            };

            return pcast;
        }

        public override string ToString()
        {
            return _name;
        }
    }
}

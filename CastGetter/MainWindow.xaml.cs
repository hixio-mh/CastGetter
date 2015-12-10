using CastGetterLib;
using System;
using System.Collections.Generic;
using System.Windows;

namespace CastGetter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<Podcast> items = new List<Podcast>();
            items.Add(new Podcast() { Name = "Celluleute", Description = "Ein Filmpodcast" });
            lvPodcasts.ItemsSource = items;

            List<Episode> episodeList = new List<Episode>();
            episodeList.Add(new Episode() {Name = "Horrorfilme",
                AlreadySync =false,
                Date = DateTime.Now,
                Description = "Es geht um die besten Horrorfilme",
                Downloaded = false,
                Duration = "2:05:00" });
            episodeList.Add(new Episode()
            {
                Name = "Weihnachtsfilme",
                AlreadySync = false,
                Date = DateTime.Now,
                Description = "Es geht um die besten Weihnachtsfilme",
                Downloaded = false,
                Duration = "2:20:00"
            });
            lvEpisodes.ItemsSource = episodeList;
        }
    }
}

using Caliburn.Micro;
using CastGetter.Interface;
using System.Collections.ObjectModel;
using System;
using System.Windows.Media;
using System.Net;
using System.IO;
using System.Linq;

namespace CastGetter.ViewModels
{

    public class PodcastViewModel : PropertyChangedBase,IHandle<Podcast>
    {
        private ObservableCollection<Podcast> _podcasts;
        //private ObservableCollection<Episode> _episodes;

        private IEventAggregator _events;

        private WebClient client;

        public PodcastViewModel(IEventAggregator events)
        {
            _podcasts = new ObservableCollection<Podcast>();
            //_episodes = new ObservableCollection<Episode>();
            DownloadColor = new SolidColorBrush(Colors.Green);
            _events = events;
            _events.Subscribe(this);
        }

        #region Commands

        public void DownloadButton()
        {
            if (client == null)
            {
                client = new WebClient();
            }
            var hasExtension = Path.HasExtension(SelectedEpisode.LinkToRessource.AbsolutePath);
            if (hasExtension)
            {
                string filePath = CleanFileName(SelectedPodcast.Name);
                
                client.DownloadFile(SelectedEpisode.LinkToRessource, filePath);
            }
        }

        #endregion

        #region Properties

        private SolidColorBrush _DownLoadColor;

        public SolidColorBrush DownloadColor
        {
            get { return _DownLoadColor; }
            set { _DownLoadColor = value; }
        }


        private Podcast _SelectedPodcast;
            
        public Podcast SelectedPodcast
        {
            get { return _SelectedPodcast; }
            set {
                _SelectedPodcast = value;
                NotifyOfPropertyChange();
            }
        }

        private Episode _SelectedEpisode;

        public Episode SelectedEpisode
        {
            get { return _SelectedEpisode; }
            set {
                _SelectedEpisode = value;
                NotifyOfPropertyChange();
            }
        }



        public ObservableCollection<Podcast> PodcastList
        {
            get { return _podcasts; }
            set { _podcasts = value; }
        }

        public void Handle(Podcast message)
        {
            PodcastList.Add(message);
            SelectedPodcast = PodcastList[PodcastList.IndexOf(message)];
        }

        #endregion

        #region Helper

        private static string CleanFileName(string fileName)
        {
            return Path.GetInvalidFileNameChars().Aggregate(fileName, (current, c) => current.Replace(c.ToString(), string.Empty));
        }

        #endregion
    }
}

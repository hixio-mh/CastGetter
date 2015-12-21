using Caliburn.Micro;
using CastGetter.Interface;
using System.Collections.ObjectModel;
using System;

namespace CastGetter.ViewModels
{

    public class PodcastViewModel : PropertyChangedBase,IHandle<Podcast>
    {
        private ObservableCollection<Podcast> _podcasts;
        private ObservableCollection<Episode> _episodes;

        private IEventAggregator _events;

        public PodcastViewModel(IEventAggregator events)
        {
            _podcasts = new ObservableCollection<Podcast>();
            _episodes = new ObservableCollection<Episode>();

            _events = events;
            _events.Subscribe(this);
        }

        #region Properties
        public ObservableCollection<Podcast> PodcastList
        {
            get { return _podcasts; }
            set { _podcasts = value; }
        }

        public ObservableCollection<Episode> EpisodeList
        {
            get { return _episodes; }
            set { _episodes = value; }
        }

        public void Handle(Podcast message)
        {
            PodcastList.Add(message);
            foreach (var ep in message.Episodes)
            {
                EpisodeList.Add(ep);
            }
        }

        #endregion
    }
}

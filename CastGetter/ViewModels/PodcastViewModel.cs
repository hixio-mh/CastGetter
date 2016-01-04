using Caliburn.Micro;
using CastGetter.Interface;
using System.Collections.ObjectModel;
using System;
using System.Windows.Media;

namespace CastGetter.ViewModels
{

    public class PodcastViewModel : PropertyChangedBase,IHandle<Podcast>
    {
        private ObservableCollection<Podcast> _podcasts;
        //private ObservableCollection<Episode> _episodes;

        private IEventAggregator _events;

        public PodcastViewModel(IEventAggregator events)
        {
            _podcasts = new ObservableCollection<Podcast>();
            //_episodes = new ObservableCollection<Episode>();

            _events = events;
            _events.Subscribe(this);
        }

        #region Properties

        private Podcast _SelectedPodcast;
            
        public Podcast SelectedPodcast
        {
            get { return _SelectedPodcast; }
            set {
                _SelectedPodcast = value;
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
    }
}

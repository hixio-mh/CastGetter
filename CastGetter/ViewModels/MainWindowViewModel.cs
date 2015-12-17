using Caliburn.Micro;
using CastGetter.Interface;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace CastGetter.ViewModels
{
    public class MainWindowViewModel : PropertyChangedBase
    {
        private ObservableCollection<Podcast> _podcasts;
        private ObservableCollection<Episode> _episodes;

        private readonly IPodcastSource _source;

        public MainWindowViewModel(IPodcastSource source)
        {
            _source = source;
            _podcasts = new ObservableCollection<Podcast>();
            _episodes = new ObservableCollection<Episode>();
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

        #endregion


    }
}

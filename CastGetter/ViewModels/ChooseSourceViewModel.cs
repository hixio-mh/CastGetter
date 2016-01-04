using Caliburn.Micro;
using CastGetter.Interface;
using CastGetter.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CastGetter.ViewModels
{
    public class ChooseSourceViewModel : Screen
    {
        IEventAggregator _eventAggregator;
        IDataStorage _storage;
        
        public ChooseSourceViewModel(IEnumerable<IPodcastSource> list,IEventAggregator eventAggregator,IDataStorage storage)
        {
            _eventAggregator = eventAggregator;
            _storage = storage;
            Sources = new ObservableCollection<IPodcastSource>();

            foreach (var source in list)
            {
                Sources.Add(source);
            }
        }

        public ObservableCollection<IPodcastSource> Sources { get; set; }
        public IPodcastSource SelectedSource { get; set; }

        public string PodcastAddress { get; set; }

        public void AddCast()
        {
            Podcast retrievedCast = SelectedSource.GetPodcast(PodcastAddress);
            _storage.SaveCast(retrievedCast);
            _eventAggregator.PublishOnUIThread(retrievedCast);
            TryClose();
        }

        //public bool CanAddCast
        //{
        //    get
        //    {
        //        if (SelectedSource != null)
        //        {
        //            return true;
        //        }
        //        return false;
        //    }
        //}
    }
}

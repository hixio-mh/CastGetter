using Caliburn.Micro;
using CastGetter.Interface;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CastGetter.ViewModels
{
    public class ChooseSourceViewModel : Screen
    {
        IEventAggregator _eventAggregator;
        public ChooseSourceViewModel(IEnumerable<IPodcastSource> list,IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
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
            _eventAggregator.PublishOnUIThread(SelectedSource.GetPodcast(PodcastAddress));
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

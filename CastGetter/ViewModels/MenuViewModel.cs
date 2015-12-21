using Caliburn.Micro;
using CastGetter.Interface;
using System.Collections.Generic;

namespace CastGetter.ViewModels
{
    public class MenuViewModel : PropertyChangedBase
    {
        private readonly IWindowManager _windowManager;
        private readonly IEventAggregator _events;

        //List of avaliable Podcast sources
        private readonly IEnumerable<IPodcastSource> _sources;
        public MenuViewModel(IEnumerable<IPodcastSource> sources, IWindowManager windowManager,IEventAggregator events)
        {
            _events = events;
            _windowManager = windowManager;
            _sources = sources;
        }

        public void AddCastCommand()
        {
            _windowManager.ShowWindow(new ChooseSourceViewModel(_sources,_events));
        }
    }
}

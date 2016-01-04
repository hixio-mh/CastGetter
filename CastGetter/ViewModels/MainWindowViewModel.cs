using Caliburn.Micro;
using CastGetter.Interface;
using CastGetter.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace CastGetter.ViewModels
{
    public class MainWindowViewModel : PropertyChangedBase
    {
        IEventAggregator _eventAggregator;

        public MainWindowViewModel(
            MenuViewModel menuView,PanelViewModel panelView,PodcastViewModel podcastView,ProgressViewModel progressView,
            IDataStorage storage,IEventAggregator eventAggregator)
        {
            MenuView = menuView;
            PanelView = panelView;
            PodcastView = podcastView;
            ProgressView = progressView;

            _eventAggregator = eventAggregator;
            //Get data from data storage
            var casts = storage.GetAllCasts();
            //if data storage contain podcasts populate Views -> with Data
            if (casts != null)
            {
                foreach (var cast in casts)
                {
                    _eventAggregator.BeginPublishOnUIThread(cast);
                }
            }
        }

        #region Views
        public MenuViewModel MenuView { get;private set; }
        public PanelViewModel PanelView { get;private set; }
        public PodcastViewModel PodcastView { get; private set; }
        public ProgressViewModel ProgressView { get; private set; }
        #endregion
    }
}

using Caliburn.Micro;
using CastGetter.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace CastGetter.ViewModels
{
    public class MainWindowViewModel : PropertyChangedBase
    {
        

        public MainWindowViewModel(
            MenuViewModel menuView,PanelViewModel panelView,PodcastViewModel podcastView,ProgressViewModel progressView)
        {
            MenuView = menuView;
            PanelView = panelView;
            PodcastView = podcastView;
            ProgressView = progressView;
        }

        #region Views
        public MenuViewModel MenuView { get;private set; }
        public PanelViewModel PanelView { get;private set; }
        public PodcastViewModel PodcastView { get; private set; }
        public ProgressViewModel ProgressView { get; private set; }
        #endregion
    }
}

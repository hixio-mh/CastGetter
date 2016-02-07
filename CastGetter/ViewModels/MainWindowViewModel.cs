using System;
using Caliburn.Micro;
using CastGetter.Interfaces;
using CastGetter.Messages;
using CastGetter.Services;

namespace CastGetter.ViewModels
{
    public class MainWindowViewModel : Conductor<object>,IHandle<OpenDetailViewMessage>
    {
        private readonly IEventAggregator _eventAggregator;
        private DetailViewModel _detailViewModel;

        public MainWindowViewModel(
            PodcastViewModel podcastView,IDataStorage storage,IEventAggregator eventAggregator, DetailViewModel detailViewModel)
        {
            _detailViewModel = detailViewModel;
            //Set Title
            base.DisplayName = "CastGetter - Enjoy podcasts the easy way :-)";
            _eventAggregator = eventAggregator;
            //Set currentView
            ActivateItem(podcastView);
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
            _eventAggregator.Subscribe(this);
        }

        public sealed override void ActivateItem(object item)
        {
            base.ActivateItem(item);
        }

        public void OpenDetailView()
        {
            if (_detailViewModel != null)
            {
                ActivateItem(_detailViewModel); 
            }
        }

        public void Handle(OpenDetailViewMessage message)
        {
            OpenDetailView();
            _eventAggregator.PublishOnUIThread(new SelectedPodcastMessage() {Podcast = message.SelectedPodcast});
        }
    }
}

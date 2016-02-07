using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using Caliburn.Micro;
using CastGetter.Interface;
using CastGetter.Messages;

namespace CastGetter.ViewModels
{
    public class DetailViewModel : Screen, IHandle<SelectedPodcastMessage>
    {
        #region Private
        private ObservableCollection<Episode> _episodes;
        private IEventAggregator _eventAggregator;
        private WebClient _client;

        #endregion


        #region Contructors

        public DetailViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            //Subscribe for events on this VM
            _eventAggregator.Subscribe(this);
            _episodes = new ObservableCollection<Episode>();
        }
        #endregion

        #region Properties 
        private Episode _SelectedEpisode;

        public Episode SelectedEpisode
        {
            get { return _SelectedEpisode; }
            set
            {
                _SelectedEpisode = value;
                NotifyOfPropertyChange();
            }
        }

        public ObservableCollection<Episode> Episodes
        {
            get { return _episodes; }
            set { _episodes = value; }
        }

        #endregion


        #region Commands

        public void DownloadButton(Episode episode)
        {
            //_events.PublishOnUIThread(new DownloadEpisode(episode.LinkToRessource)
            //{
            //    EpisodeName = episode.Name,
            //    FileName = "test.mp3",
            //    Progress = 0
            //});
            if (_client == null)
            {
                _client = new WebClient();
            }
            var hasExtension = Path.HasExtension(SelectedEpisode.LinkToRessource.AbsolutePath);
            if (hasExtension)
            {
                string ext = Path.GetExtension(SelectedEpisode.LinkToRessource.AbsolutePath);
                string filePath = CleanFileName(episode.Name);

                _client.DownloadFile(SelectedEpisode.LinkToRessource, filePath + ext);
                episode.NotDownloaded = false;
            }

        }

        #endregion

        #region EventHandler

        /// <summary>
        /// Event when episodes are added
        /// </summary>
        /// <param name="message"></param>
        public void Handle(SelectedPodcastMessage message)
        {
            _episodes.Clear();
            foreach (var episode in message.Podcast.Episodes)
            {
                Episodes.Add(episode);
            }
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
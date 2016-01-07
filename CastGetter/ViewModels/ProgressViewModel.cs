using Caliburn.Micro;
using System.Collections.ObjectModel;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace CastGetter.ViewModels
{
    public class ProgressViewModel : PropertyChangedBase,IHandle<DownloadEpisode>
    {
        #region private Variables

        IEventAggregator _eventAggregator;
        WebClient _client = null;

        #endregion

        #region Constructor

        public ProgressViewModel(IEventAggregator eventAggregator)
        {
            DownloadList = new ObservableCollection<DownloadEpisode>();
            _eventAggregator = eventAggregator;

            _eventAggregator.Subscribe(this);

            _client = new WebClient();
        }

        #endregion


        #region Properties

        private ObservableCollection<DownloadEpisode> _downloadList;

        public ObservableCollection<DownloadEpisode> DownloadList
        {
            get { return _downloadList; }
            set {
                _downloadList = value;
                NotifyOfPropertyChange();
            }
        }

        #endregion

        private void QueueDownload(DownloadEpisode ep)
        {
            Task.Factory.StartNew(() => {
                for (int i = 0; i < 100; i++)
                {
                    Thread.Sleep(300);
                    ep.Progress = i;
                }
            },TaskCreationOptions.LongRunning);
            //using (WebClient wc = new WebClient())
            //{
            //    wc.DownloadProgressChanged += wc_DownloadProgressChanged;
            //    wc.DownloadFileAsync(new System.Uri("http://www.sayka.in/downloads/front_view.jpg"),
            //    "D:\\Images\\front_view.jpg");
            //}
        }

        #region Message Receivers

        public void Handle(DownloadEpisode message)
        {
            DownloadList.Add(message);
            QueueDownload(message);
        }

        #endregion

    }

}

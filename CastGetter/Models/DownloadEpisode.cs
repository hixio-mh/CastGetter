using Caliburn.Micro;
using System;

namespace CastGetter
{
    public class DownloadEpisode : PropertyChangedBase
    {
        public DownloadEpisode(Uri downloadPath)
        {
            DownloadPath = downloadPath;
        }

        private double _Progress;

        public double Progress
        {
            get { return _Progress; }
            set {
                _Progress = value;
                NotifyOfPropertyChange();
            }
        }

        public string FileName { get; set; }

        public string EpisodeName { get; set; }

        public Uri DownloadPath { get; private set; }
    }
}

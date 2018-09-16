using System;
using System.Collections.Generic;
using System.Text;

namespace StreamVideo.Models
{
    public class UpComingMovies
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string Cast { get; set; }
        public string Description { get; set; }
        public string MovieLanguage { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string RatedPGI { get; set; }
        public string MovieType { get; set; }
        public string TrailorLink { get; set; }
        public string Logo { get; set; }
        public string PhotoFullPath
        {
            get
            {
                if (string.IsNullOrEmpty(Logo))
                {
                    return string.Empty;
                }
                return string.Format("http://cinemo.azurewebsites.net/{0}", Logo.Substring(1));
            }
        }
        public object LogoFile { get; set; }
    }
}

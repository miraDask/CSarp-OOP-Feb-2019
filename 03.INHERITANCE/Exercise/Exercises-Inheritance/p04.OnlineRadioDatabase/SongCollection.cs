namespace p04.OnlineRadioDatabase
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SongCollection
    {
        private List<Song> songs;

        public SongCollection()
        {
            this.songs = new List<Song>();
        }

        public void AddSong(Song song)
        {
            this.songs.Add(song);
        }

        public string GetPlaylistLengthAsText()
        {
           
            double totalLengthInSeconds = this.songs.Sum(x => (x.Minutes * 60) + x.Seconds);

            TimeSpan timeSpan = TimeSpan.FromSeconds(totalLengthInSeconds);
            int hours = timeSpan.Hours;
            int minutes = timeSpan.Minutes;
            int seconds = timeSpan.Seconds;

            return $"{hours}h {minutes}m {seconds}s";
        }

        public override string ToString()
        {
            return $"Songs added: {this.songs.Count}{Environment.NewLine}" +
                   $"Playlist length: {GetPlaylistLengthAsText()}";
        }
    }
}

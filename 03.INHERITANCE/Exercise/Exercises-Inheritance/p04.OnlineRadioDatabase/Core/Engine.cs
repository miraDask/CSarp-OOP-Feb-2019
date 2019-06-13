namespace p04.OnlineRadioDatabase
{
    using System;
    using System.Linq;

    public class Engine
    {
        public void Run()
        {
            var songs = new SongCollection();

            int songCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < songCount; i++)
            {
                try
                {
                    var songArguments = Console.ReadLine().Split(';');

                    if (songArguments.Length != 3)
                    {
                        throw new InvalidSongException();
                    }

                    var artist = songArguments[0];
                    var songName = songArguments[1];
                    var songLength = songArguments[2].Split(':');
                    var minutes = 0;
                    var seconds = 0;

                    bool isMinute = int.TryParse(songLength[0], out minutes);
                    bool isSecond = int.TryParse(songLength[1], out seconds);

                    if (!isMinute || !isSecond)
                    {
                        throw new InvalidSongLengthException();
                    }

                    var song = new Song(artist, songName, minutes, seconds);
                    songs.AddSong(song);
                    Console.WriteLine("Song added.");

                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(songs);
        }
    }
}

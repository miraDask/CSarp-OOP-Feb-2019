namespace p04.OnlineRadioDatabase
{
    using System;

    public class InvalidSongException : FormatException
    {
        public InvalidSongException(string message = "Invalid song.")
            : base(message)
        {
        }
    }
}

namespace p04.OnlineRadioDatabase
{
    public class InvalidSongLengthException : InvalidSongException
    {
        public InvalidSongLengthException(string message = "Invalid song length.")
            : base(message)
        {
        }
    }
}

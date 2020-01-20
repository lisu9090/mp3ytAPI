namespace Stream.Infrastructure.Interfaces
{
    interface IYtAudioStreamService
    {
        System.IO.Stream GetAudioStream(string videoId);
    }
}

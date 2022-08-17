using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Videos;
using YoutubeExplode.Videos.Streams;

namespace YoutubeConsole
{
    public class ReceiverContent : Receiver
    {
        private VideoContent YVideo { get; set; }
        private FileContent YFile { get; set; }
        private YoutubeClient _youtubeRecord;

        public ReceiverContent(VideoContent video, FileContent file)
        {
            this.YVideo = video;
            this.YFile = file;
            _youtubeRecord = new YoutubeClient();
        }

        public override async Task Operation()
        {
            // var _streamManifest = await _youtubeRecord.Videos.Streams.GetManifestAsync(YVideo.VId); // GetVideoStreams().
            YFile.MovieName = new FileInfo(YVideo.VAttr.Title);
            YFile.MoviePath = new DirectoryInfo(Environment.CurrentDirectory);
            var filePath = new FileInfo(Path.Combine(YFile.MoviePath.FullName, YFile.MovieName.Name) + ".mp4");
            if (filePath.Exists)
            {
                throw (new ArgumentException($"...файл {filePath.FullName} уже существует..."));
            }
            IStreamInfo videoStreamInfo = _youtubeRecord.Videos.Streams.GetManifestAsync(YVideo.VId).Result.GetMuxedStreams().Last();
            try
            {
                await _youtubeRecord.Videos.Streams.DownloadAsync(videoStreamInfo, filePath.FullName);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
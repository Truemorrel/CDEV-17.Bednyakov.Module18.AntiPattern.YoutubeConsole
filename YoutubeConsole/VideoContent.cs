using System;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Videos;

namespace YoutubeConsole
{
    public class VideoContent
    {
        public VideoId VId { get; set; }
        public Video VAttr { get; set; }
        public VideoContent(string url)
        {
            VId = VideoId.Parse(url);
            Task task = SetYRecord();
            task.Wait();
            Console.WriteLine($"{VAttr.Title}{Environment.NewLine}" +
                "=============================================================" +
                $"{Environment.NewLine}{VAttr.Description}");            
        }
        public async Task SetYRecord()
        {
            var YRecord = new YoutubeClient();
            VAttr = await YRecord.Videos.GetAsync(VId);
        }
    }
}
namespace WebCrawler
{
    using System.Net;

    public class HtmlDownloader : IHtmlDownloader
    {
        public string DownloadHtml(string url)
        {
            var client = new WebClient();
            var html = client.DownloadString(url);

            return html;
        }
    }
}
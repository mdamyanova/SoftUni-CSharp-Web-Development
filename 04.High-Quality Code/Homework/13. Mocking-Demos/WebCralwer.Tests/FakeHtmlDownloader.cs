namespace WebCralwer.Tests
{
    using WebCrawler;
    public class FakeHtmlDownloader : IHtmlDownloader
    {
        public string DownloadHtml(string url)
        {
            return
                "<html>" +
                "<img src=\"nakov.png\"/>" + 
                "<span>Hello</span>" +
                "<img src=\"courses/inner/background.jpeg\"/>" + 
                "</html>";
        }
    }
}
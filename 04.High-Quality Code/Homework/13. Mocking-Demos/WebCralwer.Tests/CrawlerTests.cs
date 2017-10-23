namespace WebCralwer.Tests
{
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    using WebCrawler;

    [TestClass]
    public class CrawlerTests
    {
        [TestMethod]
        public void ExtractImageUrls_Should_Return_Collection_Of_Image_Src_Content()
        {
            // Arrange
            var mock = new Mock<IHtmlDownloader>();
            mock.Setup(h => h.DownloadHtml(It.IsAny<string>()))
                .Returns(
                    "<html>" + "<img src=\"nakov.png\"/>" + "<span>Hello</span>"
                    + "<img src=\"courses/inner/background.jpeg\"/>" + "</html>");

            //to throw exception -> 
            //mock.Setup(h => h.DownloadHtml(It.Is((string url) => url == null)))
            //             .Throws(new ArgumentNullException());

            //var fakeHtmlDownloader = new FakeHtmlDownloader();
            var crawler = new Crawler(mock.Object);

            var expectedImageUrls = new[]
            {
                // What to expect?
                "nakov.png",
                "courses/inner/background.jpeg"
            };

            // Act
            var imageUrls = crawler.ExtractImageUrls(string.Empty)
                .ToList();

            
            // Assert
            CollectionAssert.AreEqual(expectedImageUrls, imageUrls);
        }
    }
}
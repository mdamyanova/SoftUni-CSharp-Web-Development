namespace SimpleMvc.Framework.Views
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Contracts;

    public class View : IRenderable
    {
        public const string BaseLayoutFileName = "Layout";
        public const string ContentPlaceholder = "{{{content}}}";
        public const string HtmlExtension = ".html";
        public const string LocalErrorPath = "\\SimpleMvc.Framework\\Errors\\error.html";

        private readonly string templateFullQualifiedName;
        private readonly IDictionary<string, string> viewData;

        public View(string templateFullQualifiedName, IDictionary<string, string> viewData)
        {
            this.templateFullQualifiedName = templateFullQualifiedName;
            this.viewData = viewData;
        }

        public string Render()
        {
            var fullHtml = this.ReadFile();

            if (this.viewData.Any())
            {
                foreach (var parameter in this.viewData)
                {
                    fullHtml = fullHtml.Replace($"{{{{{{{parameter.Key}}}}}}}", parameter.Value);
                }
            }

            return fullHtml;
        }

        private string ReadFile()
        {
            var layoutHtml = this.RenderLayoutHtml();

            var templateFullQualifiedNameWithExtension = this.templateFullQualifiedName + HtmlExtension;

            if (!File.Exists(templateFullQualifiedNameWithExtension))
            {
                var errorPath = this.GetErrorPath();
                var errorHtml = File.ReadAllText(errorPath);
                this.viewData.Add("error", "Requested view does not exist!");
                return errorHtml;
            }

            //TODO
        }

        private string RenderLayoutHtml()
        {
            var layoutHtmlQualifiedName = string.Format(
                "{0}\\{1}{2}",
                MvcContext.Get.ViewsFolder,
                BaseLayoutFileName,
                HtmlExtension);

            if (!File.Exists(layoutHtmlQualifiedName))
            {
                var errorPath = this.GetErrorPath();
                var errorHtml = File.ReadAllText(errorPath);
                this.viewData.Add("error", "Layout view does not exist!");
                return errorHtml;
            }

            var layoutHtmlFileContent = File.ReadAllText(layoutHtmlQualifiedName);

            return layoutHtmlFileContent;
        }

        private string GetErrorPath()
        {
            var appDirectoryPath = Directory.GetCurrentDirectory();
            var parentDirectory = Directory.GetParent(appDirectoryPath);
            var parentDirectoryPath = parentDirectory.FullName;

            var errorPagePath = parentDirectoryPath + LocalErrorPath;

            return errorPagePath;
        }
    }
}
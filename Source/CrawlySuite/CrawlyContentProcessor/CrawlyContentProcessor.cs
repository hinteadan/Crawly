using System;
using System.Configuration;

namespace H.Crawly.Content
{
    public class CrawlyContentProcessor
    {
        private const string defaultTemplateFileExtension = ".crawlable";
        private readonly string templatesDir = string.Empty;
        private readonly CrawlyContentTemplate template;

        public CrawlyContentProcessor(string localPath)
        {
            this.templatesDir = ConfigurationManager.AppSettings["Crawly.TemplatesDir"] != null ?
                ConfigurationManager.AppSettings["Crawly.TemplatesDir"] :
                this.templatesDir;
            this.template = new CrawlyFileTemplate(string.Format("{0}{1}{2}", templatesDir, localPath, defaultTemplateFileExtension));
        }
        public CrawlyContentProcessor(Uri requestUrl) : this(requestUrl.LocalPath) { }

        public CrawlyContentProcessor Populate(string paramName, string with)
        {
            template.Having(paramName, with);
            return this;
        }

        public CrawlyContentProcessor Populate(string paramName, Func<string> with)
        {
            return this.Populate(paramName, with());
        }

        public string GetContent()
        {
            throw new NotImplementedException();
        }
    }
}

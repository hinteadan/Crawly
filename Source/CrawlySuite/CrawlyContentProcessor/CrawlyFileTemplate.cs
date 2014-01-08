using System.IO;

namespace H.Crawly.Content
{
    public class CrawlyFileTemplate : CrawlyContentTemplate
    {
        private readonly string filePath;

        public CrawlyFileTemplate(string filePath)
        {
            this.filePath = filePath;
        }

        public override string Result()
        {
            base.RawTemplateContent = File.ReadAllText(filePath);
            return base.Result();
        }
    }
}

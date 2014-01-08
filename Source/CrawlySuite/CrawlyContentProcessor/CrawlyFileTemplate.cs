using System.IO;

namespace H.Crawly.Content
{
    public class CrawlyFileTemplate : CrawlyContentTemplate
    {
        private readonly string filePath;
        private string fileContent;

        public CrawlyFileTemplate(string filePath)
        {
            this.filePath = filePath;
        }

        protected override string RawTemplateContent
        {
            get
            {
                if (fileContent == null)
                {
                    fileContent = File.ReadAllText(filePath);
                }
                return fileContent;
            }
            set
            {
                fileContent = value;
            }
        }
    }
}

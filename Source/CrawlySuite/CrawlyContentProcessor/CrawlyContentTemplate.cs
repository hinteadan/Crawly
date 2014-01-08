using System;
using System.Collections.Generic;

namespace H.Crawly.Content
{
    public abstract class CrawlyContentTemplate
    {
        private const char parameterMark = '@';
        private static readonly char[] parameterEndMarks = new char[] { ' ', '.', '!', '?', '&', '<', '>', '|', '/', '\\', ':', ';', '"', '\'' };
        private readonly Dictionary<string, string> parameters = new Dictionary<string, string>();

        protected virtual string RawTemplateContent { get; set; }
        protected Dictionary<string, string> Parameters { get { return parameters; } }

        public CrawlyContentTemplate Having(string parameter, string value)
        {
            parameters[parameter] = value;

            return this;
        }

        public virtual string Result()
        {
            string templateContent = RawTemplateContent;
            string resultContent = string.Empty;

            if (string.IsNullOrEmpty(templateContent))
            {
                throw new InvalidOperationException("The RawTemplateContent must be set before processing the result");
            }

            int paramPosition = 0;
            string paramName;
            string value;
            do
            {
                paramPosition = templateContent.IndexOf(parameterMark);
                if (paramPosition > 0 && paramPosition < templateContent.Length - 1 && templateContent[paramPosition + 1] == parameterMark)
                {
                    paramPosition += 2;
                    continue;
                }
                if (paramPosition < 0)
                {
                    resultContent += templateContent;
                    break;
                }
                int paramEndPosition = templateContent.IndexOfAny(parameterEndMarks, paramPosition + 1);
                if (paramEndPosition < 0)
                {
                    paramEndPosition = templateContent.Length - 1;
                }
                if (paramPosition + 1 == paramEndPosition)
                {
                    throw new System.FormatException("Template parameters MUST have names. If you want to use the parameter delimiter as content, escape it by doubling it.");
                }
                paramName = templateContent.Substring(paramPosition + 1, paramEndPosition - paramPosition - 1);
                value = parameters.ContainsKey(paramName) ? parameters[paramName] : string.Empty;
                resultContent += string.Format("{0}{1}{2}", templateContent.Substring(0, paramPosition), value, templateContent[paramEndPosition]);
                templateContent = templateContent.Substring(paramEndPosition + 1);
            } while (paramPosition >= 0);

            return resultContent;
        }
    }
}

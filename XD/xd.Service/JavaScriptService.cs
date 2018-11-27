using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.IO;
using System.Web;

namespace xd.Service
{
    public class JavaScriptService
    {
        public static IHtmlString SerializeObject(object value)
        {
            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var serializer = new JsonSerializer
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };
                jsonWriter.QuoteName = false;
                serializer.Serialize(jsonWriter, value);
                return new HtmlString(stringWriter.ToString());
            }

        }
    }
}

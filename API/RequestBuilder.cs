using Newtonsoft.Json.Linq;

namespace bleaf_test_automation.API
{
    public class RequestBuilder
    {
        private readonly JObject _requestBody;

        public RequestBuilder()
        {
            _requestBody = new JObject();
        }

        public RequestBuilder AddProperty(string key, object value)
        {
            _requestBody[key] = JToken.FromObject(value);
            return this;
        }

        public string Build()
        {
            return _requestBody.ToString();
        }
    }
}
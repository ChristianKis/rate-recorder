using JsonProxy.MNBRateServiceReference;
using Newtonsoft.Json;
using System.IO;
using System.Web.Script.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace JsonProxy
{
    public class RateLoaderService : IRateLoaderService
    {
        public string GetCurrentRates()
        {
            var client = new MNBArfolyamServiceSoapClient();
            var result = client.GetCurrentExchangeRates(new MNBRateServiceReference.GetCurrentExchangeRatesRequestBody());

            var serializer = new XmlSerializer(typeof(JsonProxy.Contracts.MNBCurrentExchangeRates));



            using (TextReader reader = new StringReader(result.GetCurrentExchangeRatesResult))
            {
                var xml = serializer.Deserialize(reader);

                var json = new JavaScriptSerializer().Serialize(xml);

                return json;

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(reader.ToString());
                string jsonText = JsonConvert.SerializeXmlNode(doc);
                return jsonText;



            }

            return result.GetCurrentExchangeRatesResult;
        }
    }
}

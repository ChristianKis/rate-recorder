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
            using (var client = new MNBArfolyamServiceSoapClient())
            {
                var result = client.GetCurrentExchangeRates(new GetCurrentExchangeRatesRequestBody());

                var serializer = new XmlSerializer(typeof(Contracts.MNBCurrentExchangeRates));

                using (TextReader reader = new StringReader(result.GetCurrentExchangeRatesResult))
                {
                    var xml = serializer.Deserialize(reader);

                    var json = new JavaScriptSerializer().Serialize(xml);

                    return json;
                }
            }
        }
    }
}

namespace JsonProxy
{
    using JsonProxy.Contracts;
    using JsonProxy.MNBRateServiceReference;
    using Utilities;
    public class RateLoaderService : IRateLoaderService
    {
        public string GetCurrentRates()
        {
            using (var client = new MNBArfolyamServiceSoapClient())
            {
                var result = client.GetCurrentExchangeRates(new GetCurrentExchangeRatesRequestBody());

                var converter = new Converter<MNBCurrentExchangeRates>();

                var subject = converter.Deserialize(result.GetCurrentExchangeRatesResult);

                return converter.Serialize(subject);
            }
        }
    }
}

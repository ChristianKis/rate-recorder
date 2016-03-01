namespace JsonProxy
{
    using System.ServiceModel;
    using System.ServiceModel.Web;
    [ServiceContract]
    public interface IRateLoaderService
    {
        [OperationContract]
        [WebGet(UriTemplate = "Rates/Current", ResponseFormat = WebMessageFormat.Xml)]
        string GetCurrentRates();
    }
}
namespace JsonProxy.Utilities
{
    using System.IO;
    using System.Web.Script.Serialization;
    using System.Xml.Serialization;

    public class Converter<T>
    {
        private readonly XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
        private readonly JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();

        public T Deserialize(string xml)
        {
            using (var reader = new StringReader(xml))
            {
                return (T)xmlSerializer.Deserialize(reader);
            }
        }

        public string Serialize(T subject)
        {
            return jsonSerializer.Serialize(subject);
        }
    }
}
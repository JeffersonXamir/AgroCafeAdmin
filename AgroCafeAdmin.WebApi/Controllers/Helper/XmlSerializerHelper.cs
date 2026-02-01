using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace AgroCafeAdmin.Data.Utils
{
    public static class XmlSerializerHelper
    {
        public static XDocument GetXml<T>(T criterio)
        {
            XDocument resultado = new XDocument(new XDeclaration("1.0", "utf-8", "true"));
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(T));
                using XmlWriter xw = resultado.CreateWriter();
                xs.Serialize(xw, criterio);
                return resultado;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static string SerializeToXml<T>(T obj)
        {
            if (obj == null)
                return string.Empty;

            try
            {
                var serializer = new XmlSerializer(typeof(T));
                var settings = new XmlWriterSettings
                {
                    Encoding = Encoding.UTF8,
                    Indent = false,
                    OmitXmlDeclaration = true
                };

                using (var stringWriter = new StringWriterWithEncoding(Encoding.UTF8))
                using (var writer = XmlWriter.Create(stringWriter, settings))
                {
                    var ns = new XmlSerializerNamespaces();
                    ns.Add("", "");

                    serializer.Serialize(writer, obj, ns);
                    return stringWriter.ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al serializar objeto a XML: {ex.Message}", ex);
            }
        }

        private class StringWriterWithEncoding : StringWriter
        {
            public override Encoding Encoding { get; }

            public StringWriterWithEncoding(Encoding encoding)
            {
                Encoding = encoding;
            }
        }
    }
}

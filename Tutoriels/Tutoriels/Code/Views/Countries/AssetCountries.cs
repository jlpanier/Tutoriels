using System.Xml.Serialization;

namespace Tutoriels.Code.Activities.Countries
{
    [Serializable()]
    [XmlRoot("countries")]
    public class AssetCountries
    {
        [XmlElement("country")]
        public List<Country> Countries { get; set; }
    }

    public class Country
    {
        [XmlElement("shortname")]
        public string shortname { get; set; }

        [XmlElement("longname")]
        public string longname { get; set; }

        [XmlElement("wiki")]
        public string wiki { get; set; }
    }
}
using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LINQSamples.Model
{
    public class Hometown
    {

        #region Properties
        [XmlElement("City")]
        public string City { get; set; }
        [XmlElement("State")]
        public string State { get; set; }
        [XmlElement("CityCode")]
        public string CityCode { get; set; }
        #endregion

        public Hometown() { }


    }
}

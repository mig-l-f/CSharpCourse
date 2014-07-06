using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace LINQSamples.Model
{
    [Table(Name="Hometown")]
    public class Hometown
    {

        #region Fields
        private int _Id;
        private string _City;
        private string _State;
        private string _Zip;
        #endregion

        #region Properties
        [Column(IsPrimaryKey=true, Storage="_Id")]
        public int Id
        {
            get
            {
                return _Id;
            }
            set
            {
                _Id = value;
            }
        }

        [Column(Storage="_City")]
        [XmlElement("City")]
        public string City 
        { 
            get 
            {
                return _City;
            }
            set
            {
                _City = value;
            }
        }

        [Column(Storage = "_State")]
        [XmlElement("State")]
        public string State
        {
            get
            {
                return _State;
            }
            set
            {
                _State = value;
            }
        }

        [Column(Storage="_Zip")]
        [XmlElement("Zip")]
        public string Zip 
        {
            get
            {
                return _Zip;
            }
            set
            {
                _Zip = value;
            }
        }
        #endregion      


    }
}

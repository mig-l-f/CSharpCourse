using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using LINQSamples.Model;
using System.Xml.Serialization;

namespace LINQSamples.ViewModel
{
    public class ListOfHometowns
    {
        [NonSerialized]
        private List<Hometown> _hometowns = new List<Hometown>();

    #region Properties
        [XmlArray("Hometows")]
        [XmlArrayItem("Hometown")]
        public List<Hometown> Hometowns 
        {
            get 
            {
                return _hometowns;
            } 
            set 
            {
                _hometowns = value;
            }
        }
    #endregion

    #region Methods
        public ListOfHometowns() { }

        public Hometown this[int index]
        {
            get
            {
                return Hometowns[index];
            }
            set
            {
                Hometowns[index] = value;
            }
        }
    #endregion

    }
}

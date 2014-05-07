using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubHuntCS
{
    public class Location
    {
        public Boolean hasSubmarine { get; set; } // Property, set has access to keyword value - what the user has set to
        private Boolean _firedUpon;
        public Boolean hasBeenFiredUpon // More complete property
        {
            get { return _firedUpon; }
            set { if (value == true) _firedUpon = true; }
        }
    }
}

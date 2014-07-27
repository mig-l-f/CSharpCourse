using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ToolTypes.Model.Tools
{
    [DataContract]
    public class ToolList
    {
        public ToolList()
        {
            toollist = new List<Tool>();
        }

        [DataMember]
        public List<Tool> toollist { get; set; }
        //public Tool[] toollist { get; set;}
    }
}

using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace ToolTypes.Model.Tools
{
    [DataContract]
    public class Tool
    {
        [DataMember(IsRequired=true)]
        public int toolID { get; set; }

        [DataMember(IsRequired=true)]
        public String toolLabel { get; set; }
    }
}

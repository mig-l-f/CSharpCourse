using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolTypes.Model.Tools;
using System.Runtime.Serialization.Json;
using System.IO;

namespace ToolTypes.Model.Service
{
    public class ToolService
    {
        private IToolServiceProvider _tool_provider;

        public ToolService(IToolServiceProvider tool_provider)
        {
            _tool_provider = tool_provider;
        }

        public async Task<ToolList> GetToolList(int type)
        {
            String json_toollist =  await _tool_provider.GetToolListAsync(type);
                       
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(ToolList));
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(json_toollist));
            ToolList target = new ToolList();
            target = (ToolList)serializer.ReadObject(stream);

            return target;
        }
    }
}

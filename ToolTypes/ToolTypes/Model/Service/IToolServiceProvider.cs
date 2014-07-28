using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolTypes.Model.Service
{
    public interface IToolServiceProvider
    {
        Task<String> GetToolListAsync(int type);
    }
}

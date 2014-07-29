using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Threading;

namespace ToolTypes.Model.Service
{
    public class ToolServiceProvider : IToolServiceProvider
    {
        private HttpClient _http_client;
        private CancellationTokenSource cts = null;

        public ToolServiceProvider(HttpClient http_client)
        {
            _http_client = http_client;
        }

        public async Task<String> GetToolListAsync(int type)
        {
            if (cts != null)
            {
                cts.Cancel();
            }
            cts = new CancellationTokenSource();

            String url = String.Format("http://pmb.neongrit.net/aj/selectJSON.php?type={0}", type);
            String content = String.Empty;
            try
            {
                HttpResponseMessage response = await _http_client.GetAsync(url, cts.Token);
                content = await response.Content.ReadAsStringAsync();
            }
            catch(OperationCanceledException)
            {
                throw;
            }
            finally
            {
                cts = null;                
            }
            return content;
        }
        
    }
}

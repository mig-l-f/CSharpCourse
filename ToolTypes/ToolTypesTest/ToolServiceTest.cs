using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NSubstitute;
using ToolTypes.Model.Tools;
using ToolTypes.Model.Service;
using System.Net.Http;
using System.Net;


namespace ToolTypesTest
{
    [TestFixture]
    public class ToolServiceTest
    {
        [Test]
        public void testMockGivesCorrectString()
        {
            string output = @"[{""toolID"":10,""toolLabel"":""this is a label""}]";
            var toolProviderMock = Substitute.For<IToolServiceProvider>();
            toolProviderMock.GetToolListAsync(1).Returns(Task.FromResult(output));

            Assert.AreEqual(toolProviderMock.GetToolListAsync(1).Result, output, "Output of mock is not the expected");
        }

        [Test]
        public void testGetToollistFromToolService()
        {
            string output = @"{""toollist"":[{""toolID"":10,""toolLabel"":""this is a label""}]}";
            var toolProviderMock = Substitute.For<IToolServiceProvider>();
            toolProviderMock.GetToolListAsync(1).Returns(Task.FromResult(output));

            ToolService target = new ToolService(toolProviderMock);
            ToolList list = target.GetToolList(1).Result;

            toolProviderMock.Received().GetToolListAsync(1);
            Assert.AreEqual(1, list.toollist.Count, "List Should have 1 object");
            Assert.AreEqual("this is a label", list.toollist[0].toolLabel, "Tool label is incorrect");
        }
    }

    [TestFixture]
    public class ToolServiceProviderTest
    {        
        [Test]
        public void testServiceProviderCallsMockHttpClient()
        {
            string expectedString = @"[{""toolID"":10,""toolLabel"":""this is a label""}]";
            //ByteArrayContent myContent = new ByteArrayContent(Encoding.UTF8.GetBytes(expectedString));
            //var HttpResponseMessage = new HttpResponseMessage() { Content = myContent };
            var response = new HttpResponseMessage() { Content = new ByteArrayContent(Encoding.UTF8.GetBytes(expectedString)) };

            //FakeResponseHandler fakeResponseHandler = new FakeResponseHandler();
            //fakeResponseHandler.AddFakeResponse(
            //    new Uri(String.Format("http://pmb.neongrit.net/aj/selectJSON.php?type={0}", 1)),
            //    HttpResponseMessage);
            HttpClient client = new HttpClient(new FakeHandler
                                                {
                                                    Response = response,
                                                    InnerHandler = new HttpClientHandler()
                                                });
            ToolServiceProvider target = new ToolServiceProvider(client);

            String output = target.GetToolListAsync(1).Result;
            Assert.AreEqual(expectedString, output, "output of web client is not the expected");
        }

        //[Test]
        //public void testServiceProviderCancelsRunningTaskWhenNewRequestIsMade()
        //{
        //    //ByteArrayContent myContent1 = new ByteArrayContent(Encoding.UTF8.GetBytes("Falhou"));
        //    //ByteArrayContent myContent2 = new ByteArrayContent(Encoding.UTF8.GetBytes("Funciona"));
        //    //var HttpResponseMessage1 = new HttpResponseMessage() { Content = myContent1 };
        //    //var HttpResponseMessage2 = new HttpResponseMessage() { Content = myContent2 };

        //    //FakeResponseHandler fakeResponseHandler = new FakeResponseHandler();
        //    //fakeResponseHandler.AddFakeResponse(
        //    //    new Uri(String.Format("http://pmb.neongrit.net/aj/selectJSONarrayDelay.php?type={0}", 1)),
        //    //    HttpResponseMessage1);
        //    //fakeResponseHandler.AddFakeResponse(
        //    //    new Uri(String.Format("http://pmb.neongrit.net/aj/selectJSON.php?type={0}", 2)),
        //    //    HttpResponseMessage2);

        //    var response = new HttpResponseMessage() { Content = new ByteArrayContent(Encoding.UTF8.GetBytes("Funcioan")) };

        //    HttpClient client = new HttpClient(new FakeHandler 
        //                                        { 
        //                                            Response = response, 
        //                                            InnerHandler = new HttpClientHandler()
        //                                        });
        //    ToolServiceProvider target = new ToolServiceProvider(client);
            
        //    String output = String.Empty;
        //    Assert.Throws<TaskCanceledException>(
        //        delegate { output = target.GetDelayedToolListAsync(1).Result; });
        //    output = target.GetToolListAsync(2).Result;
        //    Assert.AreEqual("Funciona", output, "output of web client is not the expected");
        //}
    }

    // Source: http://perezgb.com/2012/2/21/web-api-testing-with-httpclient
    public class FakeHandler : DelegatingHandler
    {
        public HttpRequestMessage LastRequest { get; set; }
        public HttpResponseMessage Response { get; set; }

        protected async override Task<HttpResponseMessage> SendAsync(System.Net.Http.HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            LastRequest = request;
            if (Response == null)
                Response = base.SendAsync(request, cancellationToken).Result;
            return Response;
        }
    }

    public class FakeResponseHandler : DelegatingHandler
    {
        private readonly Dictionary<Uri, HttpResponseMessage> _FakeResponses = new Dictionary<Uri, HttpResponseMessage>();

        public void AddFakeResponse(Uri uri, HttpResponseMessage responseMessage)
        {
            _FakeResponses.Add(uri, responseMessage);
        }

        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            if (_FakeResponses.ContainsKey(request.RequestUri))
            {
                return _FakeResponses[request.RequestUri];
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound) { RequestMessage = request };
            }

        }
    }

}

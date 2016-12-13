using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace MVCWebApiClient.Handler
{
    public class MyHttpClientHandler1 : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Task<HttpResponseMessage> responseTask = base.SendAsync(request, cancellationToken).ContinueWith(
                (requestTask) =>
                {
                    Debug.WriteLine("Process Request");
                    var responseMsg = requestTask.Result;
                    responseMsg.Content = new StringContent("Hello from HttpClient Message Handler");
                    Debug.WriteLine("Process Response");
                    return responseMsg;
                },
                TaskContinuationOptions.OnlyOnRanToCompletion);

            return responseTask;
        }
    }

    public class MyHttpClientHandler2 : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var task = new Task<HttpResponseMessage>(
                () => {
                    var responseMsg = new HttpResponseMessage();
                    responseMsg.Content = new StringContent("Hello from HttpClient Message Handler");
                    return responseMsg;
                });
            task.Start();
            return task;            
        }
    }
}
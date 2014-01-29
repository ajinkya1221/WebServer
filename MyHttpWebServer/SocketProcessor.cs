using System.Threading.Tasks;

namespace MyHttpWebServer
{
    public class SocketProcessor
    {
        public HttpAdapter HttpAdapter { get; set; }
        public HttpRequest httpRequest { get; set; }
        public HttpResponse httpResponse { get; set; }

        public void Handle(NetworkSocket socket)
        {
            HttpAdapter = new HttpAdapter();
            httpRequest = new HttpRequest();
            httpResponse = new HttpResponse();
            var inputBytes = socket.GetRequest();
            httpRequest = this.HttpAdapter.ToHttoRequest(inputBytes);
            if (httpRequest != null)
            {
                httpResponse = httpRequest.Execute();
                var outputBytes = this.HttpAdapter.ToBytes(httpResponse);
                socket.WriteResponse(outputBytes);                
            }
            
        }
    }
}

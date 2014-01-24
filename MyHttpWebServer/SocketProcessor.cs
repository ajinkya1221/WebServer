namespace MyHttpWebServer
{
    public class SocketProcessor
    {
        public HttpAdapter HttpAdapter { get; set; }

        public void Handle(NetworkSocket socket)
        {
            HttpAdapter = new HttpAdapter();
            var inputBytes = socket.GetRequest();
            var httpRequest = this.HttpAdapter.ToHttoRequest(inputBytes);
            var httpResponse = httpRequest.Execute();
            var outputBytes = this.HttpAdapter.ToBytes(httpResponse);
            socket.WriteResponse(outputBytes);      
        }
    }
}

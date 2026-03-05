using System.Net;
using System.Net.Http;
using System.Text;

namespace EvilCorp
{
    public static class CommunicationChannel
    {
        private static HttpListener? _httpListener;
        private static Thread? _listenerThread;
        private static bool _isRunning = false;
        private const int BasePort = 5000;
        private const string ProxyAddress = "http://127.0.0.1:8080";

        public static event Action<string>? MessageReceived;

        public static void StartServer(int userId)
        {
            if (_isRunning) Stop();

            _isRunning = true;
            int port = BasePort + userId;
            string prefix = $"http://localhost:{port}/";

            _listenerThread = new Thread(() =>
            {
                try
                {
                    _httpListener = new HttpListener();
                    _httpListener.Prefixes.Add(prefix);
                    _httpListener.Start();

                    while (_isRunning)
                    {
                        HttpListenerContext context = _httpListener.GetContext();
                        HttpListenerRequest request = context.Request;

                        if (request.HttpMethod == "POST")
                        {
                            using (var reader = new StreamReader(request.InputStream, request.ContentEncoding))
                            {
                                string message = reader.ReadToEnd();
                                if (!string.IsNullOrEmpty(message))
                                {
                                    MessageReceived?.Invoke(message);
                                }
                            }

                            // Send response back
                            byte[] buffer = Encoding.UTF8.GetBytes("OK");
                            context.Response.ContentLength64 = buffer.Length;
                            context.Response.OutputStream.Write(buffer, 0, buffer.Length);
                        }
                        context.Response.Close();
                    }
                }
                catch (Exception)
                {
                    // Silently handle errors
                }
            });
            _listenerThread.IsBackground = true;
            _listenerThread.Start();
        }

        public static async void SendMessage(int targetUserId, string message)
        {
            try
            {
                int port = BasePort + targetUserId;
                string url = $"http://localhost:{port}/";

                // Configure HttpClient to use Burp Suite Proxy
                var handler = new HttpClientHandler
                {
                    Proxy = new WebProxy(ProxyAddress),
                    UseProxy = true
                };

                using (var client = new HttpClient(handler))
                {
                    var content = new StringContent(message, Encoding.UTF8, "application/json");
                    await client.PostAsync(url, content);
                }
            }
            catch (Exception)
            {
                // Silently handle send errors
            }
        }

        public static void Stop()
        {
            _isRunning = false;
            try
            {
                _httpListener?.Stop();
                _httpListener?.Close();
                _httpListener = null;
            }
            catch { }
        }
    }
}

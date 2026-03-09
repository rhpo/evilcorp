using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Text.RegularExpressions;

namespace EvilCorp
{
    public static class CommunicationChannel
    {
        private const int InterceptPort = 12999;
        private const int BaseUserPort = 13000;

        private static TcpListener? _server;
        private static Thread? _listenerThread;
        private static bool _isRunning = false;

        public static event Action<string>? MessageReceived;

        private static int GetPortFromPipeName(string pipeName)
        {
            var match = Regex.Match(pipeName, @"EvilCorp_(\d+)");
            if (match.Success && int.TryParse(match.Groups[1].Value, out int id))
            {
                return BaseUserPort + id;
            }
            return 0;
        }

        public static void StartServer(string pipeName)
        {
            int port = GetPortFromPipeName(pipeName);
            if (port == 0) return;

            _isRunning = true;
            _listenerThread = new Thread(() =>
            {
                try
                {
                    _server = new TcpListener(IPAddress.Loopback, port);
                    _server.Start();

                    while (_isRunning)
                    {
                        try
                        {
                            var client = _server.AcceptTcpClient();
                            new Thread(() => HandleClient(client)).Start();
                        }
                        catch { if (!_isRunning) break; }
                    }
                }
                catch { }
            });
            _listenerThread.IsBackground = true;
            _listenerThread.Start();
        }

        private static void HandleClient(TcpClient client)
        {
            try
            {
                using (client)
                using (var stream = client.GetStream())
                using (var reader = new StreamReader(stream, Encoding.UTF8))
                {
                    string? encryptedBase64 = reader.ReadLine();
                    if (!string.IsNullOrEmpty(encryptedBase64))
                    {
                        var data = Convert.FromBase64String(encryptedBase64);
                        string message = Encoding.UTF8.GetString(data);
                        MessageReceived?.Invoke(message);
                    }
                }
            }
            catch { }
        }

        public static void SendMessage(string pipeName, string message, bool skipProxy = false)
        {
            if (!skipProxy)
            {
                try
                {
                    using (var proxyClient = new TcpClient())
                    {
                        var result = proxyClient.BeginConnect(IPAddress.Loopback, InterceptPort, null, null);
                        if (result.AsyncWaitHandle.WaitOne(200))
                        {
                            proxyClient.EndConnect(result);
                            using (var s = proxyClient.GetStream())
                            using (var w = new StreamWriter(s) { AutoFlush = true })
                            {
                                // Format: TargetPipe|Base64Payload
                                string b64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(message));
                                w.WriteLine($"{pipeName}|{b64}");
                                return;
                            }
                        }
                    }
                }
                catch { }
            }

            int port = GetPortFromPipeName(pipeName);
            if (port == 0) return;

            try
            {
                using (var client = new TcpClient())
                {
                    client.Connect(IPAddress.Loopback, port);
                    using (var s = client.GetStream())
                    using (var w = new StreamWriter(s) { AutoFlush = true })
                    {
                        string b64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(message));
                        w.WriteLine(b64);
                    }
                }
            }
            catch { }
        }

        public static void Stop()
        {
            _isRunning = false;
            _server?.Stop();
        }
    }
}

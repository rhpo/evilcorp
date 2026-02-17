using System.IO.Pipes;
using System.Text;

namespace EvilCorp
{
    public static class CommunicationChannel
    {
        private static NamedPipeServerStream? _pipeServer;
        private static NamedPipeClientStream? _pipeClient;
        private static Thread? _listenerThread;
        private static bool _isRunning = false;

        public static event Action<string>? MessageReceived;

        public static void StartServer(string pipeName)
        {
            _isRunning = true;
            _listenerThread = new Thread(() =>
            {
                while (_isRunning)
                {
                    try
                    {
                        _pipeServer = new NamedPipeServerStream(pipeName, PipeDirection.InOut, 1);
                        _pipeServer.WaitForConnection();

                        StreamReader reader = new StreamReader(_pipeServer);
                        string? message = reader.ReadLine();

                        if (!string.IsNullOrEmpty(message))
                        {
                            MessageReceived?.Invoke(message);
                        }

                        _pipeServer.Disconnect();
                        _pipeServer.Dispose();
                    }
                    catch (Exception)
                    {
                        // Silently handle connection errors
                    }
                }
            });
            _listenerThread.IsBackground = true;
            _listenerThread.Start();
        }

        public static void SendMessage(string pipeName, string message)
        {
            try
            {
                using (_pipeClient = new NamedPipeClientStream(".", pipeName, PipeDirection.InOut))
                {
                    _pipeClient.Connect(1000);
                    StreamWriter writer = new StreamWriter(_pipeClient);
                    writer.WriteLine(message);
                    writer.Flush();
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
            _pipeServer?.Dispose();
            _pipeClient?.Dispose();
        }
    }
}

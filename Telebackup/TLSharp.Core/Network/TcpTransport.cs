using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace TLSharp.Core.Network
{
	public class TcpTransport : IDisposable
    {
        public static readonly Dictionary<int, string> connectionAddresses
            = new Dictionary<int, string> {
                { 1, "149.154.175.50" },
                { 2, "149.154.167.51" },
                { 3, "149.154.175.100" },
                { 4, "149.154.167.91" },
                { 5, "91.108.56.165" }
            };

        static string _defaultConnectionAddress;
        private static string defaultConnectionAddress {
            get {
                if (string.IsNullOrEmpty(_defaultConnectionAddress))
                    _defaultConnectionAddress =
                        Settings.GetValue<string>("defaultConnectionAddress");
                return _defaultConnectionAddress;
            }
        }
        public static void UpdateDC(int dc) {
            Settings.SetValue<string>("defaultConnectionAddress",
                (_defaultConnectionAddress = connectionAddresses[dc]));
        }

		private const int defaultConnectionPort = 443;
		private readonly TcpClient _tcpClient;
		private int sendCounter = 0;

		public TcpTransport()
		{
            _tcpClient = new TcpClient {
                ReceiveBufferSize = 512 * 1024, // (kb), default is 1024 * 64
                SendBufferSize = 512 * 1024
            };
			
			var ipAddress = IPAddress.Parse(defaultConnectionAddress);
			_tcpClient.Connect(ipAddress, defaultConnectionPort);
		}

		public async Task Send(byte[] packet)
		{
			if (!_tcpClient.Connected)
				throw new InvalidOperationException("Client not connected to server.");

			var tcpMessage = new TcpMessage(sendCounter, packet);

			await _tcpClient.GetStream().WriteAsync(tcpMessage.Encode(), 0, tcpMessage.Encode().Length);
			sendCounter++;
		}
        
		public async Task<TcpMessage> Receieve()
		{
			var buffer = new byte[_tcpClient.ReceiveBufferSize];
            var availableBytes = await _tcpClient.GetStream().ReadAsync(buffer, 0, buffer.Length);

            var result = buffer.Take(availableBytes).ToArray();

            return TcpMessage.Decode(result);
		}

		public void Dispose()
		{
			if (_tcpClient.Connected)
				_tcpClient.Close();
		}
	}
}

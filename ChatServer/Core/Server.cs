using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ChatServer.Core {
	public class Server {
		readonly Dictionary<Guid, Client> _clients = new Dictionary<Guid, Client>();
		readonly IPEndPoint _localEndPoint;

		public event Action<string> OnMessage = delegate { }; 

		public Server(IPEndPoint localEndPoint){
			_localEndPoint = localEndPoint;
			var acceptTh = new Thread(AcceptProc);
			acceptTh.IsBackground = true;
			acceptTh.Start();
		}

		internal void UnregisterClient(Client client){
			bool disconnected;

			lock (_clients){
				disconnected = _clients.Remove(client.Id);
			}

			if (disconnected){
				this.TransmitServerMessage($"Client '{client.Name}' disconnected");
			}
		}

		internal void TransmitServerMessage(string text){
			this.TransmitMessage($"[Server] - {text}");
		}

		internal void TransmitMessage(string msg) {
			OnMessage(msg);
			List<Client> targets;

			lock (_clients){
				targets = _clients.Values.ToList();
			}

			targets.ForEach(c => c.TransmitMessage(msg));
		}

		void AcceptProc(){
			var listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			listener.Bind(_localEndPoint);
			listener.Listen(10);

			for (;;){
				var sck = listener.Accept();
				sck.NoDelay = true;

				var client = new Client(this, sck);

				lock (_clients){
					_clients.Add(client.Id, client);
				}

				client.Start();
			}
		}
	}
}
using System;
using System.Diagnostics;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ChatClient.Core{
	class Client{
		public string Name { get; private set; }

		public event Action<string> OnMessage = delegate { };

		readonly Socket _sck;
		readonly Thread _recvTh;

		public Client(string name, string serverHostName, ushort port){
			this.Name = name;

			_sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			_sck.Connect(serverHostName, port);
			this.TransmitMessage(name);

			_recvTh = new Thread(RecvThProc);
			_recvTh.IsBackground = true;
		}

		public void Start(){
			_recvTh.Start();
		}

		private string ReceiveMsg(){
			var lbuff = new byte[4];
			_sck.Receive(lbuff);
			var buff = new byte[BitConverter.ToInt32(lbuff, 0)];
			_sck.Receive(buff);

			return Encoding.UTF8.GetString(buff);
		}

		private void RecvThProc(){
			try{
				while (_sck.Connected){
					var msg = this.ReceiveMsg();
					this.OnMessage(msg);
				}
			}
			catch (Exception ex){
				Debug.Print(ex.StackTrace);
				_sck.Dispose();
			}
		}

		public bool TransmitMessage(string msg){
			try{
				var bytes = Encoding.UTF8.GetBytes(msg);
				_sck.Send(BitConverter.GetBytes(bytes.Length));
				_sck.Send(bytes);
				return true;
			}
			catch (Exception ex){
				Debug.Print(ex.StackTrace);
				_sck.Dispose();
				return false;
			}
		}
	}
}

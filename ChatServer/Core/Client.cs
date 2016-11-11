using System;
using System.Diagnostics;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ChatServer.Core {
	internal class Client{
		public Guid Id { get; private set; }
		public string Name { get; private set; }

		readonly Server _owner;
		readonly Socket _sck;
		readonly Thread _recvTh;

		public Client(Server owner, Socket sck){
			this.Id = Guid.NewGuid();
			this.Name = this.Id.ToString();

			_sck = sck;
			_owner = owner;

			_recvTh = new Thread(RecvThProc);
			_recvTh.IsBackground = true;
		}

		public void Start(){
			this.Name = this.ReceiveMsg();
			_owner.TransmitServerMessage($"Client '{this.Name}' entered");
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
					_owner.TransmitMessage($"[{this.Name}] - {msg}");
				}
			}
			catch (Exception ex){
				Debug.Print(ex.StackTrace);
				_sck.Dispose();
				_owner.UnregisterClient(this);
			}
		}

		public void TransmitMessage(string msg){
			try{
				var bytes = Encoding.UTF8.GetBytes(msg);
				_sck.Send(BitConverter.GetBytes(bytes.Length));
				_sck.Send(bytes);
			}
			catch (Exception ex){
				Debug.Print(ex.StackTrace);
				_sck.Dispose();
				_owner.UnregisterClient(this);
			}
		}
	}
}
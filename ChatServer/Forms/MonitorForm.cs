using System;
using System.IO;
using System.Net;
using System.Windows.Forms;
using ChatServer.Core;
using Buffer = ChatServer.Core.LoopBuffer.Buffer;

namespace ChatServer.Forms
{
	public partial class MonitorForm : Form {
		private const uint SizeBuffer = 22;
		public static ushort Port;
		private Server _server { get; }

		private readonly Buffer _buffer = new Buffer(SizeBuffer);

		public MonitorForm(){
			InitializeComponent();
			var choosePort = new ChoosePortForm();
			choosePort.ShowDialog();
			_server = new Server(new IPEndPoint(IPAddress.Any, Port));
			_server.OnMessage += msg =>_buffer.Add("/" + DateTime.Now.ToString() + "/" + msg);
			update.Start();
		}

		protected override void OnClosed(EventArgs e) {
			base.OnClosed(e);
			var file = new FileInfo("log.txt");
			if (file.Exists == false) {
				file.Create();
			}

			var writer = file.AppendText();

			string[] buf = _buffer.getBuffer();

			for (int i = 0; i < SizeBuffer; i++) {
				writer.WriteLine(buf[i]);
			}
			writer.Close();
		}

		private void update_Tick(object sender, EventArgs e) {
		    portLabel.Text = @"Port:" + Port;
			string[] buf = _buffer.getBuffer();
			string log = "";
			for (int i = 0; i < SizeBuffer; i++) {
				log += buf[i] + "\r\n";
			}
			eventLog.Text = log;
		}
	}
}

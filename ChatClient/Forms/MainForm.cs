using System;
using System.Windows.Forms;
using ChatClient.Core;
using ChatClient.Forms;

namespace ChatClient{
	public partial class MainForm : Form {
		public static uint port;

		private readonly Client _client;

		private readonly string[] _messages = new string[19];
		public MainForm(){
			InitializeComponent();
			var login = new LoginForm();
			login.ShowDialog();
			_client = new Client(ChatClient.Program.Nick, ChatClient.Program.Ip, ChatClient.Program.Port);
			_client.OnMessage += AddMessage;
			_client.Start();
			update.Start();
		}

		private void button1_Click(object sender, EventArgs e) {
			_client.TransmitMessage(textBox1.Text);
			textBox1.Text = "";
		}

		private void AddMessage(string msg) {
			for (int i = 0; i < 18; i++) {
				_messages[i] = _messages[i + 1];
			}
			_messages[18] = msg;
		}

		private void update_Tick(object sender, EventArgs e) {
			textBox2.Text = "";
			for (int i = 0; i < 19; i++) {
				textBox2.Text += _messages[i] + "\r\n";
			}
		}
	}
}

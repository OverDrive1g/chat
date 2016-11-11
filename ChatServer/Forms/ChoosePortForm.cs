using System;
using System.Windows.Forms;

namespace ChatServer.Forms
{
	public partial class ChoosePortForm : Form {
		private bool _isValid;
		public ChoosePortForm(){
			InitializeComponent();
			_isValid = false;
		}

		private void accept_Click(object sender, EventArgs e) {
			try {
				ushort port = Convert.ToUInt16(portTextBox.Text);
				MonitorForm.Port = port;
				_isValid = true;
				Close();
			}
			catch (Exception exception) {
				Console.Error.WriteLine(exception.Message);
				Application.Exit();
			}
		}

		private void ChoosePortForm_FormClosed(object sender, FormClosedEventArgs e) {
			if (!_isValid) {
				Application.Exit();
			}
		}
	}
}

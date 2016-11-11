using System;
using System.Windows.Forms;

namespace ChatClient.Forms
{
	public partial class LoginForm : Form
	{
		public LoginForm(){
			InitializeComponent();
		}

		private void acceptButton_Click(object sender, EventArgs e) {
			Program.Nick = nickTextBox.Text;
		    Program.Ip = ipTextBox.Text;
		    Program.Port = Convert.ToUInt16(portTextBox.Text);
			Close();
		}
	}
}

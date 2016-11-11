using System;
using System.Windows.Forms;

namespace ChatClient
{
	static class Program {
		public static string Nick { get; set; } = "unnamed";
	    public static string Ip { get; set; } = "localhost";
	    public static ushort Port { get; set; } = 12345;

		/// <summary>
		/// Главная точка входа для приложения.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
	}
}

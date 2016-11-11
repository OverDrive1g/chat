namespace ChatServer.Forms
{
	partial class MonitorForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.eventLog = new System.Windows.Forms.TextBox();
            this.update = new System.Windows.Forms.Timer(this.components);
            this.portLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // eventLog
            // 
            this.eventLog.Enabled = false;
            this.eventLog.Location = new System.Drawing.Point(12, 12);
            this.eventLog.Multiline = true;
            this.eventLog.Name = "eventLog";
            this.eventLog.Size = new System.Drawing.Size(440, 300);
            this.eventLog.TabIndex = 0;
            // 
            // update
            // 
            this.update.Interval = 500;
            this.update.Tick += new System.EventHandler(this.update_Tick);
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(459, 13);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(29, 13);
            this.portLabel.TabIndex = 1;
            this.portLabel.Text = "Port:";
            // 
            // MonitorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 324);
            this.Controls.Add(this.portLabel);
            this.Controls.Add(this.eventLog);
            this.Name = "MonitorForm";
            this.Text = "MonitorForm";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox eventLog;
		private System.Windows.Forms.Timer update;
        private System.Windows.Forms.Label portLabel;
    }
}
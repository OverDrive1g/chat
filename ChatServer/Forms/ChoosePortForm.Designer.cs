namespace ChatServer.Forms
{
	partial class ChoosePortForm
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
			this.portLabel = new System.Windows.Forms.Label();
			this.portTextBox = new System.Windows.Forms.TextBox();
			this.accept = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// portLabel
			// 
			this.portLabel.AutoSize = true;
			this.portLabel.Location = new System.Drawing.Point(13, 13);
			this.portLabel.Name = "portLabel";
			this.portLabel.Size = new System.Drawing.Size(35, 13);
			this.portLabel.TabIndex = 0;
			this.portLabel.Text = "Порт:";
			// 
			// portTextBox
			// 
			this.portTextBox.Location = new System.Drawing.Point(13, 30);
			this.portTextBox.Name = "portTextBox";
			this.portTextBox.Size = new System.Drawing.Size(100, 20);
			this.portTextBox.TabIndex = 1;
			// 
			// accept
			// 
			this.accept.Location = new System.Drawing.Point(12, 56);
			this.accept.Name = "accept";
			this.accept.Size = new System.Drawing.Size(75, 23);
			this.accept.TabIndex = 2;
			this.accept.Text = "Accept";
			this.accept.UseVisualStyleBackColor = true;
			this.accept.Click += new System.EventHandler(this.accept_Click);
			// 
			// ChoosePortForm
			// 
			this.AcceptButton = this.accept;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(148, 96);
			this.Controls.Add(this.accept);
			this.Controls.Add(this.portTextBox);
			this.Controls.Add(this.portLabel);
			this.Name = "ChoosePortForm";
			this.Text = "ChoosePortForm";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ChoosePortForm_FormClosed);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label portLabel;
		private System.Windows.Forms.TextBox portTextBox;
		private System.Windows.Forms.Button accept;
	}
}
namespace Blockchain_E_Voting_System_Application {
	partial class MainPage {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param _name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.electionFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.mainPageLabel = new System.Windows.Forms.Label();
			this.btnLogout = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// electionFlowLayoutPanel
			// 
			this.electionFlowLayoutPanel.Location = new System.Drawing.Point(12, 79);
			this.electionFlowLayoutPanel.Name = "electionFlowLayoutPanel";
			this.electionFlowLayoutPanel.Size = new System.Drawing.Size(261, 336);
			this.electionFlowLayoutPanel.TabIndex = 1;
			this.electionFlowLayoutPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.electionFlowLayoutPanel_Paint);
			// 
			// mainPageLabel
			// 
			this.mainPageLabel.AutoSize = true;
			this.mainPageLabel.Font = new System.Drawing.Font("MS UI Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.mainPageLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
			this.mainPageLabel.Location = new System.Drawing.Point(71, 32);
			this.mainPageLabel.Name = "mainPageLabel";
			this.mainPageLabel.Size = new System.Drawing.Size(138, 27);
			this.mainPageLabel.TabIndex = 1;
			this.mainPageLabel.Text = "Main Page";
			// 
			// btnLogout
			// 
			this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
			this.btnLogout.ForeColor = System.Drawing.Color.White;
			this.btnLogout.Location = new System.Drawing.Point(185, 496);
			this.btnLogout.Name = "btnLogout";
			this.btnLogout.Size = new System.Drawing.Size(88, 36);
			this.btnLogout.TabIndex = 10;
			this.btnLogout.Text = "Log Out";
			this.btnLogout.UseVisualStyleBackColor = false;
			this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
			// 
			// MainPage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(285, 544);
			this.Controls.Add(this.btnLogout);
			this.Controls.Add(this.mainPageLabel);
			this.Controls.Add(this.electionFlowLayoutPanel);
			this.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(165)))), ((int)(((byte)(169)))));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "MainPage";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "MainPage";
			this.Load += new System.EventHandler(this.MainPage_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

        #endregion

        private System.Windows.Forms.FlowLayoutPanel electionFlowLayoutPanel;
		private System.Windows.Forms.Label mainPageLabel;
		private System.Windows.Forms.Button btnLogout;
	}
}
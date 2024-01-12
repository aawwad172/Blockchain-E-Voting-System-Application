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
			this.electionflowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.SuspendLayout();
			// 
			// electionflowLayoutPanel
			// 
			this.electionflowLayoutPanel.Location = new System.Drawing.Point(12, 12);
			this.electionflowLayoutPanel.Name = "electionflowLayoutPanel";
			this.electionflowLayoutPanel.Size = new System.Drawing.Size(261, 520);
			this.electionflowLayoutPanel.TabIndex = 1;
			// 
			// MainPage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(285, 544);
			this.Controls.Add(this.electionflowLayoutPanel);
			this.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(165)))), ((int)(((byte)(169)))));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "MainPage";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "MainPage";
			this.Load += new System.EventHandler(this.MainPage_Load);
			this.ResumeLayout(false);

		}

        #endregion

        private System.Windows.Forms.FlowLayoutPanel electionflowLayoutPanel;
    }
}
namespace Blockchain_E_Voting_System_Application {
	partial class ResultForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
			this.listViewResults = new System.Windows.Forms.ListView();
			this.SuspendLayout();
			// 
			// listViewResults
			// 
			this.listViewResults.HideSelection = false;
			this.listViewResults.Location = new System.Drawing.Point(166, 84);
			this.listViewResults.Name = "listViewResults";
			this.listViewResults.Size = new System.Drawing.Size(420, 241);
			this.listViewResults.TabIndex = 0;
			this.listViewResults.UseCompatibleStateImageBehavior = false;
			this.listViewResults.View = System.Windows.Forms.View.List;
			// 
			// ResultForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.listViewResults);
			this.Name = "ResultForm";
			this.Text = "ResultForm";
			this.Load += new System.EventHandler(this.ResultForm_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListView listViewResults;
	}
}
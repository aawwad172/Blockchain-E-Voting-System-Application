namespace Blockchain_E_Voting_System_Application {
	partial class AdminDashboard {
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
			this.btnAddElection = new System.Windows.Forms.Button();
			this.dateTimePickerStartDate = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.dateTimePickerEndDate = new System.Windows.Forms.DateTimePicker();
			this.btnRemoveEleciton = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.txtElectionID = new System.Windows.Forms.TextBox();
			this.btnLogout = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnAddElection
			// 
			this.btnAddElection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
			this.btnAddElection.ForeColor = System.Drawing.Color.White;
			this.btnAddElection.Location = new System.Drawing.Point(40, 203);
			this.btnAddElection.Name = "btnAddElection";
			this.btnAddElection.Size = new System.Drawing.Size(214, 36);
			this.btnAddElection.TabIndex = 0;
			this.btnAddElection.Text = "Add Election";
			this.btnAddElection.UseVisualStyleBackColor = false;
			this.btnAddElection.Click += new System.EventHandler(this.btnAddElection_Click);
			// 
			// dateTimePickerStartDate
			// 
			this.dateTimePickerStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dateTimePickerStartDate.Location = new System.Drawing.Point(132, 118);
			this.dateTimePickerStartDate.Name = "dateTimePickerStartDate";
			this.dateTimePickerStartDate.Size = new System.Drawing.Size(122, 26);
			this.dateTimePickerStartDate.TabIndex = 1;
			this.dateTimePickerStartDate.ValueChanged += new System.EventHandler(this.dateTimePickerStartDate_ValueChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(165)))), ((int)(((byte)(169)))));
			this.label1.Location = new System.Drawing.Point(36, 124);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(76, 19);
			this.label1.TabIndex = 2;
			this.label1.Text = "Start Date";
			this.label1.Click += new System.EventHandler(this.label1_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(165)))), ((int)(((byte)(169)))));
			this.label2.Location = new System.Drawing.Point(36, 156);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(68, 19);
			this.label2.TabIndex = 3;
			this.label2.Text = "End Date";
			this.label2.Click += new System.EventHandler(this.label2_Click);
			// 
			// dateTimePickerEndDate
			// 
			this.dateTimePickerEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dateTimePickerEndDate.Location = new System.Drawing.Point(132, 150);
			this.dateTimePickerEndDate.Name = "dateTimePickerEndDate";
			this.dateTimePickerEndDate.Size = new System.Drawing.Size(122, 26);
			this.dateTimePickerEndDate.TabIndex = 4;
			this.dateTimePickerEndDate.ValueChanged += new System.EventHandler(this.dateTimePickerEndDate_ValueChanged);
			// 
			// btnRemoveEleciton
			// 
			this.btnRemoveEleciton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
			this.btnRemoveEleciton.ForeColor = System.Drawing.Color.White;
			this.btnRemoveEleciton.Location = new System.Drawing.Point(33, 376);
			this.btnRemoveEleciton.Name = "btnRemoveEleciton";
			this.btnRemoveEleciton.Size = new System.Drawing.Size(214, 36);
			this.btnRemoveEleciton.TabIndex = 5;
			this.btnRemoveEleciton.Text = "Remove Election";
			this.btnRemoveEleciton.UseVisualStyleBackColor = false;
			this.btnRemoveEleciton.Click += new System.EventHandler(this.button1_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(165)))), ((int)(((byte)(169)))));
			this.label3.Location = new System.Drawing.Point(36, 322);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(79, 19);
			this.label3.TabIndex = 7;
			this.label3.Text = "Election ID";
			this.label3.Click += new System.EventHandler(this.label3_Click);
			// 
			// txtElectionID
			// 
			this.txtElectionID.Location = new System.Drawing.Point(132, 315);
			this.txtElectionID.Name = "txtElectionID";
			this.txtElectionID.Size = new System.Drawing.Size(115, 26);
			this.txtElectionID.TabIndex = 8;
			this.txtElectionID.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			// 
			// btnLogout
			// 
			this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
			this.btnLogout.ForeColor = System.Drawing.Color.White;
			this.btnLogout.Location = new System.Drawing.Point(185, 496);
			this.btnLogout.Name = "btnLogout";
			this.btnLogout.Size = new System.Drawing.Size(88, 36);
			this.btnLogout.TabIndex = 9;
			this.btnLogout.Text = "Log Out";
			this.btnLogout.UseVisualStyleBackColor = false;
			this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("MS UI Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
			this.label4.Location = new System.Drawing.Point(12, 57);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(262, 27);
			this.label4.TabIndex = 10;
			this.label4.Text = "Elections Dashboard";
			// 
			// AdminDashboard
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(285, 544);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.btnLogout);
			this.Controls.Add(this.txtElectionID);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.btnRemoveEleciton);
			this.Controls.Add(this.dateTimePickerEndDate);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dateTimePickerStartDate);
			this.Controls.Add(this.btnAddElection);
			this.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "AdminDashboard";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "AdminDashboard";
			this.Load += new System.EventHandler(this.AdminDashboard_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

        #endregion

        private System.Windows.Forms.Button btnAddElection;
        private System.Windows.Forms.DateTimePicker dateTimePickerStartDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePickerEndDate;
        private System.Windows.Forms.Button btnRemoveEleciton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtElectionID;
        private System.Windows.Forms.Button btnLogout;
		private System.Windows.Forms.Label label4;
	}
}
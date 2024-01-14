namespace Blockchain_E_Voting_System_Application {
	partial class Candidates {
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtCandidateEmail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMajor = new System.Windows.Forms.TextBox();
            this.GPA = new System.Windows.Forms.Label();
            this.txtGPA = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCreditHours = new System.Windows.Forms.TextBox();
            this.btnRegisterCandidate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(385, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "Candidate Registration";
            // 
            // txtCandidateEmail
            // 
            this.txtCandidateEmail.Location = new System.Drawing.Point(103, 135);
            this.txtCandidateEmail.Name = "txtCandidateEmail";
            this.txtCandidateEmail.Size = new System.Drawing.Size(166, 30);
            this.txtCandidateEmail.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(99, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Email";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(99, 270);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Major";
            // 
            // txtMajor
            // 
            this.txtMajor.Location = new System.Drawing.Point(103, 323);
            this.txtMajor.Name = "txtMajor";
            this.txtMajor.Size = new System.Drawing.Size(166, 30);
            this.txtMajor.TabIndex = 3;
            // 
            // GPA
            // 
            this.GPA.AutoSize = true;
            this.GPA.Location = new System.Drawing.Point(99, 395);
            this.GPA.Name = "GPA";
            this.GPA.Size = new System.Drawing.Size(43, 23);
            this.GPA.TabIndex = 6;
            this.GPA.Text = "GPA";
            // 
            // txtGPA
            // 
            this.txtGPA.Location = new System.Drawing.Point(103, 440);
            this.txtGPA.Name = "txtGPA";
            this.txtGPA.Size = new System.Drawing.Size(166, 30);
            this.txtGPA.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(99, 491);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 23);
            this.label5.TabIndex = 8;
            this.label5.Text = "Credit Hours";
            // 
            // txtCreditHours
            // 
            this.txtCreditHours.Location = new System.Drawing.Point(103, 541);
            this.txtCreditHours.Name = "txtCreditHours";
            this.txtCreditHours.Size = new System.Drawing.Size(166, 30);
            this.txtCreditHours.TabIndex = 7;
            // 
            // btnRegisterCandidate
            // 
            this.btnRegisterCandidate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.btnRegisterCandidate.ForeColor = System.Drawing.Color.White;
            this.btnRegisterCandidate.Location = new System.Drawing.Point(142, 195);
            this.btnRegisterCandidate.Name = "btnRegisterCandidate";
            this.btnRegisterCandidate.Size = new System.Drawing.Size(87, 40);
            this.btnRegisterCandidate.TabIndex = 9;
            this.btnRegisterCandidate.Text = "Register";
            this.btnRegisterCandidate.UseVisualStyleBackColor = false;
            this.btnRegisterCandidate.Click += new System.EventHandler(this.btnRegisterCandidate_Click);
            // 
            // Candidates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(396, 582);
            this.Controls.Add(this.btnRegisterCandidate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCreditHours);
            this.Controls.Add(this.GPA);
            this.Controls.Add(this.txtGPA);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMajor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCandidateEmail);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(165)))), ((int)(((byte)(169)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "Candidates";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Candidates";
            this.Load += new System.EventHandler(this.Candidates_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCandidateEmail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMajor;
        private System.Windows.Forms.Label GPA;
        private System.Windows.Forms.TextBox txtGPA;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCreditHours;
        private System.Windows.Forms.Button btnRegisterCandidate;
    }
}
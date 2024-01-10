namespace Blockchain_E_Voting_System_Application {
	partial class LoginForm {
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtUserName = new System.Windows.Forms.TextBox();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.checkBoxShowPassword = new System.Windows.Forms.CheckBox();
			this.button1 = new System.Windows.Forms.Button();
			this.radioButtonStudent = new System.Windows.Forms.RadioButton();
			this.radioButtonAdmin = new System.Windows.Forms.RadioButton();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("MS UI Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
			this.label1.Location = new System.Drawing.Point(28, 68);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(94, 33);
			this.label1.TabIndex = 0;
			this.label1.Text = "Login";
			this.label1.Click += new System.EventHandler(this.label1_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(30, 140);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(89, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "Username";
			this.label2.Click += new System.EventHandler(this.label2_Click);
			// 
			// txtUserName
			// 
			this.txtUserName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
			this.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtUserName.Font = new System.Drawing.Font("MS UI Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtUserName.Location = new System.Drawing.Point(34, 181);
			this.txtUserName.Multiline = true;
			this.txtUserName.Name = "txtUserName";
			this.txtUserName.Size = new System.Drawing.Size(216, 28);
			this.txtUserName.TabIndex = 2;
			// 
			// txtPassword
			// 
			this.txtPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
			this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtPassword.Font = new System.Drawing.Font("MS UI Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtPassword.Location = new System.Drawing.Point(36, 279);
			this.txtPassword.Multiline = true;
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.PasswordChar = '*';
			this.txtPassword.Size = new System.Drawing.Size(216, 28);
			this.txtPassword.TabIndex = 4;
			this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(32, 238);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(84, 23);
			this.label3.TabIndex = 3;
			this.label3.Text = "Password";
			// 
			// checkBoxShowPassword
			// 
			this.checkBoxShowPassword.AutoSize = true;
			this.checkBoxShowPassword.Location = new System.Drawing.Point(36, 340);
			this.checkBoxShowPassword.Name = "checkBoxShowPassword";
			this.checkBoxShowPassword.Size = new System.Drawing.Size(155, 27);
			this.checkBoxShowPassword.TabIndex = 5;
			this.checkBoxShowPassword.Text = "Show Password";
			this.checkBoxShowPassword.UseVisualStyleBackColor = true;
			this.checkBoxShowPassword.CheckedChanged += new System.EventHandler(this.checkBoxShowPassword_CheckedChanged);
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
			this.button1.ForeColor = System.Drawing.Color.White;
			this.button1.Location = new System.Drawing.Point(34, 465);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(214, 36);
			this.button1.TabIndex = 6;
			this.button1.Text = "Log in";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new System.EventHandler(this.button1_Click_1);
			// 
			// radioButtonStudent
			// 
			this.radioButtonStudent.AutoSize = true;
			this.radioButtonStudent.Location = new System.Drawing.Point(34, 399);
			this.radioButtonStudent.Name = "radioButtonStudent";
			this.radioButtonStudent.Size = new System.Drawing.Size(94, 27);
			this.radioButtonStudent.TabIndex = 7;
			this.radioButtonStudent.Text = "Student";
			this.radioButtonStudent.UseVisualStyleBackColor = true;
			this.radioButtonStudent.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
			// 
			// radioButtonAdmin
			// 
			this.radioButtonAdmin.AutoSize = true;
			this.radioButtonAdmin.Location = new System.Drawing.Point(163, 399);
			this.radioButtonAdmin.Name = "radioButtonAdmin";
			this.radioButtonAdmin.Size = new System.Drawing.Size(85, 27);
			this.radioButtonAdmin.TabIndex = 8;
			this.radioButtonAdmin.Text = "Admin";
			this.radioButtonAdmin.UseVisualStyleBackColor = true;
			// 
			// LoginForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(285, 544);
			this.Controls.Add(this.radioButtonAdmin);
			this.Controls.Add(this.radioButtonStudent);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.checkBoxShowPassword);
			this.Controls.Add(this.txtPassword);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtUserName);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(165)))), ((int)(((byte)(169)))));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "LoginForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Login";
			this.Load += new System.EventHandler(this.LoginForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtUserName;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.CheckBox checkBoxShowPassword;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.RadioButton radioButtonStudent;
		private System.Windows.Forms.RadioButton radioButtonAdmin;
	}
}


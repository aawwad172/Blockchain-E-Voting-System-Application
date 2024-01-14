using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Text.RegularExpressions;

namespace Blockchain_E_Voting_System_Application {

	public partial class LoginForm : Form {

        SQLiteConnection conn = new SQLiteConnection("Data Source=E-Voting System.db;Version=3;");
        SQLiteCommand cmd = new SQLiteCommand();

		private int userID;

        public LoginForm() {
			InitializeComponent();

		}

		private void label1_Click(object sender, EventArgs e) {

		}

		private void label2_Click(object sender, EventArgs e) {

		}

		private void checkBoxShowPassword_CheckedChanged(object sender, EventArgs e) {
			txtPassword.UseSystemPasswordChar = checkBoxShowPassword.Checked;
		}

		private void button1_Click(object sender, EventArgs e) {
			


		}

		private void LoginForm_Load(object sender, EventArgs e) {

		}


		private void button1_Click_1(object sender, EventArgs e) {

			if (!radioButtonStudent.Checked && !radioButtonAdmin.Checked) {
				MessageBox.Show("Please select either Student or Admin.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			string emailPattern = @"^[a-zA-Z0-9._%+-]+@std\.psut\.edu\.jo$";
			string email = txtUserName.Text.ToLower();
			string password = txtPassword.Text;


			if (!Regex.IsMatch(email, emailPattern)&&radioButtonStudent.Checked){
                MessageBox.Show("The email should be within the PSUT Organization domain!");
				return;
            }


			if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password)) {
				MessageBox.Show("Email or Password are empty!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			string connectionString = "Data Source=E-Voting System.db;Version=3;";

			try {
				using (SQLiteConnection conn = new SQLiteConnection(connectionString)) {
					conn.Open();

					string query;
					if (radioButtonAdmin.Checked) {
						// For admin, just check the credentials
						query = "SELECT 1 FROM Admins WHERE email = @email AND password = @password";
					} else {
						// For student, get the studentID along with the check
						query = "SELECT studentID FROM Students WHERE email = @email AND password = @password";
					}

					using (SQLiteCommand cmd = new SQLiteCommand(query, conn)) {
						cmd.Parameters.AddWithValue("@email", email);
						cmd.Parameters.AddWithValue("@password", password);

						using (SQLiteDataReader reader = cmd.ExecuteReader()) {
							if (reader.Read()) {
								if (!radioButtonAdmin.Checked) {
									// Set the userID if it's a student
									userID = Convert.ToInt32(reader["studentID"]);
								}

								this.Hide();

								if (radioButtonAdmin.Checked) {
									AdminDashboard adminDashboard = new AdminDashboard();
									adminDashboard.Show();
								} else {
									MainPage mainPage = new MainPage(userID);
									mainPage.Show();
								}
							} else {
								MessageBox.Show("Invalid email or password.");
							}
						}
					}
				}
			} catch (Exception ex) {
				MessageBox.Show("Error: " + ex.Message);
			}
		}

		private void txtPassword_TextChanged(object sender, EventArgs e) {

		}

		private void radioButton1_CheckedChanged(object sender, EventArgs e) {

		}
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb; // For the Microsoft Access Database!

namespace Blockchain_E_Voting_System_Application {
	public partial class LoginForm : Form {

		OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0,Data Source=Users_db.mdb");
		OleDbCommand cmd = new OleDbCommand();
		OleDbDataAdapter adapter = new OleDbDataAdapter();

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
			string username = txtUserName.Text;
			string password = txtPassword.Text;

			if ("" == username || "" == password) {
				MessageBox.Show("Username or password are empty!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Users_db.mdb";

			try {
				conn.Open();

				// SQL query to check if a user with the given username and password exists
				string query = "SELECT COUNT(1) FROM Users WHERE Username = @username AND Password = @password";

				// OleDbCommand and Parameters
				OleDbCommand cmd = new OleDbCommand(query, conn);
				cmd.Parameters.AddWithValue("@username", username);
				cmd.Parameters.AddWithValue("@password", password);

				// Execute the query and check the result
				int userExists = (int)cmd.ExecuteScalar();

				if (userExists > 0) {
					Console.WriteLine("Maniak");
					// User exists, open Form2
					MainPage mainPage = new MainPage();
					// MainPage.Show();
				} else {
					MessageBox.Show("Invalid username or password.");
				}
			} catch (Exception ex) {
				MessageBox.Show("Error: " + ex.Message);
			} finally {
				conn.Close();
			}
		}
	}
}

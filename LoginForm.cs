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

namespace Blockchain_E_Voting_System_Application {
	public partial class LoginForm : Form {

        SQLiteConnection conn = new SQLiteConnection("Data Source=login.db;Version=3;");
        SQLiteCommand cmd = new SQLiteCommand();


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

            if ("" == username || "" == password)
            {
                MessageBox.Show("Username or password are empty!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string connectionString = "Data Source=login.db;Version=3;";

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();

                    string query = "SELECT Username, Password FROM Users WHERE Username = @username AND Password = @password";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {    
                                MainPage mainPage = new MainPage();
                                mainPage.Show();
                            }
                            else
                            {
                                MessageBox.Show("Invalid username or password.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }
    }
}

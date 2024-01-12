using Blockchain_E_Voting_System_Application.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blockchain_E_Voting_System_Application {
	public partial class AdminDashboard : Form {
		public AdminDashboard() {
			InitializeComponent();
		}

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAddElection_Click(object sender, EventArgs e)
        {
            DateTime startDate = dateTimePickerStartDate.Value;
            DateTime endDate = dateTimePickerEndDate.Value;

            // Create an instance of the Election class
            Election newElection = new Election(startDate, endDate);

            // Add to database
            string connectionString = "Data Source=E-Voting System.db;Version=3;";
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string query = "INSERT INTO Elections (electionID, startDate, endDate) VALUES (@electionID, @startDate, @endDate)";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@electionID", newElection.ElectionID);
                    cmd.Parameters.AddWithValue("@startDate", newElection._startDate);
                    cmd.Parameters.AddWithValue("@endDate", newElection._endDate);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Election Added Succefully!");
                }
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=E-Voting System.db;Version=3;";
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                if (int.TryParse(txtElectionID.Text, out int electionID))
                {
                    string query = "DELETE FROM Elections WHERE electionID = @electionID";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@electionID", electionID);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Election Removed Successfully!");
                        }
                        else
                        {
                            MessageBox.Show("Election Doesn't Exist!");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Election ID format.");
                }
                conn.Close();
            }

        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePickerEndDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePickerStartDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }
    }
}

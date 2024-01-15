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

                string query = "INSERT INTO Elections (startDate, endDate) VALUES (@startDate, @endDate)";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@startDate", newElection._startDate);
                    cmd.Parameters.AddWithValue("@endDate", newElection._endDate);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show($"Election Added Successfully!");
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
                txtElectionID.Clear();
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

		private void label4_Click(object sender, EventArgs e) {

		}

		private void button1_Click_1(object sender, EventArgs e) {
			var results = new List<Tuple<string, int, string>>(); // major, candidateID, candidateName

			Console.WriteLine("Starting to process election results...");

			// Parse the election ID from the text box
			if (!int.TryParse(textResultElectionID.Text, out int electionID)) {
				MessageBox.Show("Invalid Election ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				Console.WriteLine("Error: Invalid Election ID input.");
				return;
			}

			Console.WriteLine($"Election ID: {electionID}");

			string connectionString = "Data Source=E-Voting System.db;Version=3;";
			string query = @"
                            SELECT 
                                Students.studentMajor, 
                                ec.candidateID, 
                                Students.name,
                                SUM(Candidates.totalVotes) as TotalVotes
                            FROM ElectionCandidates ec
                            INNER JOIN Candidates ON ec.candidateID = Candidates.candidateID
                            INNER JOIN Students ON Candidates.studentID_FK = Students.studentID
                            WHERE ec.electionID = @ElectionID
                            GROUP BY Students.studentMajor, ec.candidateID
                            ORDER BY Students.studentMajor, TotalVotes DESC";

			try {
				using (SQLiteConnection conn = new SQLiteConnection(connectionString)) {
					conn.Open();
					Console.WriteLine("Database connection opened successfully.");

					using (SQLiteCommand cmd = new SQLiteCommand(query, conn)) {
						cmd.Parameters.AddWithValue("@ElectionID", electionID);

						using (SQLiteDataReader reader = cmd.ExecuteReader()) {
							if (!reader.HasRows) {
								Console.WriteLine("No results found for the election.");
								MessageBox.Show("No results found.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
								return;
							}

							string currentMajor = "";
							while (reader.Read()) {
								string major = reader["studentMajor"].ToString();
								if (major != currentMajor) {
									int candidateID = Convert.ToInt32(reader["candidateID"]);
									string candidateName = reader["name"].ToString();
									Console.WriteLine($"Major: {major}, Winner Candidate ID: {candidateID}, Name: {candidateName}");
									results.Add(new Tuple<string, int, string>(major, candidateID, candidateName));
									currentMajor = major;
								}
							}
						}
					}
					OpenResultsForm(results);
				}
			} catch (Exception ex) {
				MessageBox.Show("An error occurred while processing results: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				Console.WriteLine($"Error while processing results: {ex.Message}");
			}

			Console.WriteLine("Election results processing completed.");
		}

		private void OpenResultsForm(List<Tuple<string, int, string>> results) {
			ResultForm resultsForm = new ResultForm(results);
			resultsForm.Show();
		}
	}
}

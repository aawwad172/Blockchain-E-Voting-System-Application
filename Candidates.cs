using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blockchain_E_Voting_System_Application {
	public partial class Candidates : Form {
		private int selectedElectionID;

		public Candidates(int selectedElectionID) {
            InitializeComponent();
            this.selectedElectionID = selectedElectionID;
        }

		public Candidates() {
			InitializeComponent();
		}

		private void Candidates_Load(object sender, EventArgs e) {

		}

        private void btnRegisterCandidate_Click(object sender, EventArgs e)
        {
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@std\.psut\.edu\.jo$";
            string email = txtCandidateEmail.Text.ToLower();

            // Validate email
            if (!Regex.IsMatch(email, emailPattern))
            {
                MessageBox.Show("The email should be within the PSUT Organization domain!");
                return;
            }

            // Database connection string
            string connectionString = "Data Source=E-Voting System.db;Version=3;";
            SQLiteConnection conn = new SQLiteConnection(connectionString);

            try
            {
                conn.Open();

                string query = "SELECT studentID, gpa, studentMajor, creditHours FROM Students WHERE email = @Email";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);

                SQLiteDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    double gpa = Convert.ToDouble(reader["gpa"]);
                    int creditHours = Convert.ToInt32(reader["creditHours"]);

                    // Check if GPA is lower than 80 or credit hours are less than 33
                    if (gpa < 68)
                    {
                        MessageBox.Show("You cannot be a candidate due to GPA or credit hour requirements.");
                    }
                    else if (creditHours < 33)
                    {
                        MessageBox.Show("You cannot be a candidate due to credit hour requirements.");
                    }
                    else
                    {
                        // Set the text boxes if the student meets the requirements
                        txtGPA.Text = gpa.ToString();
                        txtMajor.Text = reader["studentMajor"].ToString();
                        txtCreditHours.Text = creditHours.ToString();
                        int studentID = reader.GetInt32(reader.GetOrdinal("studentID"));
                        AddCandidateToDatabase(conn, studentID);
                    }
                }
                else
                {
                    MessageBox.Show("Email not found in the database.");
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }


        private void AddCandidateToDatabase(SQLiteConnection conn, int studentID)
        {
            using (var transaction = conn.BeginTransaction())
            {
                try
                {
                    // Insert into Candidates table
                    var insertCandidateCmd = new SQLiteCommand("INSERT INTO Candidates (totalVotes, studentID_FK) VALUES (0, @StudentID); SELECT last_insert_rowid();", conn);
                    insertCandidateCmd.Parameters.AddWithValue("@StudentID", studentID);
                    int candidateID = Convert.ToInt32(insertCandidateCmd.ExecuteScalar());

                    // Insert into ElectionCandidates table
                    var insertElectionCandidateCmd = new SQLiteCommand("INSERT INTO ElectionCandidates (electionID, candidateID) VALUES (@ElectionID, @CandidateID)", conn);
                    insertElectionCandidateCmd.Parameters.AddWithValue("@ElectionID", selectedElectionID);
                    insertElectionCandidateCmd.Parameters.AddWithValue("@CandidateID", candidateID);
                    insertElectionCandidateCmd.ExecuteNonQuery();

                    transaction.Commit();
                    MessageBox.Show("Candidate successfully registered.");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("An error occurred while registering the candidate: " + ex.Message);
                }
            }
        }

		private void txtMajor_TextChanged(object sender, EventArgs e) {

		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			this.Close();
		}
	}
}

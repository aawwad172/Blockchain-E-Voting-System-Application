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

namespace Blockchain_E_Voting_System_Application
{
    public partial class Elections : Form
    {

		private int selectedElectionID;
		private int userID;

		public Elections(int electionID, int userID) {
			InitializeComponent();

			// Assign the selected election ID to the private variable
			selectedElectionID = electionID;
			this.userID = userID;
		}

		private void Elections_Load(object sender, EventArgs e) {
			Console.WriteLine("Election ID: " +  selectedElectionID + " StudentID: " + userID);
			string connectionString = "Data Source=E-Voting System.db;Version=3;"; // Your actual connection string

			Console.WriteLine($"Debug: Elections_Load started. UserID: {userID}, ElectionID: {selectedElectionID}");

			try {
				using (SQLiteConnection conn = new SQLiteConnection(connectionString)) {
					conn.Open();

					// First, retrieve the major of the logged-in student
					string majorQuery = "SELECT studentMajor FROM Students WHERE studentID = @userID";
					string studentMajor = null;

					using (SQLiteCommand majorCmd = new SQLiteCommand(majorQuery, conn)) {
						majorCmd.Parameters.AddWithValue("@userID", userID);

						using (SQLiteDataReader majorReader = majorCmd.ExecuteReader()) {
							if (majorReader.Read()) {
								studentMajor = majorReader["studentMajor"].ToString();
								Console.WriteLine($"Debug: Student major retrieved: {studentMajor}");
							} else {
								MessageBox.Show("Student major not found.");
								return;
							}
						}
					}

					string candidatesQuery = @"
                SELECT Students.name FROM Candidates
                INNER JOIN ElectionCandidates ON Candidates.candidateID = ElectionCandidates.candidateID
                INNER JOIN Students ON Candidates.studentID_FK = Students.studentID
                WHERE Students.studentMajor = @studentMajor AND ElectionCandidates.electionID = @electionID";

					using (SQLiteCommand candidatesCmd = new SQLiteCommand(candidatesQuery, conn)) {
						candidatesCmd.Parameters.AddWithValue("@studentMajor", studentMajor);
						candidatesCmd.Parameters.AddWithValue("@electionID", selectedElectionID);

						using (SQLiteDataReader candidatesReader = candidatesCmd.ExecuteReader()) {
							if (candidatesReader.HasRows) {
								while (candidatesReader.Read()) {
									string candidateName = candidatesReader["name"].ToString();
									Console.WriteLine($"Debug: Candidate found: {candidateName}");
									listView1.Items.Add(new ListViewItem(candidateName));
								}
							} else {
								Console.WriteLine("Debug: No candidates found for the given major and election ID.");
							}
						}
					}
				}
			} catch (Exception ex) {
				MessageBox.Show("Error: " + ex.Message);
				Console.WriteLine($"Error: {ex.ToString()}");
			}
		}


		private void listView1_SelectedIndexChanged(object sender, EventArgs e) {

		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			this.Close();
		}
	}
}

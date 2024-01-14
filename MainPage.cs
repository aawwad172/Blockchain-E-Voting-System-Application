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
using static System.Collections.Specialized.BitVector32;

namespace Blockchain_E_Voting_System_Application
{
    public partial class MainPage : Form
    {
		private int selectedElectionID;
        private int userID;

		public MainPage(int userID)
        {
            this.userID = userID;
            InitializeComponent();
            Load += MainPage_Load;
        }


        private void MainPage_Load(object sender, EventArgs e)
        {
            List<Election> list = getElections();
            DisplayElections(list);
        }



        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        // Function to retrieve the Elections from the Database.

        private List<Election> getElections()
        {
            var list = new List<Election>();

            string connectionString = "Data Source=E-Voting System.db;Version=3;";

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();

                    string query = "SELECT * FROM Elections WHERE endDate > @currentDate";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@currentDate", DateTime.Now);

                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Attempt to parse the startDate and endDate
                                if (DateTime.TryParse(reader["startDate"].ToString(), out DateTime startDate) &&
                                    DateTime.TryParse(reader["endDate"].ToString(), out DateTime endDate)) {

                                    // Successfully parsed, create a new Election object
                                    Election election = new Election(startDate, endDate);
                                    election.ElectionID = Convert.ToInt32(reader["electionID"]);
                                    list.Add(election);

                                  
                                }
                                else {
                                    // Parsing failed, log the failure with the election ID
                                    Console.WriteLine("Failed to parse dates for election ID " + reader["electionID"].ToString());
                                    // You can handle the parse failure here, e.g., skip this record, show a message, etc.
                                }
                            }
                        }
                    }

                    conn.Close();
                }

                Console.WriteLine($"Retrieved {list.Count} elections from the database.");

                // Optionally, check if there are no elections
                if (list.Count == 0)
                {
                    // Handle the case when no elections are retrieved
                    // You can display a message or take appropriate action
                    Console.WriteLine("No elections found.");
                }

                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving elections: {ex.Message}");
                MessageBox.Show(ex.Message);
                // Returning empty list!
                return list;
            }
        }


        private void DisplayElections(List<Election> elections)
        {
            // Suspend layout for smooth performance
            electionFlowLayoutPanel.SuspendLayout();

            try
            {
                // Clear existing controls
                electionFlowLayoutPanel.Controls.Clear();

                Console.WriteLine($"Displaying {elections.Count} elections.");

                foreach (Election election in elections)
                {
                    // Create a button for each election
                    Button electionButton = new Button();
                    electionButton.Text = $"Election ID: {election.ElectionID}";
                    electionButton.Tag = election;  // Attach the Election object to the button
                    electionButton.Click += ElectionButton_Click;  // Subscribe to the Click event

                    // Set the size of the button
                    electionButton.Size = new Size(150, 50);  // Adjust the width and height as needed

                    

                    // Add the button to the FlowLayoutPanel
                    electionFlowLayoutPanel.Controls.Add(electionButton);
                }
            }
            finally
            {
                // Resume layout after adding controls
                electionFlowLayoutPanel.ResumeLayout();
            }
        }

        private void ElectionButton_Click(object sender, EventArgs e) {
            // Extract the Election object from the button's Tag property
            Election selectedElection = (Election)((Button)sender).Tag;

            selectedElectionID = selectedElection.ElectionID;

            // Check if the election has already ended
            Console.WriteLine("startDate: " + selectedElection._startDate + " endDate: " + selectedElection._endDate);

            if (selectedElection._startDate >= selectedElection._endDate)
            {
                MessageBox.Show("Election has ended!");
                return; // Exit the method
            }

			// Check if the current date is the election start date or before or the user already nominated himself into the election!
			Console.WriteLine("Checking if the user is already a candidate.");
            if(IsUserACandidate(userID, selectedElectionID)) {
				Elections electionsPage = new Elections(selectedElectionID, userID);
				electionsPage.Show();
			}
			else if (DateTime.Now.Date == selectedElection._startDate.Date)
            {
                // It's the registration period (including the start date)
                Candidates candidatePage = new Candidates(selectedElectionID);
                candidatePage.Show();
            }
            else
            {
                // It's past the registration period, begin voting
                Elections electionsPage = new Elections(selectedElectionID, userID);
                electionsPage.Show();
            }

        }

		private bool IsUserACandidate(int userID, int electionID) {
			string connectionString = "Data Source=E-Voting System.db;Version=3;";
			string query = @"SELECT COUNT(*) 
                    FROM ElectionCandidates
                    INNER JOIN Candidates ON ElectionCandidates.candidateID = Candidates.candidateID
                    WHERE Candidates.studentID_FK = @UserID AND ElectionCandidates.electionID = @ElectionID";

			Console.WriteLine("Connecting to DB with Connection String: " + connectionString);

			using (SQLiteConnection conn = new SQLiteConnection(connectionString)) {
				try {
					conn.Open();
					Console.WriteLine("Connection Opened.");

					using (SQLiteCommand cmd = new SQLiteCommand(query, conn)) {
						cmd.Parameters.AddWithValue("@UserID", userID);
						cmd.Parameters.AddWithValue("@ElectionID", electionID);
						Console.WriteLine($"Executing query with UserID: {userID}, ElectionID: {electionID}");

						int count = Convert.ToInt32(cmd.ExecuteScalar());
						Console.WriteLine($"Query Result Count: {count}");

						return count > 0;
					}
				} catch (Exception ex) {
					Console.WriteLine("Error in IsUserACandidate: " + ex.Message);
					return false; // or handle the error as appropriate
				}
			}
		}




		private void electionFlowLayoutPanel_Paint(object sender, PaintEventArgs e)
        {
            
        }

		private void btnLogout_Click(object sender, EventArgs e) {
			this.Close();
			LoginForm loginForm = new LoginForm();
			loginForm.Show();
		}
	}
}

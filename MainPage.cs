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
    public partial class MainPage : Form
    {
		private int selectedElectionID;

		public MainPage()
        {
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
                                Election election = new Election(Convert.ToDateTime(reader["startDate"]), Convert.ToDateTime(reader["endDate"]));
                                election.ElectionID = Convert.ToInt32(reader["electionID"]);
                                list.Add(election);
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

        private void ElectionButton_Click(object sender, EventArgs e)
        {
            // Extract the Election object from the button's Tag property
            Election selectedElection = (Election)((Button)sender).Tag;

			selectedElectionID = selectedElection.ElectionID;

            
            if (selectedElection.EndDate > selectedElection.StartDate)
            {
                Console.WriteLine("Election has ended!");
                MessageBox.Show("Election has ended!");
            } 

            if (DateTime.Now >= selectedElection.StartDate.AddDays(1)) {
                Elections electionsPage = new Elections(selectedElectionID);
			    electionsPage.Show();
            } else {
                Candidates candidatePage = new Candidates(selectedElectionID);
                candidatePage.Show();
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

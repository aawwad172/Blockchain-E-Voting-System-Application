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
	public partial class MainPage : Form {
		public MainPage() {
			InitializeComponent();
		}

        private void MainPage_Load(object sender, EventArgs e)
        {
            getElections();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

		// Function to retrieve the Elections from the Database.

		private List<Election> getElections() {
			var list = new List<Election>();

			string connectionString = "Data Source=E-Voting System.db;Version=3;";

			try {
				using (SQLiteConnection conn = new SQLiteConnection(connectionString)) {
					conn.Open();

					string query = "SELECT * FROM Elections WHERE endDate > @currentDate";
					using (SQLiteCommand cmd = new SQLiteCommand(query, conn)) {
						cmd.Parameters.AddWithValue("@currentDate", DateTime.Now);

						using (SQLiteDataReader reader = cmd.ExecuteReader()) {
							while (reader.Read()) {
								Election election = new Election(Convert.ToDateTime(reader["startDate"]), Convert.ToDateTime(reader["endDate"]));
								election.ElectionID = Convert.ToInt32(reader["electionID"]);
								list.Add(election);
							}
						}
					}

					conn.Close();
				}

				Console.WriteLine($"Retrieved {list.Count} elections from the database.");
				return list;
			} catch (Exception ex) {
				Console.WriteLine($"Error retrieving elections: {ex.Message}");
				MessageBox.Show(ex.Message);
				// Returning empty list!
				return list;
			}
		}

		private void DisplayElections(List<Election> elections) {
			// Suspend layout for smooth performance
			electionFlowLayoutPanel.SuspendLayout();

			try {
				// Clear existing controls
				electionFlowLayoutPanel.Controls.Clear();

				Console.WriteLine($"Displaying {elections.Count} elections.");

				// Batch size for adding controls
				int batchSize = 10;
				int currentBatch = 0;

				foreach (Election election in elections) {
					// Create a panel for each election
					Panel electionPanel = new Panel();
					electionPanel.BorderStyle = BorderStyle.FixedSingle;

					// Add labels for election details
					Label lblElectionID = new Label();
					lblElectionID.Text = $"Election ID: {election.ElectionID}";
					electionPanel.Controls.Add(lblElectionID);

					Label lblStartDate = new Label();
					lblStartDate.Text = $"Start Date: {election.StartDate.ToString("yyyy-MM-dd")}";
					electionPanel.Controls.Add(lblStartDate);

					Label lblEndDate = new Label();
					lblEndDate.Text = $"End Date: {election.EndDate.ToString("yyyy-MM-dd")}";
					electionPanel.Controls.Add(lblEndDate);

					// Add the panel to the FlowLayoutPanel
					electionFlowLayoutPanel.Controls.Add(electionPanel);

					currentBatch++;

					// If the batch size is reached, perform a layout
					if (currentBatch >= batchSize) {
						electionFlowLayoutPanel.PerformLayout();
						currentBatch = 0;
					}
				}

				// Perform a final layout after adding all controls
				electionFlowLayoutPanel.PerformLayout();
			} finally {
				// Resume layout after adding controls
				electionFlowLayoutPanel.ResumeLayout();
			}
		}


		private void electionFlowLayoutPanel_Paint(object sender, PaintEventArgs e) {
			List<Election> list = new List<Election>();
			list = getElections();

			DisplayElections(list);
		}

	}
}

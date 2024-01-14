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
        private int candidateID;
        Dictionary<int, Blockchain> electionBlockchains = new Dictionary<int, Blockchain>();


        public Elections(int electionID, int userID) {
			InitializeComponent();

			selectedElectionID = electionID;
			this.userID = userID;
		}

		private void Elections_Load(object sender, EventArgs e) {
			Console.WriteLine("Election ID: " +  selectedElectionID + " StudentID: " + userID);
			string connectionString = "Data Source=E-Voting System.db;Version=3;";

			Console.WriteLine($"Debug: Elections_Load started. UserID: {userID}, ElectionID: {selectedElectionID}");

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();

                    // Retrieve the major of the logged-in student
                    string majorQuery = "SELECT studentMajor FROM Students WHERE studentID = @userID";
                    string studentMajor = null;

					using (SQLiteCommand majorCmd = new SQLiteCommand(majorQuery, conn)) {
						majorCmd.Parameters.AddWithValue("@userID", userID);

                        using (SQLiteDataReader majorReader = majorCmd.ExecuteReader())
                        {
                            if (majorReader.Read())
                            {
                                studentMajor = majorReader["studentMajor"].ToString();
                                Console.WriteLine($"Debug: Student major retrieved: {studentMajor}");
                            }
                            else
                            {
                                MessageBox.Show("Student major not found.");
                                return;
                            }
                        }
                    }

                    // Query to get candidates' names and IDs
                    string candidatesQuery = @"
            SELECT Candidates.candidateID, Students.name FROM Candidates
            INNER JOIN ElectionCandidates ON Candidates.candidateID = ElectionCandidates.candidateID
            INNER JOIN Students ON Candidates.studentID_FK = Students.studentID
            WHERE Students.studentMajor = @studentMajor AND ElectionCandidates.electionID = @electionID";

                    using (SQLiteCommand candidatesCmd = new SQLiteCommand(candidatesQuery, conn))
                    {
                        candidatesCmd.Parameters.AddWithValue("@studentMajor", studentMajor);
                        candidatesCmd.Parameters.AddWithValue("@electionID", selectedElectionID);

                        using (SQLiteDataReader candidatesReader = candidatesCmd.ExecuteReader())
                        {
                            if (candidatesReader.HasRows)
                            {
                                while (candidatesReader.Read())
                                {
                                    int candidateId = Convert.ToInt32(candidatesReader["candidateID"]);
                                    string candidateName = candidatesReader["name"].ToString();
                                    Console.WriteLine($"Debug: Candidate found: {candidateName} (ID: {candidateId})");

                                    // Create a new ListViewItem with the candidate's name
                                    ListViewItem item = new ListViewItem(candidateName+candidateId);
                                    // Use the Tag property to store the candidate ID
                                    item.Tag = candidateId;
                                    listView1.Items.Add(item);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Debug: No candidates found for the given major and election ID.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                Console.WriteLine($"Error: {ex.ToString()}");
            }

        }


        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                int selectedCandidateId = (int)selectedItem.Tag;
                candidateID = selectedCandidateId;
                Console.WriteLine($"Selected Candidate ID: {selectedCandidateId}");

                // You can use selectedCandidateId as needed, for example, to cast a vote


            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			this.Close();
		}

        private void btnVote_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a candidate.");
                return;
            }

			if (!electionBlockchains.ContainsKey(selectedElectionID)) {
				InitializeBlockchainForElection(selectedElectionID);
			}

			IncrementCandidateVote(candidateID);

            int voteID = CreateVoteRecord(userID,candidateID);

			int voterID = AddVoter(userID);

			Voter voter = GetVoterDetails(voterID);
			if (voter != null) {
                // Creating new Vote object
                Vote newVote = new Vote(voter, candidateID, DateTime.UtcNow);

                AddVoteToBlockchain(selectedElectionID, newVote);

				// Get the latest block from the blockchain
				Block latestBlock = electionBlockchains[selectedElectionID].CurrentBlock;

				if (latestBlock != null) {
					InsertBlockIntoDatabase(latestBlock);
					MessageBox.Show("Your vote has been cast and recorded in the blockchain.");
				} else {
					MessageBox.Show("Failed to record the vote in the blockchain.");
				}
			} else {
				MessageBox.Show("Failed to retrieve voter details.");
			}
		}

		public void IncrementCandidateVote(int candidateID) {
			Console.WriteLine($"Incrementing vote count for CandidateID: {candidateID}");

			string connectionString = "Data Source=E-Voting System.db;Version=3;";
			string updateQuery = "UPDATE Candidates SET totalVotes = totalVotes + 1 WHERE candidateID = @CandidateId";

			using (SQLiteConnection conn = new SQLiteConnection(connectionString)) {
				conn.Open();
				using (SQLiteCommand cmd = new SQLiteCommand(updateQuery, conn)) {
					cmd.Parameters.AddWithValue("@CandidateId", candidateID);
					int rowsAffected = cmd.ExecuteNonQuery();
					Console.WriteLine($"Vote count updated. Rows affected: {rowsAffected}");
				}
				conn.Close();
			}
		}

		public int CreateVoteRecord(int voterId, int candidateId) {
			Console.WriteLine($"Creating vote record. VoterID: {voterId}, CandidateID: {candidateId}");

			string connectionString = "Data Source=E-Voting System.db;Version=3;";
			string insertQuery = "INSERT INTO Votes (voterID, candidateID, timeStamp) " +
                                    "VALUES (@VoterId, @CandidateId, @TimeStamp); " +
                                    "SELECT last_insert_rowid();";

			using (SQLiteConnection conn = new SQLiteConnection(connectionString)) {
				conn.Open();
				using (SQLiteCommand cmd = new SQLiteCommand(insertQuery, conn)) {
					cmd.Parameters.AddWithValue("@VoterId", voterId);
					cmd.Parameters.AddWithValue("@CandidateId", candidateId);
					cmd.Parameters.AddWithValue("@TimeStamp", DateTime.UtcNow);
					int voteId = Convert.ToInt32(cmd.ExecuteScalar());
					Console.WriteLine($"Vote record created. VoteID: {voteId}");

					return voteId;
				}
			}
		}

		public int AddVoter(int studentID) {
			Console.WriteLine($"Adding voter. StudentID: {studentID}");

			string connectionString = "Data Source=E-Voting System.db;Version=3;";
			string insertQuery = "INSERT INTO Voters (studentID_FK) VALUES (@StudentID); SELECT last_insert_rowid();";

			using (SQLiteConnection conn = new SQLiteConnection(connectionString)) {
				conn.Open();
				using (SQLiteCommand cmd = new SQLiteCommand(insertQuery, conn)) {
					cmd.Parameters.AddWithValue("@StudentID", studentID);
					int voterID = Convert.ToInt32(cmd.ExecuteScalar());
					Console.WriteLine($"Voter added. VoterID: {voterID}");

					return voterID;
				}
			}
		}

		public void InitializeBlockchainForElection(int electionId) {
			Console.WriteLine($"Initializing blockchain for ElectionID: {electionId}");

			Blockchain blockchain = new Blockchain();
			electionBlockchains[electionId] = blockchain;

			Console.WriteLine("Blockchain initialized.");
		}

		internal void InsertBlockIntoDatabase(Block block) {
			Console.WriteLine($"Inserting block into database. Block Hash: {block.Hash}");

			string connectionString = "Data Source=E-Voting System.db;Version=3;";
			string insertQuery = "INSERT INTO Blocks (previousHash, voteID, hash) VALUES (@PreviousHash, @VoteID, @Hash)";

			using (SQLiteConnection conn = new SQLiteConnection(connectionString)) {
				conn.Open();
				using (SQLiteCommand cmd = new SQLiteCommand(insertQuery, conn)) {
					cmd.Parameters.AddWithValue("@PreviousHash", block.PreviousHash);
					cmd.Parameters.AddWithValue("@VoteID", block.VoteRecord.VoteID);
					cmd.Parameters.AddWithValue("@Hash", block.Hash);
					int rowsAffected = cmd.ExecuteNonQuery();
					Console.WriteLine($"Block inserted into database. Rows affected: {rowsAffected}");
				}
			}
		}


		internal void AddVoteToBlockchain(int electionId, Vote vote)
        {
            Blockchain blockchain;

            // Check if the blockchain for this election already exists
            if (!electionBlockchains.ContainsKey(electionId))
            {
                // Initialize a new blockchain for this election
                blockchain = new Blockchain();
                electionBlockchains[electionId] = blockchain;
            }
            else
            {
                // Get the existing blockchain
                blockchain = electionBlockchains[electionId];
            }

            // Create and add the new block
            string previousHash = blockchain.CurrentBlock != null ? blockchain.CurrentBlock.Hash : "0";
            Block block = new Block(previousHash, vote);
            blockchain.AddBlock(block);

            // Optionally, insert this block into your database's Block table
            InsertBlockIntoDatabase(block);
        }

		internal Voter GetVoterDetails(int voterID) {
			string connectionString = "Data Source=E-Voting System.db;Version=3;";
			string query = @"
                            SELECT Students.name, Students.email, Students.password, Students.gpa, Students.creditHours, Students.studentMajor
                            FROM Voters
                            INNER JOIN Students ON Voters.studentID_FK = Students.studentID
                            WHERE Voters.voterID = @VoterId
                            ";

			Console.WriteLine("Attempting to retrieve voter details for VoterID: " + voterID);

			using (SQLiteConnection conn = new SQLiteConnection(connectionString)) {
				try {
					conn.Open();
					Console.WriteLine("Database connection opened.");

					using (SQLiteCommand cmd = new SQLiteCommand(query, conn)) {
						cmd.Parameters.AddWithValue("@VoterId", voterID);

						using (SQLiteDataReader reader = cmd.ExecuteReader()) {
							if (reader.Read()) {
								Console.WriteLine("Voter details found. Creating Voter object.");

								string name = reader["name"].ToString();
								string email = reader["email"].ToString();
								string password = reader["password"].ToString();
								float gpa = Convert.ToSingle(reader["gpa"]);
								int creditHours = Convert.ToInt32(reader["creditHours"]);
								string studentMajor = reader["studentMajor"].ToString();

								Voter voter = new Voter(name, email, password, gpa, creditHours, studentMajor);
								return voter;
							} else {
								Console.WriteLine("No voter found with VoterID: " + voterID);
							}
						}
					}
				} catch (Exception ex) {
					Console.WriteLine("Error retrieving voter details: " + ex.Message);
				}
			}

			Console.WriteLine("Returning null - Voter details not retrieved.");
			return null; // or handle this case as appropriate
		}
	}
}

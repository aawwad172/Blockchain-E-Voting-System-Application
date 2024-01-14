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

            IncrementCandidateVote(candidateID);
            CreateVoteRecord(userID,candidateID);
            int voterID = AddVoter(userID);
            // Todo: Retireve the information of the current user depending on the user it and then
            // create the Voter object and then send it into the Vote Object

            //Voter newVoter = new Voter();
           // Vote newVote = new Vote(userID, candidateID, DateTime.Now);
			
			

        }

        public void IncrementCandidateVote(int candidateID)
        {
            string connectionString = "Data Source=E-Voting System.db;Version=3;";
            string updateQuery = "UPDATE Candidates SET totalVotes = totalVotes + 1 WHERE candidateID = @CandidateId";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(updateQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@CandidateId", candidateID);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        public int CreateVoteRecord(int voterId, int candidateId)
        {
            string connectionString = "Data Source=E-Voting System.db;Version=3;";
            string insertQuery = "INSERT INTO Votes (voterID, candidateID, timeStamp) VALUES (@VoterId, @CandidateId, @TimeStamp); SELECT last_insert_rowid();";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@VoterId", voterId);
                    cmd.Parameters.AddWithValue("@CandidateId", candidateId);
                    cmd.Parameters.AddWithValue("@TimeStamp", DateTime.UtcNow); 
                    int voteId = Convert.ToInt32(cmd.ExecuteScalar()); 
                    return voteId;
                }
            }
        }

        public int AddVoter(int studentID)
        {
            string connectionString = "Data Source=E-Voting System.db;Version=3;"; // Replace with your actual connection string
            string insertQuery = "INSERT INTO Voters (studentID_FK) VALUES (@StudentID); SELECT last_insert_rowid();";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@StudentID", studentID);
                    int voterID = Convert.ToInt32(cmd.ExecuteScalar()); // Returns the ID of the newly inserted voter
                    return voterID;
                }
            }
        }

        public void InitializeBlockchainForElection(int electionId)
        {
            Blockchain blockchain = new Blockchain(); // Creates a new blockchain with a genesis block
            electionBlockchains[electionId] = blockchain; // Store the blockchain for this specific election
        }

        internal void InsertBlockIntoDatabase(Block block)
        {
            string connectionString = "Data Source=E-Voting System.db;Version=3;";
            string insertQuery = "INSERT INTO Block (previousHash, voteID, hash) VALUES (@PreviousHash, @VoteID, @Hash)";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@PreviousHash", block.PreviousHash);
                    cmd.Parameters.AddWithValue("@VoteID", block.VoteRecord.VoteID); // Assuming VoteRecord contains the VoteID
                    cmd.Parameters.AddWithValue("@Hash", block.Hash);
                    cmd.ExecuteNonQuery();
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

    }
}

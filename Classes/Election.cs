using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blockchain_E_Voting_System_Application.Classes {
	internal class Election {
		public string electionID { get; set; }
		public DateTime startDate { get; set; }
		public DateTime endDate { get; set; }
		public Dictionary<string, Candidate> candidates;

		// Constructor
		public Election(string electionID, DateTime startDate, DateTime endDate) {
			this.electionID = electionID;
			this.startDate = startDate;
			this.endDate = endDate;
			candidates = new Dictionary<string, Candidate>();
		}

		// Method to add a candidate to the election
		public void addCandidate(Candidate candidate) {
			candidates.Add(candidate.candidateID, candidate);
		}

		// Method to retrieve information about a candidate
		public Candidate getCandidateInfo(string candidateID) {
			if (candidates.ContainsKey(candidateID)) {
				Console.WriteLine("Candidate Found Successfully!");
				return candidates[candidateID];
			} else {
				Console.WriteLine("Candidate is Not Exist!");
				return null;
			}
		}

		// Method to declare the results of the election
		public void DeclareResults() {
			// Implementation to calculate and announce the results
		}
	}
}

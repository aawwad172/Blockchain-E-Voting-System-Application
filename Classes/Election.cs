using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blockchain_E_Voting_System_Application.Classes {
	internal class Election {
		public string ElectionID { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public Dictionary<string, Candidate> candidates { get; set; }

		// Constructor
		public Election(string electionID, DateTime startDate, DateTime endDate) {
			ElectionID = electionID;
			StartDate = startDate;
			EndDate = endDate;
			candidates = new Dictionary<string, Candidate>();
		}

		// Method to add a candidate to the election
		public void addCandidate(Candidate candidate) {
			candidates[candidate.candidateID] = candidate;
		}

		// Method to retrieve information about a candidate
		public Candidate getCandidateInfo(string candidateID) {
			if (candidates.ContainsKey(candidateID)) {
				return candidates[candidateID];
			} else { return null; }
		}

		// Method to declare the results of the election
		public void DeclareResults() {
			// Implementation to calculate and announce the results
		}
	}
}

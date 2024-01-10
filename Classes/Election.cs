using System;
using System.Collections.Generic;

namespace Blockchain_E_Voting_System_Application.Classes {
	internal class Election {
		private static int nextElectionID = 1;

		// Attributes
		private int _electionID;
		public DateTime _startDate { get; set; }
		public DateTime _endDate { get; set; }
		public Dictionary<int, Candidate> Candidates { get; private set; }

		// Constructor
		public Election(DateTime startDate, DateTime endDate) {
			this.ElectionID = nextElectionID++;
			this._startDate = startDate;
			this._endDate = endDate;
			Candidates = new Dictionary<int, Candidate>();
		}

		// Setters and Getters
		public int ElectionID {
			get { return _electionID; }
			private set { _electionID = value; }
		}

		// Methods
		public void AddCandidate(Candidate candidate) {
			Candidates.Add(candidate.CandidateID, candidate);
		}

		// Method to retrieve information about a candidate
		public Candidate GetCandidateInfo(int candidateID) {
			if (Candidates.ContainsKey(candidateID)) {
				Console.WriteLine("Candidate Found Successfully!");
				return Candidates[candidateID];
			} else {
				Console.WriteLine("Candidate Not Exist!");
				return null;
			}
		}

		// Method to declare the results of the election
		public void DeclareResults() {
			// Implementation to calculate and announce the results
		}
	}
}

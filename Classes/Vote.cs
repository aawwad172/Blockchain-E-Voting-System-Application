using System;

namespace Blockchain_E_Voting_System_Application.Classes {
	internal class Vote {

		// Private attributes
		private int _voteID;
		private Voter _voter;
		private int _candidateID;
		private DateTime _timestamp;

		// Constructor
		public Vote(int voterID, Voter voter, int candidateID, DateTime timestamp) {
			_voter = voter;
			_candidateID = candidateID;
			_timestamp = timestamp;
		}

		// Getters and Setters
		public int VoteID {
			get { return _voteID; }
			set { _voteID = value; }
		}

		public Voter Voter {
			set { _voter = value; }
			get { return _voter; }
		}


		public int CandidateID {
			get { return _candidateID; }
			set { _candidateID = value; }
		}

		public DateTime Timestamp {
			get { return _timestamp; }
			set { _timestamp = value; }
		}
	}
}

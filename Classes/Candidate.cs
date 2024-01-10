using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blockchain_E_Voting_System_Application.Classes {
	internal class Candidate : Student {
		private static int nextCandidateID = 1;

		// Attributes
		private int _candidateID;
		private int _totalVotes;

		// Constructor, utilizing base class constructor for Student attributes
		public Candidate(string name, string email, float gpa, int creditHours, string major)
			: base(name, email, gpa, creditHours, major) {
			this.CandidateID = nextCandidateID++;
			this.TotalVotes = 0;
		}

		// Setters and Getters
		public int CandidateID {
			get { return _candidateID; }
			private set { _candidateID = value; }
		}

		public int TotalVotes {
			get { return _totalVotes; }
			set { _totalVotes = value; }
		}
	}
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blockchain_E_Voting_System_Application.Classes {
	internal class Candidate : Student {

		// Attributes
		private int _candidateID;
		private int _totalVotes;

		// Constructor, utilizing base class constructor for Student attributes
		public Candidate(string name, string email, string password, float gpa, int creditHours, string major)
			: base(name, email, password, gpa, creditHours, major) {
			this.TotalVotes = 0;
		}

		// Setters and Getters
		public int CandidateID {
			get { return _candidateID; }
			set { _candidateID = value; }
		}

		public int TotalVotes {
			get { return _totalVotes; }
			set { _totalVotes = value; }
		}
	}
}


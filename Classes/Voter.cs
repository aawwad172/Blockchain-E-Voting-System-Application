using System;

namespace Blockchain_E_Voting_System_Application.Classes {
	internal class Voter : Student {

		// Attributes
		private int _voterID;


		// Constructor
		public Voter(string name, string email, string password, float gpa, int creditHours, string studentMajor)
			: base(name, email, password, gpa, creditHours, studentMajor)
		{
		}

		// Setters and Getters
		public int VoterID {
			get { return _voterID; }
			set { _voterID = value; }
		}

	}
}

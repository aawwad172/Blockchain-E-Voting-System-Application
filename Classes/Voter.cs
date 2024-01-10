using System;

namespace Blockchain_E_Voting_System_Application.Classes {
	internal class Voter : Student {
		private static int nextVoterID = 1;

		// Attributes
		private int _voterID;


		// Constructor
		public Voter(string name, string email, string password, float gpa, int creditHours, string studentMajor)
			: base(name, email, password, gpa, creditHours, studentMajor)
		{
			_voterID = nextVoterID++;
		}

		// Setters and Getters
		public int VoterID {
			private set { _voterID = value; }
			get { return _voterID; }
		}

	}
}

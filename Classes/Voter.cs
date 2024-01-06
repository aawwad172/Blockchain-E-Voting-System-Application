using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blockchain_E_Voting_System_Application.Classes {
	internal class Voter : Student {
		public bool EligibilityStatus { get; }

		public Voter(string studentID, string name, string email, double gpa, int creditHours, Major studentMajor, bool eligibilityStatus)
			: base(studentID, name, email, gpa, creditHours, studentMajor) { // Call the base class constructor
			EligibilityStatus = eligibilityStatus;
		}
	}
}

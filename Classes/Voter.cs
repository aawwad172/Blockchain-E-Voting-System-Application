using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blockchain_E_Voting_System_Application.Classes {
	internal class Voter : Student {

		public Voter(string studentID, string name, string email, float gpa, int creditHours, string studentMajor)
			: base(studentID, name, email, gpa, creditHours, studentMajor) { // Call the base class constructor

		}
	}
}

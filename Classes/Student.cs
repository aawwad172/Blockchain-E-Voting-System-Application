using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blockchain_E_Voting_System_Application.Classes {
	internal class Student {
		private string studentID;
		private string name;
		string email;
		private float gpa;
		private int creditHours;
		private string studentMajor;

		public Student(string studentID, string name, String email,float gpa, int creditHours, string studentMajor) {
			StudentID = studentID;
			Name = name;
			Email = email;
			GPA = gpa;
			CreditHours = creditHours;
			StudentMajor = studentMajor;
		}

		// Property for studentID
		public string StudentID {
			get { return studentID; }
			set { studentID = value; }
		}

		// Property for name
		public string Name {
			get { return name; }
			set { name = value; }
		}

		public string Email {
			get { return email; }
			set { email = value; }

		// Property for gpa
		public float GPA {
			get { return gpa; }
			set { gpa = value; }
		}

		// Property for creditHours
		public int CreditHours {
			get { return creditHours; }
			set { creditHours = value; }
		}

		// Property for studentMajor
		public string StudentMajor {
			get { return studentMajor; }
			set { studentMajor = value; }
		}
	}
}

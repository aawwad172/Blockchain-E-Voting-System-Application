using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blockchain_E_Voting_System_Application.Classes {
	internal class Student {
		private int studentID;
		private string name;
		private float gpa;
		private int creditHours;
		private String studentMajor;

		// Property for studentID
		public int StudentID {
			get { return studentID; }
			set { studentID = value; }
		}

		// Property for name
		public string Name {
			get { return name; }
			set { name = value; }
		}

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
		public String StudentMajor {
			get { return studentMajor; }
			set { studentMajor = value; }
		}
	}
}

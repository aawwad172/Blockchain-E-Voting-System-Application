﻿using System;

namespace Blockchain_E_Voting_System_Application.Classes {
	internal class Student {

		// Attribute
		private int _studentID;
		private string _name;
		private string _email;
		private string _password;
		private float _gpa;
		private int _creditHours;
		private string _studentMajor;

		// Constructor
		public Student(string name, string email, string password, float gpa, int creditHours, string studentMajor) {
			this.Name = name;
			this.Email = email;
			this.GPA = gpa;
			this.CreditHours = creditHours;
			this.StudentMajor = studentMajor;
			this._password = password;
		}

		// Setters and Getters

		// Read-only property for _studentID
		public int StudentID {
			get { return _studentID; }
			set { _studentID = value; }
		}

		public string Name {
			get { return _name; }
			set { _name = value; }
		}

		public string Email {
			get { return _email; }
			set { _email = value; }
		}

		private string Password {
			get { return _password; }
			set { _password = value; }
		}

		public float GPA {
			get { return _gpa; }
			set { _gpa = value; }
		}

		public int CreditHours {
			get { return _creditHours; }
			set { _creditHours = value; }
		}

		public string StudentMajor {
			get { return _studentMajor; }
			set { _studentMajor = value; }
		}


		// Other Methods
		public bool verifyIdentity(string studentID) {
			/*
			 * Here is the rest of the code if the University System had an API
			 * so we can use it to check the details of the student.
			 */
			return true;
		}
	}
}

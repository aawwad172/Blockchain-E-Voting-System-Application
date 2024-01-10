using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blockchain_E_Voting_System_Application.Classes {
	internal class Admin {
		private static int nextAdminID = 1;

		private int _adminID;
		private string _name;

		// Constructor
		public Admin(string name) {
			this.AdminID = nextAdminID++;
			this.Name = name;
		}

		// Getters and Setters
		public int AdminID {
			get { return _adminID; }
			private set { _adminID = value; }
		}

		public string Name {
			get { return _name; }
			set { _name = value; }
		}
	}
}

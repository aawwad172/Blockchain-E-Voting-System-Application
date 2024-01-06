using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blockchain_E_Voting_System_Application.Classes {
	internal class Candidate: Student {
        public string candidateID { get; set; }
        public int totalVotes { get; set; }


        // Constructor
        public Candidate(string studentID, string name, string email, float gpa, int creditHours, string major, string candidateID)
            : base(studentID, name, email, gpa, creditHours, major)
        {
            this.candidateID = candidateID;
            totalVotes = 0;
        }


     
    }

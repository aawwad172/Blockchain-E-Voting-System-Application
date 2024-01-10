using Blockchain_E_Voting_System_Application.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blockchain_E_Voting_System_Application {
	public partial class MainPage : Form {
		public MainPage() {
			InitializeComponent();
		}

        private void MainPage_Load(object sender, EventArgs e)
        {
            string electionId = "Election2024";
            DateTime startDate = DateTime.Now;
            DateTime endDate = DateTime.Now.AddDays(1); // Example end date: one day from now

            // Create an instance of Election
            Election currentElection = new Election(electionId, startDate, endDate);
            


        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       
    }
}

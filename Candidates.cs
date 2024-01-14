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
	public partial class Candidates : Form {
		private int selectedElectionID;

		public Candidates(int selectedElectionID) {
			this.selectedElectionID = selectedElectionID;
		}

		public Candidates() {
			InitializeComponent();
		}

		private void Candidates_Load(object sender, EventArgs e) {

		}
	}
}

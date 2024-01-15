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
	public partial class ResultForm : Form {

		private List<Tuple<string, int, string>> _results;
		public ResultForm(List<Tuple<string, int, string>> results) {
			InitializeComponent();
			_results = results;
			LoadResults();
		}

		private void LoadResults() {
			foreach (var result in _results) {
				string major = result.Item1;
				int candidateID = result.Item2;
				string candidateName = result.Item3;

				// Create a ListViewItem or similar control to display the result
				ListViewItem item = new ListViewItem(new[] { major, candidateID.ToString(), candidateName });
				listViewResults.Items.Add(candidateName + " with id: "+ candidateID +" from " + major);  // Assuming you have a ListView named listViewResults
			}
		}


		private void ResultForm_Load(object sender, EventArgs e) {

		}
	}
}

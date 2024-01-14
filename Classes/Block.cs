using System;
using System.Security.Cryptography;
using System.Text;

namespace Blockchain_E_Voting_System_Application.Classes {
	internal class Block {

		// Attributes
		private int _blockID;
		private string _previousHash;
		private Vote _voteRecord;
		private string _hash;
		private bool _isGenesisBlock;

		public Block(string previousHash, Vote voteRecord, bool isGenesisBlock = false) {
			PreviousHash = previousHash;
			VoteRecord = voteRecord;
			IsGenesisBlock = isGenesisBlock;
			Hash = ComputeHash();
		}

		// Getters and Setters
		public int BlockID {
			get { return _blockID; }
			private set { _blockID = value; }
		}

		public string PreviousHash {
			get { return _previousHash; }
			set { _previousHash = value; }
		}

		public Vote VoteRecord {
			get { return _voteRecord; }
			set {
				_voteRecord = value;
				_hash = ComputeHash();
			}
		}

		public string Hash {
			get { return _hash; }
			private set { _hash = value; }
		}

		public bool IsGenesisBlock {
			set { _isGenesisBlock = value; }
			get { return _isGenesisBlock; }
		}


		// Methods
		private string ComputeHash() {
			using (SHA256 sha256 = SHA256.Create()) {
				StringBuilder rawData = new StringBuilder();
				rawData.Append(BlockID).Append(PreviousHash);

				if (VoteRecord != null) {
					rawData.Append(VoteRecord.VoteID).Append(VoteRecord.Voter.VoterID).Append(VoteRecord.CandidateID).Append(VoteRecord.Timestamp);
				}

				byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData.ToString()));

				StringBuilder builder = new StringBuilder();
				for (int i = 0; i < bytes.Length; i++) {
					builder.Append(bytes[i].ToString("x2"));
				}

				return builder.ToString();
			}
		}

		// Method to verify the block's hash
		public bool IsValid() {
			return Hash == ComputeHash();
		}
	}
}

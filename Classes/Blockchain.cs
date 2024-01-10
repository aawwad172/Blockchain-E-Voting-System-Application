using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blockchain_E_Voting_System_Application.Classes {
	internal class Blockchain {

		// Attributes
		public List<Block> Blocks { get; private set; }
		public Block CurrentBlock { get; private set; }


		// Constructor
		public Blockchain() {
			Blocks = new List<Block>();
			Block genesisBlock = new Block("0", null, true);
			AddBlock(genesisBlock);
		}

		// Method to add a new block to the blockchain
		public void AddBlock(Block newBlock) {
			if (Blocks.Count > 0) {
				newBlock.PreviousHash = CurrentBlock.Hash;
			}
			Blocks.Add(newBlock);
			CurrentBlock = newBlock;
		}

		// Method to verify the integrity of the blockchain
		public bool VerifyChain() {
			for (int i = 1; i < Blocks.Count; i++) {
				Block current = Blocks[i];
				Block previous = Blocks[i - 1];

				// Check if the hash of each block is correct
				if (!current.IsValid()) { return false; }

				// Check if the current block's previous hash is equal to the hash of the previous block
				if (current.PreviousHash != previous.Hash) {
					return false;
				}
			}
			return true;
		}
	}
}

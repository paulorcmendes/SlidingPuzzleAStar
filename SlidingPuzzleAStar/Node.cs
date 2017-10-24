using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlidingPuzzleAStar
{
	//Class Node
    class Node
    {
        private List<Neighbor> neighbors;
        private int[] state;
        private int expectation; //manhatan distance

        public Node(int[] state)
        {
            this.State = state;
            this.neighbors = new List<Neighbor>();
            this.expectation = 0;
        }
        public Node(int[] state, int expectation)
        {
            this.State = state;
            this.neighbors = new List<Neighbor>();
            this.Expectation = expectation;
        }
        public int Expectation {
            get
            {
                return expectation;
            }
            set
            {
                expectation = value;
            }
        }
        public int[] State
        {
            get
            {
                return this.state;
            }
            set
            {
                this.state = value;
            }
        }
        public List<Neighbor> Neighbors
        {
            get
            {
                return this.neighbors;
            }
        }
        //function just to show the current state in a fancy way
        public static string ShowPuzzle(int[] puzzle)
        {
            if (puzzle == null) return null;
            string msg = "";
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    msg += (puzzle[i * 3 + j] == 0 ? "  |" : puzzle[i * 3 + j] + " |");
                }
                msg += "\n";
            }
            return msg+"\n\n";
        }
        public override String ToString()
        {
            return ShowPuzzle(this.State);
        }
        public override bool Equals(object obj)
        {
            return State.SequenceEqual(((Node)obj).State);
        }
    }
}

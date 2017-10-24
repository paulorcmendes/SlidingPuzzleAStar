using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlidingPuzzleAStar
{
    //neighbor represents a node and a distance.
    //I use this class in order to not use two different lists, one for nodes that are neighbors and the costs.
    //I use one single list: of neighbors, instead.
    class Neighbor
    {
        private Node node;
        private int cost;

        public Neighbor(Node node, int cost)
        {
            Node = node;
            Cost = cost;
        }

        public Node Node
        {
            get
            {
                return this.node;
            }
            set
            {
                this.node = value;
            }
     
        }

        public int Cost
        {
            get
            {
                return this.cost;
            }
            set
            {
                this.cost = value;
            }
        }
    }
}

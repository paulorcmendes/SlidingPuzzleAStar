using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlidingPuzzleAStar
{
    //I am using a category of search because I also implemented the problem of Romanian cities.
    public enum CATEGORY{BREADTH_FIRST, UNIFORM_COST, A_STAR}
    class Path : Neighbor, IComparable<Path>
    {
        private List<Node> pathToMe; //all the path to reach me
        private CATEGORY myCategory; //category of search
        public Path(Node node, int cost) : base(node, cost)
        {
            pathToMe = new List<Node>();
            MyCategory = CATEGORY.BREADTH_FIRST;
        }
        public Path(Node node, int cost, CATEGORY myCategory) : base(node, cost)
        {
            pathToMe = new List<Node>();
            MyCategory = myCategory;
        }

        public List<Node> PathToMe 
        {
            get
            {
                return pathToMe;
            }
            set
            {
                pathToMe = value;
            }
        }
        public CATEGORY MyCategory
        {
            get
            {
                return myCategory;
            }
            set
            {
                myCategory = value;
            }
        }

        private string PathToString(List<Node> path)
        {
            string msg = "";
            foreach (Node node in path)
            {
                msg += node;
            }
            return msg;
        }

        public override string ToString()
        {
            return PathToString(PathToMe) + " with cost: " + base.Cost;
        }
        //every comparable class in c# implements a method called CompareTo. It is used to sort a list, for instance.
        //I override it depending on the algorithm that I am using.
        public int CompareTo(Path other)
        {   //if i am using AStar, I take the expectation in consideration.
            if(myCategory == CATEGORY.A_STAR)
            {
                int v1 = GetCostWithExpectation();
                int v2 = other.GetCostWithExpectation();

                return v1.CompareTo(v2);
            }         
            return Cost.CompareTo(other.Cost);
        }
        public int GetCostWithExpectation()
        {
            return Cost + Node.Expectation;
        }
        public override bool Equals(object obj)
        {
            return Node.Equals(((Path)obj).Node);
        }
    }
}

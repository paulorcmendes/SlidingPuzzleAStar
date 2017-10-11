using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlidingPuzzleAStar
{
    class GraphSearch
    {
        public static Path AStarSearch(Node initial, Node goal)
        {
            bool found;
            Path initialState = new Path(initial, 0, CATEGORY.A_STAR);
            Node goalState = goal;

            //defining initial and final states
            List<Path> border = new List<Path>();
            List<Node> explored = new List<Node>();

            //adding initial state to the border
            border.Add(initialState);
            found = false;
            Path currentNode = null; //current node being explored
            while (!found)
            {
                if (border.Count == 0)
                {
                    //if there are no nodes in the border, we haven't found
                    break;
                }

                //removing the node that is currently being explored from the border
                currentNode = border[0];
                border.RemoveAt(0);

                if (currentNode.Node.Equals(goalState))
                {
                    //adding the goal node to the path
                    currentNode.PathToMe.Add(currentNode.Node);
                    found = true;
                    break;
                }

                //adding node to the explored set
                explored.Add(currentNode.Node);
                AddNeighbors(currentNode.Node, Array.IndexOf(currentNode.Node.State, 0), goalState);
                foreach (Neighbor neighbor in currentNode.Node.Neighbors)
                {
                    if (!explored.Contains(neighbor.Node))
                    {
                        //new path created using the current node reached and the cost to reach it
                        Path newPath = new Path(neighbor.Node, currentNode.Cost + neighbor.Cost, CATEGORY.A_STAR);

                        //saying that the path to me is the path to my father plus my father itself
                        newPath.PathToMe = currentNode.PathToMe.ToList();
                        newPath.PathToMe.Add(currentNode.Node);


                        border.Add(newPath);
                        border.Sort();
                        //foreach (Path p in border)
                        //{
                        //    Console.Write(p.Node + " c:" + p.Cost + " e:" + p.Node.Expectation + "s: " + (p.Cost + p.Node.Expectation) + "; ");
                        //}
                        //Console.WriteLine();
                        //Console.ReadKey();
                    }
                }
            }
            if (found) return currentNode;
            return null;
        }
        private static void AddNeighbors(Node node, int zPos, Node goalState) {
            int[] newState;
            if (zPos / 3 > 0) {
                newState = North(node.State, zPos);
                node.Neighbors.Add(new Neighbor(new Node(newState, Program.GetExpectation(newState, goalState.State)), 1));
            }
            if (zPos / 3 < 2)
            {
                newState = South(node.State, zPos);
                node.Neighbors.Add(new Neighbor(new Node(newState, Program.GetExpectation(newState, goalState.State)), 1));
            }
            if (zPos % 3 < 2)
            {
                newState = East(node.State, zPos);
                node.Neighbors.Add(new Neighbor(new Node(newState, Program.GetExpectation(newState, goalState.State)), 1));
            }
            if (zPos % 3 > 0)
            {
                newState = West(node.State, zPos);
                node.Neighbors.Add(new Neighbor(new Node(newState, Program.GetExpectation(newState, goalState.State)), 1));
            }
        }
        
        public static int[] North(int[] state, int zPos) {
            int[] newState = null;
            if ((zPos/3) > 0) {
                newState = state.ToArray();
                newState[zPos] = state[zPos - 3];
                newState[zPos - 3] = state[zPos];
            }
            return newState;
        }
        public static int[] South(int[] state, int zPos)
        {
            int[] newState = null;
            if ((zPos / 3) < 2)
            {
                newState = state.ToArray();
                newState[zPos] = state[zPos + 3];
                newState[zPos + 3] = state[zPos];
            }
            return newState;
        }
        public static int[] East(int[] state, int zPos)
        {
            int[] newState = null;
            if ((zPos % 3) < 2)
            {
                newState = state.ToArray();
                newState[zPos] = state[zPos + 1];
                newState[zPos + 1] = state[zPos];
            }
            return newState;
        }
        public static int[] West(int[] state, int zPos)
        {
            int[] newState = null;
            if ((zPos % 3) > 0)
            {
                newState = state.ToArray();
                newState[zPos] = state[zPos - 1];
                newState[zPos - 1] = state[zPos];
            }
            return newState;
        }
    }
}

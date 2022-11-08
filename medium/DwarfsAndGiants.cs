/* Author: Michał Hołowaty
 * Original Upload Date: 08/11/2022
 * Assignment Link:https://www.codingame.com/ide/puzzle/dwarfs-standing-on-the-shoulders-of-giants
 * Example Input:
9
7 2
8 9
1 6
6 9
1 7
1 2
3 9
2 3
6 3
 * */
class Graph
{
    private Dictionary<int, List<int>> _nodeAdjList { get; set; }
    private Dictionary<int, int> _nodeMaxDepth { get; set; }
    public Graph() {
        _nodeAdjList = new();
        _nodeMaxDepth = new();
    }
    public void AddConnection(int start, int end) {
        if (!_nodeAdjList.ContainsKey(start)) _nodeAdjList.Add(start, new());
        if (!_nodeAdjList.ContainsKey(end)) _nodeAdjList.Add(end, new());
        _nodeAdjList[start].Add(end);
    }
    private int TraverseGraph(int currentNode, int currentDepth) {
        int Max = ++currentDepth;
        foreach (var Node in _nodeAdjList[currentNode]) {
            Max = Math.Max(TraverseGraph(Node, currentDepth), Max);
        }
        return Max;
    }
    internal string FindLongestPath() {
        foreach (var node in _nodeAdjList) {
            _nodeMaxDepth.Add(node.Key, TraverseGraph(node.Key, 0));
        }
        var MaxPath = _nodeMaxDepth.MaxBy(x => x.Value).Value;
        return MaxPath.ToString();
    }
}
class Solution
{
    static Graph ReadInput() {
        Graph Hawat = new();
        int N = int.Parse(Console.ReadLine()); // the number of relationships of influence
        for (int i = 0; i < N; i++) {
            string[] Inputs = Console.ReadLine().Split(' ');
            int X = int.Parse(Inputs[0]); // a relationship of influence between two people (x influences y)
            int Y = int.Parse(Inputs[1]);
            Hawat.AddConnection(X, Y);
        }
        return Hawat;
    }
    static string FindSolution(Graph input) {
        return input.FindLongestPath();
    }
    static void Main(string[] args) {
        Console.WriteLine(FindSolution(ReadInput()));
    }
}
/*
 *     public void TypeOut() {
        foreach (var Node in _nodeAdjList) {
            Console.WriteLine($"{Node.Key}      {string.Join(' ', Node.Value)}");
        }
    }*/
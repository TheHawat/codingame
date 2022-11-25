/* Author: Michał Hołowaty
 * Original Upload Date: 25/11/2022
 * Assignment Link:https://www.codingame.com/training/easy/character-replacement-problem
 * Example Input:
qw ws aq za sd
6
zzzzzz
aaaaaa
qqqqqq
wwwwww
ssssss
dddddd
 * */
class Graph
{
    private Dictionary<char, List<char>> _nodes { get; set; }
    private Dictionary<char, char> _translations { get; set; }
    public Graph() {
        _nodes = new();
        _translations = new();
    }
    public void AddNodes(string input) {
        if (input[0] == input[1]) return;
        if (!_nodes.ContainsKey(input[0])) _nodes.Add(input[0], new List<char>());
        if (!_nodes.ContainsKey(input[1])) _nodes.Add(input[1], new List<char>());
        _nodes[input[0]].Add(input[1]);
    }
    public bool SolveTranslations() {
        foreach (var node in _nodes) {
            if (node.Value.Count > 1) return false;
            List<char> Visited = new();
            if (!FindTranslation(node.Key, ref Visited)) return false;
            _translations.Add(node.Key, Visited[^1]); 
        }
        return true;
    }
    private bool FindTranslation(char key, ref List<char> visited) {
        if (visited.Contains(key)) return false;
        visited.Add(key);
        if (_nodes[key].Count == 0) return true;
        return FindTranslation(_nodes[key][0], ref visited); 
    }
    public string TranslateString(string input) {
        foreach (var translation in _translations) {
            input = input.Replace(translation.Key, translation.Value);
        }
        return input;
    }
}
class Solution
{
    static void ProcessInput() {
        string[] Code = Console.ReadLine().Split(' ');
        Graph Hawat = new();
        foreach (var code in Code) {
            Hawat.AddNodes(code);
        }
        if (!Hawat.SolveTranslations()) {
            Console.WriteLine("ERROR");
            return;
        }
        int N = int.Parse(Console.ReadLine());
        for (int i = 0; i < N; i++) {
            Console.WriteLine(Hawat.TranslateString(Console.ReadLine()));
        }
    }
    static void Main(string[] args) {
        ProcessInput();
    }
}

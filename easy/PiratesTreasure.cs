/* Author: Michał Hołowaty
 * Original Upload Date: 08/11/2022
 * Assignment Link:https://www.codingame.com/ide/puzzle/pirates-treasure
 * Example Input:
5
7
0 0 1 1 0
0 1 0 0 1
0 1 1 1 0
0 1 0 1 1
1 1 1 1 0
0 1 0 0 1
1 0 0 0 0
 * */
class Maze
{
    private List<string> _mazeImage { get; set; }
    private readonly int[] _possibilities = { -1, 0, 1 };
    public Maze() {
        _mazeImage = new();
    }
    public void AddRow(string row) {
        _mazeImage.Add(row);
    }
    private bool CheckCell(int x, int y) {
        if (_mazeImage[x][y] == '1') return false;
        int Counter = 0;
        foreach (int TX in _possibilities) {
            foreach (int TY in _possibilities) {
                int NextX = x + TX, NextY = y + TY;
                Counter += (TX == 0 && TY == 0) ? 0 : GetCounter(NextX, NextY);
            }
        }
        return Counter == 8;
    }
    private int GetCounter(int x, int y) {
        if (!InRange(x, y)) return 1;
        if (_mazeImage[x][y] == '1') return 1;
        return 0;
    }
    private bool InRange(int nextX, int nextY) {
        if (nextX >= 0 && nextX < _mazeImage.Count &&
            nextY >= 0 && nextY < _mazeImage[nextX].Length) {
            return true;
        }
        return false;
    }
    public (int X, int Y) FindTreasure() {
        for (int i = 0; i < _mazeImage.Count; i++) {
            for (int j = 0; j < _mazeImage[i].Length; j++) {
                if (CheckCell(i, j)) return (i, j);
            }
        }
        return (-1, -1);
    }
}
class Solution
{
    static Maze ReadInput() {
        Console.ReadLine();
        int H = int.Parse(Console.ReadLine());
        Maze Hawat = new();
        for (int i = 0; i < H; i++) {
            string Line = Console.ReadLine().Replace(" ", "");
            Hawat.AddRow(Line);
        }
        return Hawat;
    }
    static string FindSolution(Maze input) {
        (int X, int Y) Result = input.FindTreasure();
        return $"{Result.Y} {Result.X}";
    }
    static void Main(string[] args) {
        Console.WriteLine(FindSolution(ReadInput()));
    }
}
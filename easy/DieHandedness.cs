/* Author: Michał Hołowaty
 * Original Upload Date: 09/11/2022
 * Assignment Link:https://www.codingame.com/ide/puzzle/die-handedness
 * Example Input:
 3
2156
 4
 * */
class Dice
{
    List<int> _s { get; set; }
    List<(int[] Ring, int Up, int Down)> _cycles { get; set; }
    public Dice(List<int> diceDefinition) {
        _s = diceDefinition;
        _cycles = new();
        InitialiseCycles();
    }
    private void InitialiseCycles() {
        _cycles.Clear();
        _cycles.Add((new[] { _s[1], _s[2], _s[3], _s[4] }, _s[5], _s[0]));
        _cycles.Add((new[] { _s[0], _s[4], _s[5], _s[2] }, _s[3], _s[1]));
        _cycles.Add((new[] { _s[0], _s[3], _s[5], _s[1] }, _s[2], _s[4]));
    }
    public string CheckDice() {
        if (!(_s[0] + _s[5] == 7 && _s[1] + _s[3] == 7 && _s[2] + _s[4] == 7)) return "degenerate";
        foreach (var Cycle in _cycles) {
            if (CheckCycle(Cycle)) return "left-handed";
        }
        return "right-handed";
    }
    private bool CheckCycle((int[] Ring, int Up, int Down) cycle) {
        int One = Array.IndexOf(cycle.Ring, 1);
        if (One == -1) return false;
        if (((One == 3 ? cycle.Ring[0] : cycle.Ring[One + 1]) == 2 && cycle.Up == 3) ||
            ((One == 0 ? cycle.Ring[3] : cycle.Ring[One - 1]) == 2 && cycle.Down == 3)) return true;
        return false;
    }
}
class Solution
{
    static Dice ReadInput() {
        List<int> Sides = new();
        for (int i = 0; i < 3; i++) {
            string Line = Console.ReadLine();
            foreach (char c in Line) {
                if (c != ' ') Sides.Add((int)c - 48);
            }
        }
        return new Dice(Sides);
    }
    static void Main(string[] args) {
        Console.WriteLine(ReadInput().CheckDice());
    }
}

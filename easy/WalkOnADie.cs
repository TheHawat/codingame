/* Author: Michał Hołowaty
 * Original Upload Date: 09/12/2022
 * Assignment Link:https://www.codingame.com/ide/puzzle/walk-on-a-die
 * Example Input:
 4
2156
 3
UUURRLDDDLLU
*/

using System;
using System.Collections.Generic;
class Dice
{
    private readonly Dictionary<char, char[]> _nodes;
    private char _currentNode;
    public char CurrentNode => _currentNode;
    private char _previousNode;
    public Dice(List<string> input) {
        _nodes = ProcessInput(input);
        _currentNode = input[1][1];
        _previousNode = input[2][1];
    }
    private static Dictionary<char, char[]> ProcessInput(List<string> input) {
        Dictionary<char, char[]> TempNodes = new() {
            { input[0][1], new char[] { input[1][3], input[1][2], input[1][1], input[1][0] } },
            { input[1][0], new char[] { input[0][1], input[1][1], input[2][1], input[1][3] } },
            { input[1][1], new char[] { input[0][1], input[1][2], input[2][1], input[1][0] } },
            { input[1][2], new char[] { input[0][1], input[1][3], input[2][1], input[1][1] } },
            { input[1][3], new char[] { input[0][1], input[1][0], input[2][1], input[1][2] } },
            { input[2][1], new char[] { input[1][1], input[1][2], input[1][3], input[1][0] } }
        };
        return TempNodes;
    }
    private char NextNode(char move) {
        if (move == 'D') return _previousNode;
        int NextIndex = Array.IndexOf(_nodes[_currentNode], _previousNode);
        if (move == 'L') NextIndex = ChangeTick(NextIndex, 1);
        if (move == 'R') NextIndex = ChangeTick(NextIndex, -1);
        if (move == 'U') {
            NextIndex = ChangeTick(NextIndex, -1);
            NextIndex = ChangeTick(NextIndex, -1);
        }
        return _nodes[_currentNode][NextIndex];
    }
    private static int ChangeTick(int index, int direction) {
        int Result = index + direction;
        if (Result < 0) return 3;
        if (Result > 3) return 0;
        return Result;
    }
    public void ProcessMove(char move) {
        char TempNode = NextNode(move);
        _previousNode = _currentNode; 
        _currentNode = TempNode;
    }
}
class Solution
{
    static (Dice, string) ReadInput() {
        List<string> Input = new();
        for (int i = 0; i < 3; i++) {
            Input.Add(Console.ReadLine());
        }
        string Commands = Console.ReadLine();
        return (new Dice(Input), Commands);
    }
    static string ProcessAssignment() {
        (Dice Hawat, string Commands) = ReadInput();
        foreach (char c in Commands) {
            Hawat.ProcessMove(c);
        }
        return Hawat.CurrentNode.ToString();
    }
    static void Main(string[] args) {
        Console.WriteLine(ProcessAssignment());
    }
}
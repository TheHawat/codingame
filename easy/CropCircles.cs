/* Author: Michał Hołowaty
 * Original Upload Date: 07/11/2022
 * Assignment Link:https://www.codingame.com/ide/puzzle/crop-circles
 * Example Input:
je9 ju9 em7 om7 PLANTMOWjm21
*/
using System;
class Crops
{
    private bool[,] _cropField { get; set; }
    private int _height { get; set; } = 25;
    private int _width { get; set; } = 19;
    public Crops() {
        _cropField = new bool[_height, _width];
        InitialiseSeeds();
    }
    private void InitialiseSeeds() {
        for (int i = 0; i < _height; i++) {
            for (int j = 0; j < _width; j++) {
                _cropField[i, j] = true;
            }
        }
    }
    public void TypeOut() {
        for (int i = 0; i < _height; i++) {
            string line = "";
            for (int j = 0; j < _width; j++) {
                line += _cropField[i, j] ? "{}" : "  ";
            }
            Console.WriteLine(line);
        }
    }
    private bool Flop(int mode, int x, int y) {
        if (mode == 0) return false;
        if (mode == 2) return true;
        return !_cropField[x, y];
    }
    private void DoTheWork(int mode, int x, int y, double r) {
        double R2 = r * r;
        for (int i = Convert.ToInt32(-r); i < r; i++) {
            for (int j = Convert.ToInt32(-r); j < r; j++) {
                int NextX = x + i, NextY = y + j;
                if (InRange(NextX, NextY) && (i * i) + (j * j) < R2) {
                    _cropField[NextX, NextY] = Flop(mode, NextX, NextY);
                }
            }
        }
    }
    private bool InRange(int nextX, int nextY) {
        if (nextX >= 0 && nextY >= 0 && nextX < _height && nextY < _width) return true;
        return false;
    }

    public void ProcessInstruction(string instruction) {
        int Mode = ChoseMode(ref instruction);
        int X = Convert.ToInt32(instruction[1]) - 97;
        int Y = Convert.ToInt32(instruction[0]) - 97;
        instruction = instruction.Substring(2);
        double R = Convert.ToDouble(instruction) / 2;
        DoTheWork(Mode, X, Y, R);
    }
    private int ChoseMode(ref string instruction) {
        if (instruction.Contains("PLANTMOW")) {
            instruction = instruction.Replace("PLANTMOW", "");
            return 1;
        }
        if (instruction.Contains("PLANT")) {
            instruction = instruction.Replace("PLANT", "");
            return 2;
        }
        return 0;
    }
}
class Solution
{
    static Crops ReadAndProcessInput() {
        string[] SeparateInstructions = Console.ReadLine().Split(' ');
        Crops Hawat = new();
        foreach (string Instruction in SeparateInstructions) {
            Hawat.ProcessInstruction(Instruction);
        }
        return Hawat;
    }
    static void Main(string[] args) {
        ReadAndProcessInput().TypeOut();
    }
}
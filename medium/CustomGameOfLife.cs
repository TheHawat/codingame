/* Author: Michał Hołowaty
 * Original Upload Date: 26/10/2022
 * Assignment Link:https://www.codingame.com/ide/puzzle/custom-game-of-life
 * Example Input:
20 20 15
101110010
011011000
OOO.OO.O.O..OOO..OOO
.O.O..OOOOOO.OO.O.O.
OO.OOO.O..OOO.O..O..
..OOO....OO..OOO....
OOO..O..OO.O...OOOO.
OOOOO...OO.OO.OOOOOO
OO.O.........OO.O.O.
O..OOOO.O.OO.O.OOO..
O..O...O.OO...OOOOOO
...OOOOOO.OO...O.OO.
...O...OOOOO...O.O..
...OO...OO...OO..OO.
....O..OOO...OOOO.O.
..OO...OO.OOOO.....O
OOOO.OOOO.O.OO......
O..OO.O..OOO...OOO..
O.O.O..OOO..OO.O.O..
OOOOO.O..O..OO..O...
O...OOOO.O..O...O...
.O...O....OOOOO...O.
 * */
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
class GameOfLife
{
    private readonly (int DX, int DY)[] _modifier = { (1, 0), (-1, 0), (0, 1), (0, -1), (1, -1), (-1, 1), (-1, -1), (1, 1) };
    private List<bool[]> _image { get; set; }
    private List<int> _deathRuleSet { get; set; }
    private List<int> _lifeRuleSet { get; set; }
    public GameOfLife() {
        _image = new List<bool[]>();
        _deathRuleSet = new List<int>();
        _lifeRuleSet = new List<int>();
    }
    public GameOfLife(string death, string life) {
        List<int> DeathList = new();
        List<int> LifeList = new();
        for (int i = 0; i < 9; i++) {
            if (death[i] == '1') DeathList.Add(i);
            if (life[i] == '1') LifeList.Add(i);
        }
        _deathRuleSet = DeathList;
        _lifeRuleSet = LifeList;
        _image = new List<bool[]>();
    }
    public void AddLine(bool[] input) {
        _image.Add(input);
    }
    static private bool InBounds(int index, List<bool[]> height) {
        return (index >= 0) && (index < height.Count);
    }
    static private bool InBounds(int index, bool[] width) {
        return (index >= 0) && (index < width.Length);
    }
    private int CountSurrounding(int x, int y) {
        int Result = 0;
        foreach (var (DX, DY) in _modifier) {
            int NextX = x + DX, NextY = y + DY;
            bool CellExits = InBounds(NextX, _image) && InBounds(NextY, _image[0]);
            if (CellExits) Result += _image[NextX][NextY] ? 1 : 0;
        }
        return Result;
    }
    public void ProgressTurn() {
        List<bool[]> ImageClone = new();
        _image.ForEach(x => ImageClone.Add((bool[])x.Clone()));
        for (int i = 0; i < _image.Count; i++) {
            for (int j = 0; j < _image[i].Length; j++) {
                int Counter = CountSurrounding(i, j);
                ImageClone[i][j] = ProcessValue(Counter, _image[i][j]);
            }
        }
        _image = ImageClone;
    }
    private bool ProcessValue(int counter, bool value) {
        if (value && _deathRuleSet.Contains(counter)) return true;
        if (value) return false;
        if (!value && _lifeRuleSet.Contains(counter)) return true;
        return false;
    }
    internal void TypeOut() {
        for (int i = 0; i < _image.Count; i++) {
            for (int j = 0; j < _image[i].Length; j++) {
                Console.Write(_image[i][j] ? 'O' : '.');
            }
            Console.WriteLine();
        }
    }
}
class Solution
{
    static (GameOfLife, int) ReadInput() {
        string[] Inputs = Console.ReadLine().Split(' ');
        int Height = int.Parse(Inputs[0]);
        string DeathRuleSet = Console.ReadLine();
        string LifeRuleSet = Console.ReadLine();
        GameOfLife Hawat = new(DeathRuleSet, LifeRuleSet);
        for (int i = 0; i < Height; i++) {
            bool[] Line = Array.ConvertAll(Console.ReadLine().ToCharArray(), x => x == 'O');
            Hawat.AddLine(Line);
        }
        return (Hawat, int.Parse(Inputs[2]));
    }
    static void Main() {
        (GameOfLife Hawat, int N) = ReadInput();
        while (N > 0) {
            N--;
            Hawat.ProgressTurn();
        }
        Hawat.TypeOut();
    }
}
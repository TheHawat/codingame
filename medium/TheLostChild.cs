/* Author: Michał Hołowaty
 * Original Upload Date: 06/11/2022
 * Assignment Link:https://www.codingame.com/ide/puzzle/the-lost-child-episode-1
 * Example Input:
##########
#...#C...#
#...##...#
###.#..###
#.##M#...#
#.....#..#
#.....#..#
#.....#..#
#........#
##########
 * */
using System;
class Maze
{
    private int[,] _image { get; set; }
    private bool[,] _initialVisited { get; set; }
    private (int X, int Y) _startingPosition { get; set; }
    private (int X, int Y) _endingPosition { get; set; }
    private readonly (int DX, int DY)[] _modifier = { (1, 0), (-1, 0), (0, 1), (0, -1) };
    public Maze(int w, int h) {
        _image = new int[h, w];
        _initialVisited = new bool[h, w];
    }
    public void AddRow(string line, int i) {
        for (int j = 0; j < _image.GetLength(1); j++) {
            ProcessChar(line[j], i, j);
        }
    }
    private void ProcessChar(char c, int i, int j) {
        _image[i, j] = c == '.' || c == 'C' || c == 'M' ? 0 : -1;
        _initialVisited[i, j] = c == '#' ? true : false;
        if (c == 'C') _startingPosition = (i, j);
        if (c == 'M') _endingPosition = (i, j);
    }
    private (int X, int Y) NextCoordinates(int modifierIndex, int x, int y) {
        int NextX = _modifier[modifierIndex].DX + x, NextY = _modifier[modifierIndex].DY + y;
        return (NextX, NextY);
    }
    private void Move(bool[,] visited, int score, int x, int y) {
        if (!(_image[x, y] > score || _image[x, y] == 0)) return;
        bool[,] NewVisited = (bool[,])visited.Clone();
        NewVisited[x, y] = true;
        _image[x, y] = score;
        for (int i = 0; i < _modifier.Length; i++) {
            (int NextX, int NextY) = NextCoordinates(i, x, y);
            if (InRange(NextX, NextY) && !visited[NextX, NextY]) Move(NewVisited, score + 1, NextX, NextY);
        }
    }
    private bool InRange(int nextX, int nextY) {
        if (nextX >= 0 && nextY >= 0 && nextX < 10 && nextY < 10) return true;
        return false;
    }
    public void SolveMaze() {
        Move(_initialVisited, 0, _startingPosition.X, _startingPosition.Y);
        TypeOut();
    }
    private void TypeOut() {
        Console.WriteLine($"{_image[_endingPosition.X, _endingPosition.Y] * 10}km");
    }
    class Solution
    {
        static Maze ReadInput() {
            int W = 10;
            int H = 10;
            Maze Hawat = new Maze(W, H);
            for (int i = 0; i < H; i++) {
                Hawat.AddRow(Console.ReadLine(), i);
            }
            return Hawat;
        }
        static void Main(string[] args) {
            ReadInput().SolveMaze();
        }
    }
}
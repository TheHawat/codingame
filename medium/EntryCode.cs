/* Author: Michał Hołowaty
 * Original Upload Date: 07/12/2022
 * Assignment Link:https://www.codingame.com/ide/puzzle/entry-code
 * Example Input:
9
3
 * */


using System;
using System.Collections.Generic;
class CodeBreaker
{
    private int _availableDigits;
    private int _codeLength;
    private Queue<string> _numsToInsert;
    private string _bestCode;

    public CodeBreaker(int x, int n) {
        _availableDigits = x;
        _codeLength = n;
        _numsToInsert = new();
        _bestCode = "";
    }
    internal string SolvesCode() {
        InitialiseQueue();
        ProcessQueue();
        DoTheMagicTrick();
        return _bestCode;
    }
    private void DoTheMagicTrick() {
        _bestCode = _bestCode[..^_codeLength];
        _bestCode = _bestCode.Insert((_bestCode.Length - _codeLength), (_availableDigits - 1).ToString());
    }
    private void ProcessQueue() {
        while (_numsToInsert.Count > 0) {
            string Number = _numsToInsert.Dequeue();
            if (_bestCode.Contains(Number)) continue;
            AddToCode(Number);
        }
    }
    private void AddToCode(string number) {
        for (int i = 0; i < _codeLength - 1; i++) {
            string End = _bestCode[^(_codeLength - i - 1)..^0];
            string Start = number[0..^(i + 1)];
            if (End == Start) {
                _bestCode += number[(_codeLength - i - 1)..];
                return;
            }
        }
        _bestCode += number;
    }
    private void InitialiseQueue() {
        string CurrentWord = new('0', _codeLength);
        _bestCode = CurrentWord;
        string LastWord = new((_availableDigits - 1).ToString()[0], _codeLength);
        while (CurrentWord != LastWord) {
            _numsToInsert.Enqueue(CurrentWord);
            CurrentWord = UpTick(CurrentWord);
        }
        _numsToInsert.Enqueue(LastWord);
    }
    private string UpTick(string currentWord) {
        if (currentWord[^1] == (_availableDigits - 1).ToString()[0]) return (UpTick(currentWord[0..^1]) + '0');
        return (currentWord[0..^1]) + (char)(currentWord[^1] + 1);
    }
}

class Solution
{
    private static CodeBreaker ReadInput() {
        int X = int.Parse(Console.ReadLine());
        int N = int.Parse(Console.ReadLine());
        CodeBreaker Hawat = new(X, N);
        return Hawat;
    }
    static void Main(string[] args) {
        CodeBreaker Hawat = ReadInput();
        Console.WriteLine(Hawat.SolvesCode());
    }
}
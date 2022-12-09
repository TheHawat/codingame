/* Author: Michał Hołowaty
 * Original Upload Date: 09/12/2022
 * Assignment Link:https://www.codingame.com/ide/puzzle/the-gift
 * Example Input:
3
10
5
10
5
*/

using System;
using System.Linq;
using System.Collections.Generic;
class BudgetList
{
    private List<int> _payers;
    private int _alreadyPaid;
    private int _budget;
    public int Budget { private get => _budget; set => _budget = value; }
    public BudgetList() {
        _budget = 0;
        _alreadyPaid = 0;
        _payers = new();
    }
    internal void AddPayer(int v) {
        _payers.Add(v);
    }
    public string FindSolution() {
        if (_payers.Sum(x => x) < _budget) return "IMPOSSIBLE";
        List<int> Result = ProcessBudgets();
        Result = Result.OrderBy(x => x).ToList();
        string TransformedResult = "";
        foreach (int v in Result) {
            TransformedResult += v;
            TransformedResult += "\n";
        }
        return TransformedResult;
    }
    private List<int> ProcessBudgets() {
        List<int> Result = new();
        _payers = _payers.OrderBy(x => x).ToList();
        while (KnockSmallFish(ref Result)) ;
        ShaveEveryone(ref Result);
        return Result;
    }
    private void ShaveEveryone(ref List<int> result) {
        int EqualShare = _budget / _payers.Count;
        _budget -= EqualShare * _payers.Count;
        for (int i = 0; i < _payers.Count; i++) {
            if (_budget-- > 0) result.Add(EqualShare + 1 + _alreadyPaid);
            else result.Add(EqualShare + _alreadyPaid);
        }
    }
    private bool KnockSmallFish(ref List<int> result) {
        int Poorest = _payers[0];
        if (Poorest * _payers.Count < _budget) {
            _alreadyPaid += Poorest;
            _budget -= Poorest * _payers.Count;
            for (int i = 0; i < _payers.Count; i++) {
                _payers[i] -= Poorest;
            }
            while (_payers[0] == 0) {
                _payers.RemoveAt(0);
                result.Add(_alreadyPaid);
            }
            return true;
        }
        return false;
    }
}
class Solution
{
    static BudgetList ReadInput() {
        BudgetList Hawat = new();
        int N = int.Parse(Console.ReadLine());
        Hawat.Budget = int.Parse(Console.ReadLine());
        for (int i = 0; i < N; i++) {
            Hawat.AddPayer(int.Parse(Console.ReadLine()));
        }
        return Hawat;
    }
    static void Main(string[] args) {
        Console.WriteLine(ReadInput().FindSolution());
    }
}
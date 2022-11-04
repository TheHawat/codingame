/* Author: Michał Hołowaty
 * Original Upload Date: 04/11/2022
 * Assignment Link:https://www.codingame.com/ide/puzzle/conway-sequence
 * Example Input:
33
25
 * */
class Solution
{
    static void AddPair(ref int count, ref int number, ref List<int> result) {
        result.Add(count);
        result.Add(number);
        count = 0;
    }
    static List<int> NextLine(List<int> input) {
        List<int> Result = new();
        int CurrentCount = 0, CurrentNumber = input[0];
        for (int i = 0; i < input.Count; i++) {
            if (CurrentNumber != input[i]) {
                AddPair(ref CurrentCount, ref CurrentNumber, ref Result);
                CurrentNumber = input[i];
            }
            CurrentCount++;
        }
        AddPair(ref CurrentCount, ref CurrentNumber, ref Result);
        return Result;
    }
    static string ProcessInput() {
        List<List<int>> Sequence = new();
        int R = int.Parse(Console.ReadLine());
        Sequence.Add(new List<int> { R });
        int L = int.Parse(Console.ReadLine());
        int i = 0;
        while (i < L) {
            Sequence.Add(NextLine(Sequence[i]));
            i++;
        }
        return String.Join(" ", Sequence[L - 1]);
    }
    static void Main(string[] args) {
        Console.WriteLine(ProcessInput());
    }
}
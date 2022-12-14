/* Author: Michał Hołowaty
 * Original Upload Date: 02/11/2022
 * Assignment Link:https://www.codingame.com/ide/puzzle/1d-bush-fire
 * Example Input:
39
ff
ff.
fffff
ff.ffff
.f..f.f.f
f..ffffff
.ff.f.f...f
....f..fffffff...f
..f.fff..ff.f.f.f...
.ffff.f.ffff..f...f.
f.f.f.f..ffffff.f...f.f
f.ffff..f..f.ff.ff.fffff..
...fff....f.ff..f...fffff.
fff.f.ff.fffffff.f.ffff.ff.fff
ffffff...ff.f.fff.ff.fff.f.f.ffffff..
fffff.fff.ffffffff..fffffff.ffffffffffffffff
f.fffff..f....ffff...f..f.fff....f..fff.f.f.f
.fffff.ff.fffff.ffff.ff.f..ff.fffff.ff.fffffffff
..fffffff.ffffffff.fffffffffffff..fffffffffffff.f
.f.f..ff..f.ffff.f..f.fff.ffff...f..f.f...f.ff.ff
....f.f....f.ff.f..ff..fff..fff.ffff...ff..f...fff.
.ff..fff...ff.f...f.f..f....f.ff.f.f.fff..fff.ff..f
fff.ffff..fffffffffffffff.fffffffff.f...f.fffff.f..f.f..f
f.ff.f.ff.......f..ff.fff..ff...fff.fff..ffff.ff...ff...f
fff.f.ff..f.f..f.ffffffffff.ff..f...f..fffff..f...ffffff..fff
..fffff.ffff.ff..fffff.f.f.f.fff.ff.ffffffff.ff.ffffffff....f.f
f.f...fff.f.ffff.ffff..f..f..f..f.....f.f....fffff.f..f.ff..f.fffff.
fffffffffffffff..fffffff.fffffff.f.fffffffffffffff.ff.ff.fffff.ff.ff.
fffffffffffffffff..f..fff.fff.ffffffffffff.fffffff.fffff.fff.fff.ffffffffff.fff
fffff.....ff..ff..f..fff..ff.fffffff..ff......ffffffff.f.fff.ff.f...f...ff.f.f.f.f.
ffff..ff..ffff.f.ffff..ffff.fff.ffff.f.ff...ff.fff.fffff.fffffffffff.fff.fffffffff.ff
f.f.....ffffffffffff..f.f..f..ff..ff..f..f.ff....f.fff.fff.fff.f......f..ff.ffff.f.f.
ff.fffff.fff...ffff..f.f..f.f..fffffffffff..fffffffffff.ff.ff..fff.ffff.ff.ffff.fff.ffffff
.f..ffff.f.f.ff..ffffff..f.fffffffff.ffffff.fffffff.ff.ff..fffffff.f.ff.ffffffffffffff.f.f
f.ffffffffffffffffff.ffffff.fff.ffff.fffffff.f.ffff.ffffff.fff..ffff.fffffffff.ffff.ffff.f.
f.f..ff.f.ffff.f.f..f..ff.ff.f.f.f..ff.ffff....f..ff.f.fffffffff.f.f..fff.f..ff...fff.f.fff..
ffff.f.f.ffffffff.fffffffffffff.ff..fffff..f.ffffff.fff.f.ff.f.fffff..f.fffffff.ffffff.fff.ff.ff
.f.ffff.ff.ff.fff.fffff.fffffffff..fff.f.f.ff...ff.f.f..ffffff.fff.f..fff.f.f.f.ffff..ff....ff.fff
......ff..f......f.f.f..f....ff.fff.f.f.f.f..f.fff.fffff....fffff.f.f.f...fffff.f.........f.ff.f..
*/
class Solution
{
    static void Main(string[] args) {
        int N = int.Parse(Console.ReadLine());
        for (int i = 0; i < N; i++) {
            HowManyDrops(Console.ReadLine());
        }
    }
    private static void HowManyDrops(string? input) {
        char[] Forest = input.ToCharArray();
        int Counter = 0;
        for (int i = 0; i < Forest.Length; i++) {
            if (Forest[i] == 'f') {
                Forest[i] = '.';
                if (i < Forest.Length - 1) Forest[i + 1] = '.';
                if (i < Forest.Length - 2) Forest[i + 2] = '.';
                Counter++;
            }
        }
        Console.WriteLine(Counter);
    }
}

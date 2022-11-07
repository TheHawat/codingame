/* Author: Michał Hołowaty
 * Original Upload Date: 07/11/2022
 * Assignment Link:https://www.codingame.com/ide/puzzle/frame-the-picture
 * Example Input:
Oo:
3 7
   _o  
 _< \_ 
(_)>(_)
 * */
class Picture
{
    private List<string> _image { get; set; }
    private int _width { get; set; }
    public Picture(int width) {
        _width = width;
        _image = new();
    }
    internal void AddRow(string row) {
        _image.Add(row);
    }
    private void AddFrameCharacter(char frameCharacter) {
        for (int i = 0; i < _image.Count; i++) {
            _image[i] += frameCharacter;
            _image[i] = frameCharacter + _image[i];
        }
        _width += 2;
        string FullLine = new(frameCharacter, _width);
        _image.Add(FullLine);
        _image.Insert(0, FullLine);
    }
    internal void TypeOut() {
        for (int i = 0; i < _image.Count; i++) {
            Console.WriteLine(_image[i]);
        }
    }
    internal void AddFrame(string? framePattern) {
        framePattern = framePattern + " ";
        for (int i = framePattern.Length - 1; i >=0; i-- ) {
            AddFrameCharacter(framePattern[i]);
        }
    }
}
class Solution
{
    static Picture ReadInput() {
        string FramePattern = Console.ReadLine(); // the ASCII art pattern to use to frame the picture
        string[] Inputs = Console.ReadLine().Split(' ');
        int h = int.Parse(Inputs[0]); // the height of the picture
        int w = int.Parse(Inputs[1]); // the width  of the picture
        Picture Hawat = new(w);
        for (int i = 0; i < h; i++) {
            Hawat.AddRow(Console.ReadLine());
        }
        Hawat.AddFrame(FramePattern);
        return Hawat;
    }
    static void Main(string[] args) {
        ReadInput().TypeOut();
    }
}
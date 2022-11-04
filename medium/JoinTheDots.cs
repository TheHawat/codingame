/* Author: Michał Hołowaty
 * Original Upload Date: 04/11/2022
 * Assignment Link: https://www.codingame.com/ide/puzzle/join-the-dots
 * Example Input:
13 13
....2...1....
.............
......A...9..
.............
3......H....8
...B.........
.........G...
.............
4..C.....F..7
.............
.....D.E.....
.............
....5...6....
 * */
class DottedImage
{
    private List<char[]> _image { get; set; }
    private List<(int Number, int X, int Y)> _numberCoordinates { get; set; }
    public DottedImage(List<char[]> image) {
        _image = image;
        _numberCoordinates = new List<(int Number, int X, int Y)>();
    }
    private void FindNumbers() {
        _numberCoordinates.Clear();
        for (int i = 0; i < _image.Count; i++) {
            for (int j = 0; j < _image[i].Length; j++) {
                ProcessSigns(i, j);
            }
        }
        _numberCoordinates = _numberCoordinates.OrderBy(x => x.Number).ToList();
    }
    private void ProcessSigns(int i, int j) {
        if (_image[i][j] == '.') {
            _image[i][j] = ' ';
            return;
        }
        _numberCoordinates.Add(((int)_image[i][j], i, j));
        _image[i][j] = 'o';
    }
    private void DrawLine(int inputIndex) {
        (int X, int Y) Cursor = (_numberCoordinates[inputIndex].X, _numberCoordinates[inputIndex].Y);
        (int X, int Y) End = (_numberCoordinates[inputIndex + 1].X, _numberCoordinates[inputIndex + 1].Y);
        (char Line, int DX, int DY) Transformation = GetTransformation(inputIndex, Cursor, End);
        while (Cursor.X != End.X || Cursor.Y != End.Y) {
            Cursor.X += Transformation.DX;
            Cursor.Y += Transformation.DY;
            _image[Cursor.X][Cursor.Y] = FindCross(Transformation.Line, _image[Cursor.X][Cursor.Y]);
        }
        _image[Cursor.X][Cursor.Y] = 'o';
    }
    private char FindCross(char line, char image) {
        if (image == ' ') return line;
        if ((image == '-' && line == '|') || (image == '|' && line == '-')) return '+';
        if ((image == '/' && line == '\\') || (image == '\\' && line == '/')) return 'X';
        return '*';
    }
    private (char Line, int DX, int DY) GetTransformation(int inputIndex, (int X, int Y) start, (int X, int Y) end) {
        int DeltaX = end.X - start.X;
        int DeltaY = end.Y - start.Y;
        return GetTransformationValues(DeltaX, DeltaY);
    }
    private (char Line, int DX, int DY) GetTransformationValues(int deltaX, int deltaY) {
        if (deltaX == 0 && deltaY < 0) return ('-', 0, -1);
        if (deltaX == 0 && deltaY > 0) return ('-', 0, 1);
        if (deltaY == 0 && deltaX < 0) return ('|', -1, 0);
        if (deltaY == 0 && deltaX > 0) return ('|', 1, 0);
        if (deltaX < 0 && deltaY < 0) return ('\\', -1, -1);
        if (deltaX > 0 && deltaY > 0) return ('\\', 1, 1);
        if (deltaX < 0 && deltaY > 0) return ('/', -1, 1);
        //if (deltaX > 0 && deltaY < 0)
        return ('/', 1, -1);
    }
    internal void CompleteAssignment() {
        FindNumbers();
        DrawAllLines();
        TypeOut();
    }
    private void TypeOut() {
        for (int i = 0; i < _image.Count; i++) {
            Console.WriteLine(string.Join("", _image[i]).TrimEnd());
        }
    }
    private void DrawAllLines() {
        while (_numberCoordinates.Count > 1) {
            DrawLine(0);
            _numberCoordinates.RemoveAt(0);
        }
    }
}
class Solution
{
    static DottedImage ReadInput() {
        List<char[]> Image = new();
        string[] inputs = Console.ReadLine().Split(' ');
        int H = int.Parse(inputs[0]);
        for (int i = 0; i < H; i++) {
            Image.Add(Console.ReadLine().ToCharArray());
        }
        return new DottedImage(Image);
    }
    static void Main(string[] args) {
        ReadInput().CompleteAssignment();
    }
}
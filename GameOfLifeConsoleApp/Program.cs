using GameOfLifeEngine;
using System.Runtime.InteropServices;

[DllImport("kernel32.dll", ExactSpelling = true)]
static extern IntPtr GetConsoleWindow();

[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

const int MAXIMIZE = 3;

Console.ReadKey();
Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
ShowWindow(GetConsoleWindow(), MAXIMIZE);
Console.CursorVisible = false;
Console.SetCursorPosition(0, 0);

var gameEngine = new GameEngine
(
    rows:48,
    cols:200,
    density:2
);

while (true)
{
    Console.Title = gameEngine.CurrentGeneration.ToString();

    var field = gameEngine.GetCurrentGeneration();

    for (int y = 0; y < field.GetLength(1); y++)
    {
        var str = new char[field.GetLength(0)];

        for (int x = 0; x < field.GetLength(0); x++)
        {
            if (field[x, y])
                str[x] = '#';
            else
                str[x] = ' ';
        }
        Console.WriteLine(str);
    }
    Console.SetCursorPosition(0, 0);
    gameEngine.NextGeneraiton();
}

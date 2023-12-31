using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazeConsole;
internal class ConsoleService
{
    private string _foregroundColorString = "lime";
    private string _backgroundcolorString = "black";

    public int WindowWidth { get; set; }
    public int WindowHeight { get; set; }
    public int WindowTop { get; set; }
    public int WindowLeft { get; set; }
    public int CursorLeft { get; set; }
    public int CursorTop { get; set; }
    public string? Title { get; set; }
    public bool ShowCursor { get; set; }
    public bool CapsLock { get; set; }
    public bool NumberLock { get; set; }
    public bool KeyAvailable { get; set; }
    public ConsoleColor ForegroundColor { get; set; }
    public ConsoleColor BackgroundColor { get; set; }
    internal string ForegroundColorString
    {
        get { return _foregroundColorString; }
        set
        {
            _foregroundColorString = value;
            ForegroundColor = ConvertToConsoleColor(value);
        }
    }
    internal string BackgroundColorString
    {
        get { return _backgroundcolorString; }
        set
        {
            _backgroundcolorString = value;
            BackgroundColor = ConvertToConsoleColor(value);
        }
    }
    internal EventCallback<string> OnWrite { get; set; }
    internal EventCallback<string> OnWriteLine { get; set; }
    internal EventCallback<string> OnReadKey { get; set; }
    internal EventCallback OnRead { get; set; }
    internal EventCallback OnReadLine { get; set; }
    internal EventCallback OnBeep { get; set; }
    internal EventCallback OnClear { get; set; }
    internal EventCallback OnResetColor { get; set; }


    public void Write(string message) => OnWrite.InvokeAsync(message);
    public void WriteLine(string message) => OnWriteLine.InvokeAsync(message);
    public void ReadLine() => OnReadLine.InvokeAsync();
    public void Read() => OnRead.InvokeAsync();
    public void Beep() => OnBeep.InvokeAsync();
    public void Clear() => OnClear.InvokeAsync();
    public void ResetColor() => OnResetColor.InvokeAsync();
    public (int Column, int Row) GetCursorPosition()
    {
        return (CursorLeft, CursorTop);
    }
    public void SetSize(int width, int height)
    {
        WindowHeight = height;
        WindowWidth = width;
    }
    private ConsoleColor ConvertToConsoleColor(string color)
    {
        switch (color)
        {
            case "black":
                return ConsoleColor.Black;
            case "blue":
                return ConsoleColor.Blue;
            case "cyan":
                return ConsoleColor.Cyan;
            case "darkblue":
                return ConsoleColor.DarkBlue;
            case "darkcyan":
                return ConsoleColor.DarkCyan;
            case "darkgray":
                return ConsoleColor.DarkGray;
            case "darkgreen":
                return ConsoleColor.DarkGreen;
            case "darkmagenta":
                return ConsoleColor.DarkMagenta;
            case "darkred":
                return ConsoleColor.DarkRed;
            case "darkyellow":
                return ConsoleColor.DarkYellow;
            case "gray":
                return ConsoleColor.Gray;
            case "green":
                return ConsoleColor.Green;
            case "magenta":
                return ConsoleColor.Magenta;
            case "red":
                return ConsoleColor.Red;
            case "white":
                return ConsoleColor.White;
            case "yellow":
                return ConsoleColor.Yellow;
            default:
                throw new ArgumentOutOfRangeException(nameof(color));
        }
    }
    private string ConvertToColorString(ConsoleColor color)
    {
        switch (color)
        {
            case ConsoleColor.Black:
                return "black";
            case ConsoleColor.DarkBlue:
                return "darkblue";
            case ConsoleColor.DarkGreen:
                return "darkgreen";
            case ConsoleColor.DarkCyan:
                return "darkcyan";
            case ConsoleColor.DarkRed:
                return "darkred";
            case ConsoleColor.DarkMagenta:
                return "darkmagenta";
            case ConsoleColor.DarkYellow:
                return "darkyellow";
            case ConsoleColor.Gray:
                return "gray";
            case ConsoleColor.DarkGray:
                return "darkgray";
            case ConsoleColor.Blue:
                return "blue";
            case ConsoleColor.Green:
                return "green";
            case ConsoleColor.Cyan:
                return "cyan";
            case ConsoleColor.Red:
                return "red";
            case ConsoleColor.Magenta:
                return "magenta";
            case ConsoleColor.Yellow:
                return "yellow";
            case ConsoleColor.White:
                return "white";
            default:
                throw new ArgumentOutOfRangeException(nameof(color));
        }
    }


}

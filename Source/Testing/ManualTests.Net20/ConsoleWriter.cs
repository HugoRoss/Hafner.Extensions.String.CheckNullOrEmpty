namespace ManualTests;

using System;

internal sealed class ConsoleWriter {

    private ConsoleColor DefaultForegroundColor { get; }
    private ConsoleColor DefaultBackgroundColor { get; }

    public ConsoleWriter() {
        DefaultForegroundColor = Console.ForegroundColor;
        DefaultBackgroundColor = Console.BackgroundColor;
    }

    public void Write(string text, ConsoleColor? foregroundColor = null, ConsoleColor? backgroundColor = null) {
        Action<string> action = Console.Out.Write;
        PrivateWrite(action,text, foregroundColor, backgroundColor);
    }

    public void WriteLine(string text = "", ConsoleColor? foregroundColor = null, ConsoleColor? backgroundColor = null) {
        Action<string> action = Console.Out.WriteLine;
        PrivateWrite(action, text, foregroundColor, backgroundColor);
    }

    private void PrivateWrite(Action<string> action, string? text, ConsoleColor? foregroundColor = null, ConsoleColor? backgroundColor = null) {
        text ??= "[null]";
        if (foregroundColor is not null) {
            Console.ForegroundColor = foregroundColor.Value;
        }
        if (backgroundColor is not null) {
            Console.BackgroundColor = backgroundColor.Value;
        }
        action.Invoke(text);
        if (foregroundColor is not null) {
            Console.ForegroundColor = DefaultForegroundColor;
        }
        if (backgroundColor is not null) {
            Console.BackgroundColor = DefaultBackgroundColor;
        }
    }

}

namespace ManualTests;

using System;
using System.Runtime.CompilerServices;
using Hafner.Extensions;

internal class Tests(ConsoleWriter consoleWriter) {

    /// <summary>
    /// Verifies that a null or empty argument throws an <see cref="ArgumentNullException"/> with the parameter name.
    /// </summary>
    public bool CheckNullOrEmpty_Throws_Parameter() {
        StringKind[] stringKinds = { StringKind.Null, StringKind.Empty };
        bool success = true;
        foreach (StringKind stringKind in stringKinds) {
            success &= CheckNullOrEmpty_Throws_Parameter(stringKind);
        }
        return success;
    }

    private bool CheckNullOrEmpty_Throws_Parameter(StringKind stringKind) {
        string? sut = GetTestString(stringKind);
        consoleWriter.Write($"Test: '{GetUnitTestName()}({stringKind})'");
        try {
            sut.CheckNullOrEmpty();
            consoleWriter.WriteLine("Failed!\r\nNo exception was thrown!", ConsoleColor.Red);
            return false;
        } catch (ArgumentNullException expectedException) {
            string expected = "The argument for parameter 'sut' is mandatory and cannot be null or empty!";
            string actual = expectedException.Message;
            int index = actual.IndexOf(expected, StringComparison.Ordinal);
            if (index < 0) {
                consoleWriter.WriteLine($"Failed!\r\nThe error message does not contain the expected text!\r\nExpected: {expected}\r\nActual: {actual}", ConsoleColor.Red);
                return false;
            }
        }
        consoleWriter.WriteLine($"Succeeded.", ConsoleColor.Green);
        return true;
    }

    /// <summary>
    /// Verifies that a normal or white-space argument works as expected with the parameter name.
    /// </summary>
    public bool CheckNullOrEmpty_Works_Parameter() {
        StringKind[] stringKinds = { StringKind.WhiteSpace, StringKind.Normal };
        bool success = true;
        foreach (StringKind stringKind in stringKinds) {
            success &= CheckNullOrEmpty_Works_Parameter(stringKind);
        }
        return success;
    }

    private bool CheckNullOrEmpty_Works_Parameter(StringKind stringKind) {
        string? sut = GetTestString(stringKind);
        string result = sut.CheckNullOrEmpty();
        if (Object.ReferenceEquals(sut, result)) {
            consoleWriter.WriteLine($"Succeeded.", ConsoleColor.Green);
            return true;
        }
        consoleWriter.WriteLine($"Failed!\r\nNot the same instance was returned.", ConsoleColor.Red);
        return false;
    }


    /// <summary>
    /// Verifies that a null or empty argument throws an <see cref="ArgumentNullException"/> with the given expression.
    /// </summary>
    public bool CheckNullOrEmpty_Throws_Expression() {
        StringKind[] stringKinds = { StringKind.Null, StringKind.Empty };
        bool success = true;
        foreach (StringKind stringKind in stringKinds) {
            success &= CheckNullOrEmpty_Throws_Expression(stringKind);
        }
        return success;
    }

    private bool CheckNullOrEmpty_Throws_Expression(StringKind stringKind) {
        consoleWriter.Write($"Test: '{GetUnitTestName()}({stringKind})'");
        try {
            GetTestString(stringKind).CheckNullOrEmpty();
            consoleWriter.WriteLine("Failed!\r\nNo exception was thrown!", ConsoleColor.Red);
            return false;
        } catch (ArgumentNullException expectedException) {
            string expected = "The result of expression 'GetTestString(stringKind)' is mandatory and cannot be null or empty!";
            string actual = expectedException.Message;
            int index = actual.IndexOf(expected, StringComparison.Ordinal);
            if (index < 0) {
                consoleWriter.WriteLine($"Failed!\r\nThe error message does not contain the expected text!\r\nExpected: {expected}\r\nActual: {actual}", ConsoleColor.Red);
                return false;
            }
        }
        consoleWriter.WriteLine($"Succeeded.", ConsoleColor.Green);
        return true;
    }

    /// <summary>
    /// Verifies that a normal or white-space argument works as expected with the given expression.
    /// </summary>
    public bool CheckNullOrEmpty_Works_Expression() {
        StringKind[] stringKinds = { StringKind.WhiteSpace, StringKind.Normal };
        bool success = true;
        foreach (StringKind stringKind in stringKinds) {
            success &= CheckNullOrEmpty_Works_Expression(stringKind);
        }
        return success;
    }

    private bool CheckNullOrEmpty_Works_Expression(StringKind stringKind) {
        string result = GetTestString(stringKind).CheckNullOrEmpty();
        if (result is not null) {
            consoleWriter.WriteLine($"Succeeded.", ConsoleColor.Green);
            return true;
        }
        consoleWriter.WriteLine($"Failed!\r\nNull was returned.", ConsoleColor.Red);
        return false;
    }

    /// <summary>
    /// Verifies that a <see langword="null"/> or empty argument throws an <see cref="ArgumentNullException"/> with a generic message
    /// if the parameter name is <see langword="null"/>.
    /// </summary>
    public bool CheckNullOrEmpty_Throws_ParameterNameNull() {
        StringKind[] stringKinds = { StringKind.Null, StringKind.Empty };
        bool success = true;
        foreach (StringKind stringKind in stringKinds) {
            success &= CheckNullOrEmpty_Throws_ParameterNameNull(stringKind, null!);
        }
        return success;
    }

    private bool CheckNullOrEmpty_Throws_ParameterNameNull(StringKind stringKind, string parameterName) {
        consoleWriter.Write($"Test: '{GetUnitTestName()}({stringKind}, {parameterName ?? "null"})'");
        try {
            GetTestString(stringKind).CheckNullOrEmpty(null!);
            consoleWriter.WriteLine("Failed!\r\nNo exception was thrown!", ConsoleColor.Red);
            return false;
        } catch (ArgumentNullException expectedException) {
            string expected = "The argument is mandatory and cannot be null or empty!";
            string actual = expectedException.Message;
            int index = actual.IndexOf(expected, StringComparison.Ordinal);
            if (index < 0) {
                consoleWriter.WriteLine($"Failed!\r\nThe error message does not contain the expected text!\r\nExpected: {expected}\r\nActual: {actual}", ConsoleColor.Red);
                return false;
            }
        }
        consoleWriter.WriteLine($"Succeeded.", ConsoleColor.Green);
        return true;
    }

    /// <summary>
    /// Verifies that a non-null or white-space argument works as expected even if the parameter name is <see langword="null"/>.
    /// </summary>
    public bool CheckNullOrEmpty_Works_ParameterNameNull() {
        StringKind[] stringKinds = { StringKind.WhiteSpace, StringKind.Normal };
        bool success = true;
        foreach (StringKind stringKind in stringKinds) {
            success &= CheckNullOrEmpty_Works_ParameterNameNull(stringKind);
        }
        return success;
    }

    private bool CheckNullOrEmpty_Works_ParameterNameNull(StringKind stringKind) {
        string result = GetTestString(stringKind).CheckNullOrEmpty();
        if (String.IsNullOrEmpty(result)) {
            consoleWriter.WriteLine($"Failed!\r\nNull or empty was returned.", ConsoleColor.Red);
            return false;
        }
        consoleWriter.WriteLine($"Succeeded.", ConsoleColor.Green);
        return true;
    }

    private static string? GetTestString(StringKind stringKind) {
        switch (stringKind) {
            case StringKind.Null:
                return null;
            case StringKind.Empty:
                return "";
            case StringKind.WhiteSpace:
                return "   ";
            case StringKind.Normal:
                return "abc";
        }
        throw new NotSupportedException($"{nameof(stringKind)} '{stringKind}' is not supported!");
    }

    private static string GetUnitTestName([CallerMemberName] string caller = "") {
        return $"{caller}";
    }

    private enum StringKind {
        Null,
        Empty,
        WhiteSpace,
        Normal
    }

}

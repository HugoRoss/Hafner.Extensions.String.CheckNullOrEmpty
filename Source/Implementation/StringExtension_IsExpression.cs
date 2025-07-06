namespace Hafner.Extensions;

using System.Diagnostics.CodeAnalysis;

/// <summary>
/// Class that provides an extension method that returns <see langword="true"/> if a given parameter name string is recognized as an expression, <see langword="false"/> otherwise.
/// </summary>
[SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "It looks smarter.")]
internal static class StringExtension_IsExpression {

    /// <summary>
    /// Extension method to check if a parameter name string is an expression (<see langword="true"/>) or not (<see langword="false"/>). <see langword="null"/>
    /// returns <see langword="false"/>.
    /// </summary>
    /// <param name="paramName">The name of the expression or parameter.</param>
    /// <returns><see langword="true"/> if the given <paramref name="paramName"/> is recognized as an expression, <see langword="false"/> otherwise.</returns>
    public static bool IsExpression(this string? paramName) {
        if (paramName is null) return false;
        return (paramName.IndexOfAny([' ', '\t', '\n', '\r', '.', '(', '[']) > -1);
    }

}

namespace Hafner.Extensions;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

/// <summary>
/// Class that provides an extension method to check if a string is <see langword="null"/> or empty that throws an
/// <see cref="ArgumentNullException"/> if it is.
/// </summary>
[SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "It looks smarter.")]
public static class StringExtension_CheckNullOrEmpty {

    /// <summary>
    /// Extension method to check if a string is <see langword="null"/> or empty that throws an <see cref="ArgumentNullException"/>
    /// if it is and otherwise returns the same string.
    /// </summary>
    /// <param name="text">The string to check.</param>
    /// <param name="paramName">The name of the parameter which is filled in by the compiler.</param>
    /// <returns>The same string which is guaranteed not to be <see langword="null"/> or empty.</returns>
    /// <exception cref="ArgumentNullException">An <see cref="ArgumentNullException"/> is thrown if <paramref name="text"/> is <see langword="null"/> or empty.</exception>
    [SuppressMessage("Usage", "CA2208:Instantiate argument exceptions correctly", Justification = "Edge case when the received parameter name is null.")]
    public static string CheckNullOrEmpty([NotNull] this string? text, [CallerArgumentExpression(nameof(text))] string paramName = "") {
        if (String.IsNullOrEmpty(text)) {
            if (paramName is null) throw new ArgumentNullException("unknown", "The argument is mandatory and cannot be null or empty!");
            if (paramName.IsExpression()) throw new ArgumentNullException(paramName, $"The result of expression '{paramName}' is mandatory and cannot be null or empty!");
            throw new ArgumentNullException(paramName, $"The argument for parameter '{paramName}' is mandatory and cannot be null or empty!");
        }
#pragma warning disable CS8603 //Possible null reference return.
#pragma warning disable CS8777 //Parameter must have a non-null value when exiting.
        return text;
#pragma warning restore CS8777 //Parameter must have a non-null value when exiting.
#pragma warning restore CS8603 //Possible null reference return.
    }

}

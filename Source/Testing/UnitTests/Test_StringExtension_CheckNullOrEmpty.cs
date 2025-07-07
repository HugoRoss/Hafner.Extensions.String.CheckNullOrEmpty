namespace Hafner.Tools.Tests;

using System;
using FluentAssertions;
using Hafner.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/// <summary>
/// Ensures correct functionality of the <see cref="StringExtension_CheckNullOrEmpty.CheckNullOrEmpty">String.CheckNullOrEmpty()</see> extension method.
/// </summary>
[TestClass]
public partial class Test_StringExtension_CheckNullOrEmpty {

    /// <summary>
    /// Verifies that a <see langword="null"/> argument throws an <see cref="ArgumentNullException"/> with the parameter name.
    /// </summary>
    [DataTestMethod("StringExtension.CheckNullOrEmpty: throws (using parameter name)")]
    [DataRow(StringKind.Null)]
    [DataRow(StringKind.Empty)]
    public void CheckNullOrEmpty_Throws_Parameter(StringKind stringKind) {
        string? sut = GetTestString(stringKind);
        ArgumentNullException exception = Assert.ThrowsException<ArgumentNullException>(() => sut.CheckNullOrEmpty());
        exception.Message.Should().Match("The argument for parameter 'sut' is mandatory and cannot be null or empty!*Parameter *sut*");
    }

    /// <summary>
    /// Verifies that a normal or white-space argument works as expected with the parameter name.
    /// </summary>
    [DataTestMethod("StringExtension.CheckNullOrEmpty: works (using parameter name)")]
    [DataRow(StringKind.WhiteSpace)]
    [DataRow(StringKind.Normal)]
    public void CheckNullOrEmpty_Works_Parameter(StringKind stringKind) {
        string? sut = GetTestString(stringKind);
        string result = sut.CheckNullOrEmpty();
        Assert.AreSame(sut, result);
    }

    /// <summary>
    /// Verifies that a <see langword="null"/> or empty argument throws an <see cref="ArgumentNullException"/> with the given expression.
    /// </summary>
    [DataTestMethod("StringExtension.CheckNullOrEmpty: throws (using an expression)")]
    [DataRow(StringKind.Null)]
    [DataRow(StringKind.Empty)]
    public void CheckNullOrEmpty_Throws_Expression(StringKind stringKind) {
        ArgumentNullException exception = Assert.ThrowsException<ArgumentNullException>(() => GetTestString(stringKind).CheckNullOrEmpty());
        exception.Message.Should().Match("The result of expression 'GetTestString(stringKind)' is mandatory and cannot be null or empty!*Parameter *GetTestString(stringKind)*");
    }

    /// <summary>
    /// Verifies that a non-null or white-space argument works as expected with the parameter name.
    /// </summary>
    [DataTestMethod("StringExtension.CheckNullOrEmpty: works (using an expression)")]
    [DataRow(StringKind.WhiteSpace)]
    [DataRow(StringKind.Normal)]
    public void CheckNullOrEmpty_Works_Expression(StringKind stringKind) {
        string result = GetTestString(stringKind).CheckNullOrEmpty();
        Assert.IsTrue(!String.IsNullOrEmpty(result));
    }

    /// <summary>
    /// Verifies that a <see langword="null"/> or empty argument throws an <see cref="ArgumentNullException"/> with a generic message
    /// if the parameter name is <see langword="null"/>.
    /// </summary>
    [DataTestMethod("StringExtension.CheckNullOrEmpty: throws (using an expression)")]
    [DataRow(StringKind.Null)]
    [DataRow(StringKind.Empty)]
    public void CheckNullOrEmpty_Throws_ParameterNameNull(StringKind stringKind) {
        ArgumentNullException exception = Assert.ThrowsException<ArgumentNullException>(() => GetTestString(stringKind).CheckNullOrEmpty(null!));
        exception.Message.Should().Match("The argument is mandatory and cannot be null or empty!*Parameter *unknown*");
    }

    /// <summary>
    /// Verifies that a non-null or white-space argument works as expected even if the parameter name is <see langword="null"/>.
    /// </summary>
    [DataTestMethod("StringExtension.CheckNullOrEmpty: works (using an expression)")]
    [DataRow(StringKind.WhiteSpace)]
    [DataRow(StringKind.Normal)]
    public void CheckNullOrEmpty_Works_ParameterNameNull(StringKind stringKind) {
        string result = GetTestString(stringKind).CheckNullOrEmpty(null!);
        Assert.IsTrue(!String.IsNullOrEmpty(result));
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

}

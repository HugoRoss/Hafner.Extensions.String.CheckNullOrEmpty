namespace Hafner.Tools.Tests;

using System;
using System.ComponentModel;
using System.Diagnostics;
using FluentAssertions;
using Hafner.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/// <summary>
/// Ensures correct functionality of the <see cref="StringExtension_CheckNullOrEmpty.CheckNullOrEmpty(string?, string)">String.CheckNullOrEmpty()</see> extension method.
/// </summary>
[TestClass]
public class ManualTests_Invocation {

    /// <summary>
    ///Gets or sets the test context which provides
    ///information about and functionality for the current test run.
    ///</summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public TestContext TestContext { get; set; } = null!; //Hint: Automatically assigned by the test runner

    /// <summary>
    /// Writes a text to the test context, leaving the cursor on the same line.
    /// </summary>
    /// <param name="text">The text to be written.</param>
    private void Write(string text) {
        TestContext.Write(text);
    }

    /// <summary>
    /// Writes a text to the test context, advancing the cursor to the next line.
    /// </summary>
    /// <param name="text">The text to be written.</param>
    private void WriteLine(string text = "") {
        TestContext.WriteLine(text);
    }


    /// <summary>
    /// Verifies that a null argument throws an <see cref="ArgumentNullException"/> with the parameter name.
    /// </summary>
    [DataTestMethod]
    [DataRow(@"Net20")]
    [DataRow(@"Net30")]
    [DataRow(@"Net35")]
    [DataRow(@"Net40")]
    [DataRow(@"Net403")]
    [DataRow(@"Net45")]
    [DataRow(@"Net451")]
    [DataRow(@"Net452")]
    [DataRow(@"Net46")]
    [DataRow(@"Net461")]
    public void ManualTests_Invoke(string frameworkMoniker) {
        string testApp = $@"..\..\..\..\ManualTests.{frameworkMoniker}\bin\Debug\{frameworkMoniker}\ManualTests.{frameworkMoniker}.exe";

        ProcessStartInfo psi = new ProcessStartInfo {
            FileName = "cmd.exe",                   // Command to run
            Arguments = $"/c {testApp}",            // Arguments (/c tells cmd to run and exit)
            RedirectStandardOutput = true,          // Redirect the standard output
            UseShellExecute = false,                // Required for redirection
            CreateNoWindow = true                   // Don't create a window
        };

        // Start the process
        try {
            using (Process process = Process.Start(psi)) {
                process.WaitForExit();
                string output = process.StandardOutput.ReadToEnd();
                WriteLine(output.TrimEnd());
                if (output.IndexOf("All tests succeeded!", StringComparison.OrdinalIgnoreCase) == -1) {
                    throw new AssertFailedException($"Manual test '{testApp}' did not complete successfully! Details see test output...");
                }
            }
        } catch (UnitTestAssertException) {
            throw;
        } catch (Exception ex) {
            WriteLine($"Something went wrong invoking manual test '{testApp}'!");
            WriteLine($"The error message was: {ex.Message}");
            throw;
        }
    }

}

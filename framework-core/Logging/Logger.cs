using NUnit.Framework;
using System;
using System.Diagnostics;

namespace framework_core.Logging
{
    /// <summary>
    /// A custom logging class for CardinalCheck tests.
    /// </summary>
    public class Logger
    {
        /// <summary>
        /// Write an info-level loging message to the console.
        /// </summary>
        /// <param name="msg">The string message to be written to the log.</param>
        public static void Info(string msg)
        {
            Info(msg: msg, args: Array.Empty<string>());
        }

        /// <summary>
        /// Write an error-level loging message to the console.
        /// </summary>
        /// <param name="msg">The string message to be written to the log.</param>
        public static void Error(string msg)
        {
            Error(msg: msg, args: Array.Empty<string>());
        }

        /// <summary>
        /// Write an info-level loging message to the console.
        /// </summary>
        /// <param name="msg">The string message to be written to the log.</param>
        /// <param name="args">An array of strings to be appended to the message.</param>
        public static void Info(string msg, params string[] args)
        {
            TestContext.WriteLine(msg, args);
            Debug.WriteLine(msg, args);
        }

        /// <summary>
        /// Write an error-level loging message to the console.
        /// </summary>
        /// <param name="msg">The string message to be written to the log.</param>
        /// <param name="args">An array of strings to be appended to the message.</param>
        public static void Error(string msg, params string[] args)
        {
            TestContext.WriteLine(msg, args);
            Debug.WriteLine(msg, args);
        }
    }
}

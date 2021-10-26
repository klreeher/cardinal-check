using System;
using System.Diagnostics;

namespace cardinal.webFramework
{
    /// <summary>
    /// A custom logging class for KorQA tests.
    /// </summary>
    public class Logger
    {
        /// <summary>
        /// Write an info-level loging message to the console.
        /// </summary>
        /// <param name="msg">The string message to be written to the log.</param>
        public static void Info(string msg)
        {
            Console.WriteLine(msg);
            Debug.WriteLine(msg);
        }

        /// <summary>
        /// Write an error-level loging message to the console.
        /// </summary>
        /// <param name="msg">The string message to be written to the log.</param>
        public static void Error(string msg)
        {
            Console.Error.WriteLine(msg);
            Debug.WriteLine(msg);
        }

        /// <summary>
        /// Write an info-level loging message to the console.
        /// </summary>
        /// <param name="msg">The string message to be written to the log.</param>
        /// <param name="args">An array of strings to be appended to the message.</param>
        public static void Info(string msg, params string[] args)
        {
            Console.WriteLine(msg, args);
            Debug.WriteLine(msg, args);
        }

        /// <summary>
        /// Write an error-level loging message to the console.
        /// </summary>
        /// <param name="msg">The string message to be written to the log.</param>
        /// <param name="args">An array of strings to be appended to the message.</param>
        public static void Error(string msg, params string[] args)
        {
            Console.Error.WriteLine(msg, args);
            Debug.WriteLine(msg, args);
        }
    }
}

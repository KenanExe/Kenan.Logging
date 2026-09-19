using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Kenan.Logging
{
    /// <summary>
    /// Provides console logging with custom coloring and window focusing.
    /// </summary>
    public class LoggingService
    {
        [DllImport("kernel32.dll")]
        private static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        private const int SW_RESTORE = 9;

        static ConsoleColor WarnColor;
        static ConsoleColor MethodColor;

        /// <summary>
        /// Specifies the severity level of a log entry.
        /// </summary>
        public enum LogLevel
        {
            /// <summary>Information log entry.</summary>
            Info,

            /// <summary>Warning log entry.</summary>
            Warning,

            /// <summary>Error log entry.</summary>
            Error
        }

        /// <summary>
        /// Logs a formatted message to the console and brings the window to focus.
        /// </summary>
        /// <param name="Message">Message to log.</param>
        /// <param name="Level">Log level (Optional, default: LogLevel.Info).</param>
        public static void Log(string Message, LogLevel Level = LogLevel.Info)
        {
            IntPtr consoleHandle = GetConsoleWindow();
            if (consoleHandle != IntPtr.Zero)
            {
                ShowWindow(consoleHandle, SW_RESTORE);
                SetForegroundWindow(consoleHandle);
            }

            StackTrace stackTrace = new StackTrace();

            var CallerFrame = stackTrace.GetFrame(1);
            var Method = CallerFrame?.GetMethod();

            string problem;

            switch (Level)
            {
                case LogLevel.Info:
                    problem = "Info ";
                    WarnColor = ConsoleColor.Gray;
                    MethodColor = ConsoleColor.DarkGray;
                    break;
                case LogLevel.Warning:
                    problem = "Warning ";
                    WarnColor = ConsoleColor.Yellow;
                    MethodColor = ConsoleColor.DarkYellow;
                    break;
                case LogLevel.Error:
                    problem = "Error ";
                    WarnColor = ConsoleColor.Red;
                    MethodColor = ConsoleColor.DarkRed;
                    break;
                default:
                    problem = "Unknown ";
                    WarnColor = ConsoleColor.White;
                    MethodColor = ConsoleColor.Gray;
                    break;
            }
            var Header = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] ";
            var Body = Method != null ? $"{Method.DeclaringType?.Name}.{Method.Name} " : "Unknown.Method ";
            var Back = Message;

            Console.ForegroundColor = MethodColor;
            Console.Write(Header);
            Console.ForegroundColor = WarnColor;
            Console.Write(problem);
            Console.ForegroundColor = MethodColor;
            Console.Write(Body);
            Console.ForegroundColor = WarnColor;
            Console.WriteLine(Back);
            Console.ResetColor();
        }
    }
}
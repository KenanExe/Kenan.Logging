# 🪵 Kenan.Logging

A lightweight, single-purpose C# logging helper for console applications. Its only goal: **be simple.**

[![License](https://img.shields.io/github/license/KenanExe/Kenan.Logging)](https://github.com/KenanExe/Kenan.Logging/blob/master/LICENSE) [![Language](https://img.shields.io/badge/Language-C%23-blue)](https://github.com/KenanExe/Kenan.Logging) [![Platform](https://img.shields.io/badge/platform-Windows-lightgrey)](https://github.com/KenanExe/Kenan.Logging) [![.NET Framework](https://img.shields.io/badge/.NET%20Framework-4.7.2-512BD4)](https://dotnet.microsoft.com/) [![Release](https://img.shields.io/github/v/release/KenanExe/Kenan.Logging)](https://github.com/KenanExe/Kenan.Logging/releases/latest)

## 🚀 What Does It Do?

Kenan.Logging is a drop-in replacement for `Console.Write` / `Console.WriteLine`. Instead of plain, unstructured text, one call gives you a timestamped, color-coded, and readable log line — complete with the log level and the calling method — and brings the console window to the foreground so you never miss it. No configuration files, no heavy dependencies, just a single DLL.

## ✨ Key Features

- **Drop-in Replacement:** Swap `Console.Write` calls for `LoggingService.Log(...)` and get structured output immediately.
- **Three Log Levels:** `Info`, `Warning`, and `Error`, each with its own color scheme.
- **Automatic Caller Info:** Captures the calling class and method via `StackTrace` — no need to pass it manually.
- **Timestamped Entries:** Every log line is stamped with the current date and time.
- **Auto-Focus Console:** Brings the console window to the front and focuses it on every log call, so output never goes unnoticed.
- **Zero Dependencies:** A single DLL, nothing else to install.

## 🖼️ Sample Output
<img width="510" height="131" alt="demo" src="https://github.com/user-attachments/assets/4dbce01b-8365-46c8-bbf6-c6724f474f05" />


## 🛠️ Installation & Usage

1. Grab the latest DLL from the [Releases](https://github.com/KenanExe/Kenan.Logging/releases) page.
2. Add `Kenan.Logging.dll` as a reference in your project.
3. Start logging:

```csharp
using Kenan.Logging;

class Program
{
    static void Main()
    {
        LoggingService.Log("Application started.");
        LoggingService.Log("This is a warning message.", LoggingService.LogLevel.Warning);
        LoggingService.Log("Something went wrong!", LoggingService.LogLevel.Error);
    }
}
```

> No NuGet package yet — for now, referencing the DLL directly is the way to go.

## 📋 Requirements

- .NET Framework **4.7.2**
- Windows operating system (uses `kernel32.dll` / `user32.dll` P/Invoke calls to focus the console window)

## 🗺️ Roadmap

This is an early, first-version release, so there's a lot ahead:

- [ ] **Settings system:** toggle logging on/off and choose where logs go (console / file / both)
- [ ] File logging support (txt / json)
- [ ] Custom color themes per log level
- [ ] Option to disable the automatic console auto-focus behavior
- [ ] Log level filtering (e.g. only show Warning and above)
- [ ] NuGet package (if there's demand)

## 🤝 Contributing

This is an early-stage, actively developed project — issues, suggestions, and pull requests are always welcome.

## 📄 License

This project is licensed under the [MIT License](LICENSE.txt).

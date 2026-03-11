# QuickLog.net

`QuickLog.net` is a simple .NET logging library 

It supports logging:
- to the console
- to a file

## Features

- Dependency injection via `AddQuickLog(...)`
- Basic log levels (`Trace`, `Error``)
- Console output with timestamp
- File output with automatic directory creation

## Requirements

- .NET `10.0`

## Configuration

Configure it with DI:

```csharp
using QuickLog.net;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

services.AddQuickLog(options =>
{
	options.EnableConsoleLogging = true;
	options.EnableFileLogging = true;
	options.FileLoggingPath = "logs/exemple";
    options.AddDateToFileFormat = true;
});
```

Available options:

- `EnableConsoleLogging` (bool?): enables/disables console logging (default `true`)
- `EnableFileLogging` (bool?): enables/disables file logging (default `false`)
- `FileLoggingPath` (string?): log file path (for example `logs/exemple`)
- `AddDateToFileFormat` (bool?): enables/diasble date at the end of the file (for example `logs/exemple260311.log`)

## Usage

Inject the logger:

```csharp
using QuickLog.net.Logging;

public class App
{
	private readonly IQuickLog _quickLog;

	public App(IQuickLog quickLog)
	{
		_quickLog = quickLog;
	}

	public void Run()
	{
		_quickLog.LogTrace("Application started");
		_quickLog.LogError("This is a sample error log");
	}
}
```

## Log Format

Each line is written using this format:

```text
[yyyy-MM-dd HH:mm:ss] [LogType] message
```

Example:

```text
[2026-03-10 14:30:12] [Trace] Application started
```

## Log To A File

To write logs to a file, you must:

1. set `EnableFileLogging = true`
2. set `FileLoggingPath`

Valid example:

```csharp
services.AddQuickLog(options =>
{
	options.EnableConsoleLogging = true;
	options.EnableFileLogging = true;
	options.FileLoggingPath = "logs/exemple";
});
```

The directory is created automatically if needed.

## Run The Example

From the solution root:

```bash
dotnet run --project Exemple/Exemple.csproj
```

The file will be created here:

```text
Exemple/logs/quicklog.log
```

## Quick Structure

- `QuickLog.net/Logging/QuickLog.cs`: logger implementation
- `QuickLog.net/Logging/IQuickLog.cs`: logger contract
- `QuickLog.net/Model/QuickLogOption.cs`: configuration options
- `QuickLog.net/DI/ServiceCollectionExtension.cs`: `AddQuickLog` extension
- `Exemple/Program.cs`: usage example